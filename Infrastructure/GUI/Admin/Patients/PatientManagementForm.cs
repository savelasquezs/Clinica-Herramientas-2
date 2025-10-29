using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Patients
{
    public partial class PatientManagementForm : Form
    {
        private readonly User currentUser;
        private readonly AdminConfig adminConfig;
        private List<Patient> patients = new List<Patient>();

        public PatientManagementForm(User currentUser, AdminConfig adminConfig)
        {
            this.currentUser = currentUser;
            this.adminConfig = adminConfig;
            InitializeComponent();
            SetupDataGridView();
            LoadPatients();
        }

        private void SetupDataGridView()
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.Columns.Clear();

            // Configurar estilos
            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(37, 99, 235),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold)
            };
            dgvPatients.ColumnHeadersDefaultCellStyle = headerStyle;

            var alternatingRowStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
            };
            dgvPatients.AlternatingRowsDefaultCellStyle = alternatingRowStyle;

            // Agregar columnas
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "Dni",
                Width = 150
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullname",
                HeaderText = "Nombre Completo",
                DataPropertyName = "Fullname",
                Width = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 200
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "Teléfono",
                DataPropertyName = "Phonenumber",
                Width = 150
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGender",
                HeaderText = "Género",
                DataPropertyName = "Gender",
                Width = 100
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBirthdate",
                HeaderText = "Fecha Nacimiento",
                DataPropertyName = "Birthdate",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void LoadPatients()
        {
            try
            {
                patients = adminConfig.ViewPatientInformationService.GetAllPatients();
                dgvPatients.DataSource = null;
                dgvPatients.DataSource = patients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var filteredPatients = patients.Where(p =>
                p.Dni.ToLower().Contains(searchTerm) ||
                p.Fullname.ToLower().Contains(searchTerm) ||
                p.Email.ToLower().Contains(searchTerm)
            ).ToList();

            dgvPatients.DataSource = null;
            dgvPatients.DataSource = filteredPatients;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de crear paciente - Próximamente", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implementar PatientCreateForm
            // var createForm = new PatientCreateForm(adminConfig);
            // if (createForm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadPatients();
            //     MessageBox.Show("Paciente creado exitosamente", "Éxito", 
            //         MessageBoxButtons.OK, MessageBoxIcon.Information);
            // }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un paciente para editar", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Funcionalidad de editar paciente - Próximamente", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implementar PatientEditForm
            // var selectedPatient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;
            // var editForm = new PatientEditForm(selectedPatient, adminConfig);
            // if (editForm.ShowDialog() == DialogResult.OK)
            // {
            //     LoadPatients();
            //     MessageBox.Show("Paciente actualizado exitosamente", "Éxito", 
            //         MessageBoxButtons.OK, MessageBoxIcon.Information);
            // }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPatients();
            txtSearch.Clear();
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
