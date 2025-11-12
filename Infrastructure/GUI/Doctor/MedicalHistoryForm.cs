using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Doctor
{
    public partial class MedicalHistoryForm : Form
    {
        private readonly DoctorInputs doctorInputs;
        private readonly User currentUser;
        private Patient? selectedPatient;
        private List<MedicalRecord> medicalRecords = new List<MedicalRecord>();

        public MedicalHistoryForm(DoctorInputs doctorInputs, User currentUser)
        {
            this.doctorInputs = doctorInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();
            var headerStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(5, 150, 105), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold) };
            dgvHistory.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvHistory.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(240, 253, 244) };
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Fecha", DataPropertyName = "Date", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colReason", HeaderText = "Motivo", DataPropertyName = "ConsultationReason", Width = 200, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDiagnosis", HeaderText = "Diagnóstico", DataPropertyName = "Diagnosis", Width = 250 });
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientSelectionForm(doctorInputs, currentUser);
            if (patientForm.ShowDialog() == DialogResult.OK && patientForm.SelectedPatient != null)
            {
                selectedPatient = patientForm.SelectedPatient;
                lblPatientInfo.Text = $"Paciente: {selectedPatient.Fullname} - DNI: {selectedPatient.Dni}";
                LoadMedicalHistory();
            }
        }

        private void LoadMedicalHistory()
        {
            if (selectedPatient == null) return;
            try
            {
                medicalRecords = doctorInputs.GetMedicalHistory(selectedPatient.Dni);
                dgvHistory.DataSource = null;
                dgvHistory.DataSource = medicalRecords.OrderByDescending(m => m.Date).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un registro para ver detalles", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var record = (MedicalRecord)dgvHistory.SelectedRows[0].DataBoundItem;
            var details = new StringBuilder();
            details.AppendLine($"Fecha: {record.Date:dd/MM/yyyy HH:mm}");
            details.AppendLine($"Motivo: {record.ConsultationReason}");
            details.AppendLine($"Sintomatología: {record.Symptoms}");
            details.AppendLine($"Diagnóstico: {record.Diagnosis}");
            if (record.Order != null)
            {
                details.AppendLine($"\nOrden #{record.Order.OrderNumber}");
                foreach (var item in record.Order.Items)
                {
                    if (item is MedicationOrderItem med) details.AppendLine($"  - Medicamento: {med.Medication.Name}, Dosis: {med.Dose}");
                    else if (item is ProcedureOrderItem proc) details.AppendLine($"  - Procedimiento: {proc.Procedure.Name}");
                    else if (item is DiagnosticAidOrderItem diag) details.AppendLine($"  - Ayuda Diagnóstica: {diag.DiagnosticAid.Name}");
                }
            }
            MessageBox.Show(details.ToString(), "Detalles del Registro Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

