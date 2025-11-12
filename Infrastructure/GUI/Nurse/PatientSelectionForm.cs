using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class PatientSelectionForm : Form
    {
        private readonly NurseInputs nurseInputs;
        private readonly User currentUser;
        private List<Patient> patients = new List<Patient>();
        public Patient? SelectedPatient { get; private set; }

        public PatientSelectionForm(NurseInputs nurseInputs, User currentUser)
        {
            this.nurseInputs = nurseInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
            LoadPatients();
        }

        private void SetupDataGridView()
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.Columns.Clear();
            var headerStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(236, 72, 153), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold) };
            dgvPatients.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvPatients.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(253, 242, 248) };
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDni", HeaderText = "DNI", DataPropertyName = "Dni", Width = 150 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFullname", HeaderText = "Nombre Completo", DataPropertyName = "Fullname", Width = 300, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email", DataPropertyName = "Email", Width = 200 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBirthdate", HeaderText = "Fecha Nacimiento", DataPropertyName = "Birthdate", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        }

        private void LoadPatients()
        {
            try
            {
                Program.Config.NurseConfig.NurseUseCase.SetCurrentUser(currentUser);
                patients = Program.Config.NurseConfig.NurseUseCase.GetAllPatients();
                dgvPatients.DataSource = null;
                dgvPatients.DataSource = patients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadPatients();
                return;
            }
            var filtered = patients.Where(p => p.Dni.ToLower().Contains(searchTerm) || p.Fullname.ToLower().Contains(searchTerm)).ToList();
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = filtered;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un paciente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SelectedPatient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnSelect_Click(sender, e);
        }
    }
}

