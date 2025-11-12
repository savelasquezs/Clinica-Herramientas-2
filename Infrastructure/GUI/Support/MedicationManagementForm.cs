using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class MedicationManagementForm : Form
    {
        private readonly SupportInputs supportInputs;
        private readonly User currentUser;
        private List<Medication> medications = new List<Medication>();

        public MedicationManagementForm(SupportInputs supportInputs, User currentUser)
        {
            this.supportInputs = supportInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
            LoadMedications();
        }

        private void SetupDataGridView()
        {
            dgvMedications.AutoGenerateColumns = false;
            dgvMedications.Columns.Clear();

            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(234, 88, 12),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold)
            };
            dgvMedications.ColumnHeadersDefaultCellStyle = headerStyle;

            var alternatingRowStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(255, 247, 237)
            };
            dgvMedications.AlternatingRowsDefaultCellStyle = alternatingRowStyle;

            dgvMedications.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", DataPropertyName = "Id", Width = 80 });
            dgvMedications.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Nombre", DataPropertyName = "Name", Width = 300, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvMedications.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCost", HeaderText = "Costo", DataPropertyName = "Cost", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvMedications.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDose", HeaderText = "Dosis", DataPropertyName = "Dose", Width = 150 });
            dgvMedications.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDuration", HeaderText = "Duración (días)", DataPropertyName = "TreatmentDuration", Width = 120 });
        }

        private void LoadMedications()
        {
            try
            {
                medications = supportInputs.GetAllMedications();
                dgvMedications.DataSource = null;
                dgvMedications.DataSource = medications;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar medicamentos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var createForm = new MedicationForm(supportInputs, null);
            if (createForm.ShowDialog() == DialogResult.OK)
            {
                LoadMedications();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMedications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un medicamento para editar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedMedication = (Medication)dgvMedications.SelectedRows[0].DataBoundItem;
            var editForm = new MedicationForm(supportInputs, selectedMedication);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadMedications();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMedications();
        }
    }
}

