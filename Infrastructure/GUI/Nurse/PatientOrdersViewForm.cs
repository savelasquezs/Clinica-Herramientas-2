using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class PatientOrdersViewForm : Form
    {
        private readonly NurseInputs nurseInputs;
        private readonly User currentUser;
        private Patient? selectedPatient;
        private List<Order> orders = new List<Order>();

        public PatientOrdersViewForm(NurseInputs nurseInputs, User currentUser)
        {
            this.nurseInputs = nurseInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.Columns.Clear();
            var headerStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(236, 72, 153), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold) };
            dgvOrders.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvOrders.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(253, 242, 248) };
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "colOrderNumber", HeaderText = "Número", DataPropertyName = "OrderNumber", Width = 100 });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreationDate", HeaderText = "Fecha Creación", DataPropertyName = "CreationDate", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn { Name = "colItemCount", HeaderText = "Items", DataPropertyName = "ItemCount", Width = 80 });
        }

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientSelectionForm(nurseInputs, currentUser);
            if (patientForm.ShowDialog() == DialogResult.OK && patientForm.SelectedPatient != null)
            {
                selectedPatient = patientForm.SelectedPatient;
                lblPatientInfo.Text = $"Paciente: {selectedPatient.Fullname} - DNI: {selectedPatient.Dni}";
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            if (selectedPatient == null) return;
            try
            {
                Program.Config.NurseConfig.NurseUseCase.SetCurrentUser(currentUser);
                orders = nurseInputs.GetPatientOrders(selectedPatient.Dni);
                var orderData = orders.Select(o => new
                {
                    o.OrderNumber,
                    o.CreationDate,
                    ItemCount = o.Items.Count
                }).ToList();
                dgvOrders.DataSource = null;
                dgvOrders.DataSource = orderData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar órdenes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una orden para ver detalles", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var orderNumber = (int)dgvOrders.SelectedRows[0].Cells["colOrderNumber"].Value;
            var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order == null) return;

            var details = new StringBuilder();
            details.AppendLine($"Orden #{order.OrderNumber}");
            details.AppendLine($"Fecha: {order.CreationDate:dd/MM/yyyy HH:mm}");
            details.AppendLine("\nItems:");
            foreach (var item in order.Items)
            {
                if (item is MedicationOrderItem med)
                    details.AppendLine($"  - Medicamento: {med.Medication.Name}, Dosis: {med.Dose}, Duración: {med.TreatmentDuration} días, Costo: ${med.Cost:N2}");
                else if (item is ProcedureOrderItem proc)
                    details.AppendLine($"  - Procedimiento: {proc.Procedure.Name}, Frecuencia: {proc.Frequency}, Costo: ${proc.Cost:N2}");
                else if (item is DiagnosticAidOrderItem diag)
                    details.AppendLine($"  - Ayuda Diagnóstica: {diag.DiagnosticAid.Name}, Cantidad: {diag.Quantity}, Costo: ${diag.Cost:N2}");
            }
            MessageBox.Show(details.ToString(), "Detalles de la Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

