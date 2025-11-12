using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class NurseVisitForm : Form
    {
        private readonly NurseInputs nurseInputs;
        private readonly User currentUser;
        private Patient? selectedPatient;
        private OrderItem? selectedOrderItem;
        private List<Order> patientOrders = new List<Order>();
        private List<AdministeredMedication> administeredMedications = new List<AdministeredMedication>();

        public NurseVisitForm(NurseInputs nurseInputs, User currentUser)
        {
            this.nurseInputs = nurseInputs;
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientSelectionForm(nurseInputs, currentUser);
            if (patientForm.ShowDialog() == DialogResult.OK && patientForm.SelectedPatient != null)
            {
                selectedPatient = patientForm.SelectedPatient;
                lblPatientInfo.Text = $"Paciente: {selectedPatient.Fullname} - DNI: {selectedPatient.Dni}";
                LoadPatientOrders();
            }
        }

        private void LoadPatientOrders()
        {
            if (selectedPatient == null) return;
            try
            {
                Program.Config.NurseConfig.NurseUseCase.SetCurrentUser(currentUser);
                patientOrders = nurseInputs.GetPatientOrders(selectedPatient.Dni);
                cmbOrderItem.Items.Clear();
                foreach (var order in patientOrders)
                {
                    foreach (var item in order.Items)
                    {
                        if (item is MedicationOrderItem med)
                            cmbOrderItem.Items.Add($"Orden #{order.OrderNumber} - Item {item.ItemNumber}: {med.Medication.Name}");
                        else if (item is ProcedureOrderItem proc)
                            cmbOrderItem.Items.Add($"Orden #{order.OrderNumber} - Item {item.ItemNumber}: {proc.Procedure.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderItem.SelectedIndex == -1) return;
            var selectedText = cmbOrderItem.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedText)) return;
            var orderNum = int.Parse(selectedText.Split('#')[1].Split('-')[0].Trim());
            var itemNum = int.Parse(selectedText.Split("Item ")[1].Split(':')[0].Trim());
            var order = patientOrders.First(o => o.OrderNumber == orderNum);
            selectedOrderItem = order.Items.First(i => i.ItemNumber == itemNum);
        }

        private void btnAddMedication_Click(object sender, EventArgs e)
        {
            if (selectedOrderItem == null || !(selectedOrderItem is MedicationOrderItem))
            {
                MessageBox.Show("Por favor seleccione un item de medicamento de la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDose.Text) || string.IsNullOrWhiteSpace(txtRoute.Text))
            {
                MessageBox.Show("Por favor complete dosis y vía de administración", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var medItem = (MedicationOrderItem)selectedOrderItem;
                var adminMed = new AdministeredMedication(selectedOrderItem, txtTestsPerformed.Text.Trim(), txtNotes.Text.Trim(), dtpPerformedAt.Value, medItem.Medication, txtDose.Text.Trim(), txtRoute.Text.Trim());
                administeredMedications.Add(adminMed);
                lstMedications.Items.Add($"{medItem.Medication.Name} - {txtDose.Text} - {txtRoute.Text}");
                MessageBox.Show("Medicamento agregado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedPatient == null || selectedOrderItem == null)
            {
                MessageBox.Show("Por favor seleccione un paciente y un item de orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBloodPressure.Text) || string.IsNullOrWhiteSpace(txtTemperature.Text) ||
                string.IsNullOrWhiteSpace(txtPulse.Text) || string.IsNullOrWhiteSpace(txtOxygenLevel.Text))
            {
                MessageBox.Show("Por favor complete todos los signos vitales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtTemperature.Text, out double temperature) ||
                !int.TryParse(txtPulse.Text, out int pulse) ||
                !int.TryParse(txtOxygenLevel.Text, out int oxygenLevel))
            {
                MessageBox.Show("Por favor ingrese valores numéricos válidos para temperatura, pulso y oxígeno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Program.Config.NurseConfig.NurseUseCase.SetCurrentUser(currentUser);
                nurseInputs.CreateNurseVisit(selectedOrderItem, txtTestsPerformed.Text.Trim(), txtNotes.Text.Trim(), dtpPerformedAt.Value, txtBloodPressure.Text.Trim(), temperature, pulse, oxygenLevel, administeredMedications, dtpVisitTime.Value, selectedPatient);
                MessageBox.Show("Visita de enfermería registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

