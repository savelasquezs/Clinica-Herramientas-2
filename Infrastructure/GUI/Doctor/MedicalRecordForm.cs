using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Doctor
{
    public partial class MedicalRecordForm : Form
    {
        private readonly DoctorInputs doctorInputs;
        private readonly User currentUser;
        private Patient? selectedPatient;
        private Order? currentOrder;
        private List<Medication> medications = new List<Medication>();
        private List<Procedure> procedures = new List<Procedure>();
        private List<DiagnosticAid> diagnosticAids = new List<DiagnosticAid>();
        private bool hasDiagnosticAid = false;

        public MedicalRecordForm(DoctorInputs doctorInputs, User currentUser)
        {
            this.doctorInputs = doctorInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            LoadInventory();
        }

        private void LoadInventory()
        {
            try
            {
                medications = Program.Config.SupportConfig.SupportInputs.GetAllMedications();
                procedures = Program.Config.SupportConfig.SupportInputs.GetAllProcedures();
                diagnosticAids = Program.Config.SupportConfig.SupportInputs.GetAllDiagnosticAids();
                
                cmbMedication.Items.Clear();
                foreach (var med in medications) cmbMedication.Items.Add($"{med.Id} - {med.Name}");
                
                cmbProcedure.Items.Clear();
                foreach (var proc in procedures) cmbProcedure.Items.Add($"{proc.Id} - {proc.Name}");
                
                cmbDiagnosticAid.Items.Clear();
                foreach (var diag in diagnosticAids) cmbDiagnosticAid.Items.Add($"{diag.Id} - {diag.Name}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientSelectionForm(doctorInputs, currentUser);
            if (patientForm.ShowDialog() == DialogResult.OK && patientForm.SelectedPatient != null)
            {
                selectedPatient = patientForm.SelectedPatient;
                lblPatientInfo.Text = $"Paciente: {selectedPatient.Fullname} - DNI: {selectedPatient.Dni}";
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (selectedPatient == null)
            {
                MessageBox.Show("Por favor seleccione un paciente primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtOrderNumber.Text) || !int.TryParse(txtOrderNumber.Text, out int orderNumber))
            {
                MessageBox.Show("Por favor ingrese un número de orden válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Program.Config.DoctorConfig.DoctorUseCase.SetCurrentUser(currentUser);
                currentOrder = doctorInputs.CreateOrder(orderNumber, DateTime.Now);
                lblOrderInfo.Text = $"Orden #{currentOrder.OrderNumber} creada";
                grpOrderItems.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMedication_Click(object sender, EventArgs e)
        {
            if (currentOrder == null || selectedPatient == null) return;
            if (hasDiagnosticAid)
            {
                MessageBox.Show("No se pueden agregar medicamentos cuando hay ayudas diagnósticas en la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMedication.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDose.Text) ||
                string.IsNullOrWhiteSpace(txtDuration.Text) || !int.TryParse(txtDuration.Text, out int duration))
            {
                MessageBox.Show("Por favor complete todos los campos del medicamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var medText = cmbMedication.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(medText))
                {
                    MessageBox.Show("Por favor seleccione un medicamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var medId = int.Parse(medText.Split('-')[0].Trim());
                var medication = medications.First(m => m.Id == medId);
                var itemNumber = currentOrder.Items.Count + 1;
                doctorInputs.AddMedicationToOrder(currentOrder, itemNumber, medication.Cost, medication, txtDose.Text.Trim(), duration);
                MessageBox.Show("Medicamento agregado a la orden", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProcedure_Click(object sender, EventArgs e)
        {
            if (currentOrder == null || selectedPatient == null) return;
            if (hasDiagnosticAid)
            {
                MessageBox.Show("No se pueden agregar procedimientos cuando hay ayudas diagnósticas en la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProcedure.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtFrequency.Text) ||
                !int.TryParse(txtFrequency.Text, out int frequency))
            {
                MessageBox.Show("Por favor complete todos los campos del procedimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var procText = cmbProcedure.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(procText))
                {
                    MessageBox.Show("Por favor seleccione un procedimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var procId = int.Parse(procText.Split('-')[0].Trim());
                var procedure = procedures.First(p => p.Id == procId);
                var itemNumber = currentOrder.Items.Count + 1;
                int? specialistTypeId = chkRequiresSpecialist.Checked && !string.IsNullOrWhiteSpace(txtSpecialistTypeId.Text) && int.TryParse(txtSpecialistTypeId.Text, out int specId) ? specId : null;
                doctorInputs.AddProcedureToOrder(currentOrder, itemNumber, procedure.Cost, procedure, frequency, chkRequiresSpecialist.Checked, specialistTypeId);
                MessageBox.Show("Procedimiento agregado a la orden", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDiagnosticAid_Click(object sender, EventArgs e)
        {
            if (currentOrder == null || selectedPatient == null) return;
            if (currentOrder.Items.Count > 0)
            {
                MessageBox.Show("No se pueden agregar ayudas diagnósticas cuando ya hay otros items en la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDiagnosticAid.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Por favor complete todos los campos de la ayuda diagnóstica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var diagText = cmbDiagnosticAid.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(diagText))
                {
                    MessageBox.Show("Por favor seleccione una ayuda diagnóstica", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var diagId = int.Parse(diagText.Split('-')[0].Trim());
                var diagnosticAid = diagnosticAids.First(d => d.Id == diagId);
                var itemNumber = 1;
                int? specialistTypeId = chkDiagRequiresSpecialist.Checked && !string.IsNullOrWhiteSpace(txtDiagSpecialistTypeId.Text) && int.TryParse(txtDiagSpecialistTypeId.Text, out int specId) ? specId : null;
                doctorInputs.AddDiagnosticAidToOrder(currentOrder, itemNumber, diagnosticAid.Cost, diagnosticAid, quantity, chkDiagRequiresSpecialist.Checked, specialistTypeId);
                hasDiagnosticAid = true;
                MessageBox.Show("Ayuda diagnóstica agregada a la orden", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderItems()
        {
            if (currentOrder == null) return;
            var items = new List<string>();
            foreach (var item in currentOrder.Items)
            {
                if (item is MedicationOrderItem med) items.Add($"Item {item.ItemNumber}: {med.Medication.Name} - Dosis: {med.Dose}");
                else if (item is ProcedureOrderItem proc) items.Add($"Item {item.ItemNumber}: {proc.Procedure.Name} - Frecuencia: {proc.Frequency}");
                else if (item is DiagnosticAidOrderItem diag) items.Add($"Item {item.ItemNumber}: {diag.DiagnosticAid.Name} - Cantidad: {diag.Quantity}");
            }
            lstOrderItems.Items.Clear();
            lstOrderItems.Items.AddRange(items.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedPatient == null)
            {
                MessageBox.Show("Por favor seleccione un paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConsultationReason.Text) || string.IsNullOrWhiteSpace(txtSymptoms.Text) || string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Por favor complete motivo de consulta, sintomatología y diagnóstico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Program.Config.DoctorConfig.DoctorUseCase.SetCurrentUser(currentUser);
                doctorInputs.CreateMedicalRecord(dtpRecordDate.Value, selectedPatient, txtConsultationReason.Text.Trim(), txtSymptoms.Text.Trim(), txtDiagnosis.Text.Trim(), currentOrder);
                MessageBox.Show("Registro médico creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

