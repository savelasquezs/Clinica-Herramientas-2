using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Appointments
{
    public partial class AppointmentManagementForm : Form
    {
        private readonly AdminConfig adminConfig;
        private readonly User currentUser;
        private List<Appointment> appointments = new List<Appointment>();
        private List<Patient> patients = new List<Patient>();

        public AppointmentManagementForm(AdminConfig adminConfig, User currentUser)
        {
            this.adminConfig = adminConfig;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
            LoadAppointments();
            LoadPatients();
        }

        private void SetupDataGridView()
        {
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.Columns.Clear();

            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(37, 99, 235),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold)
            };
            dgvAppointments.ColumnHeadersDefaultCellStyle = headerStyle;

            var alternatingRowStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
            };
            dgvAppointments.AlternatingRowsDefaultCellStyle = alternatingRowStyle;

            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "Id1",
                Width = 80
            });

            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPatientDni",
                HeaderText = "DNI Paciente",
                DataPropertyName = "PatientDni",
                Width = 150
            });

            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPatientName",
                HeaderText = "Nombre Paciente",
                DataPropertyName = "PatientName",
                Width = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAppointments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Fecha",
                DataPropertyName = "Date1",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });
        }

        private void LoadAppointments()
        {
            try
            {
                var allPatients = adminConfig.ViewPatientInformationService.GetAllPatients();
                appointments = new List<Appointment>();
                
                foreach (var patient in allPatients)
                {
                    var patientAppointments = adminConfig.ViewPatientInformationService.GetPatientAppointments(patient.Dni);
                    appointments.AddRange(patientAppointments);
                }

                var appointmentData = appointments.Select(a => new
                {
                    a.Id1,
                    PatientDni = a.Patient1.Dni,
                    PatientName = a.Patient1.Fullname,
                    a.Date1
                }).ToList();

                dgvAppointments.DataSource = null;
                dgvAppointments.DataSource = appointmentData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar citas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatients()
        {
            try
            {
                patients = adminConfig.ViewPatientInformationService.GetAllPatients();
                cmbPatient.Items.Clear();
                foreach (var patient in patients)
                {
                    cmbPatient.Items.Add($"{patient.Dni} - {patient.Fullname}");
                }
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
                LoadAppointments();
                return;
            }

            var filtered = appointments.Where(a =>
                a.Patient1.Dni.ToLower().Contains(searchTerm) ||
                a.Patient1.Fullname.ToLower().Contains(searchTerm)
            ).Select(a => new
            {
                a.Id1,
                PatientDni = a.Patient1.Dni,
                PatientName = a.Patient1.Fullname,
                a.Date1
            }).ToList();

            dgvAppointments.DataSource = null;
            dgvAppointments.DataSource = filtered;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAppointmentId.Text))
                {
                    MessageBox.Show("Por favor ingrese un ID para la cita", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtAppointmentId.Text, out int appointmentId))
                {
                    MessageBox.Show("El ID debe ser un número válido", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbPatient.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor seleccione un paciente", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedPatientText = cmbPatient.SelectedItem?.ToString() ?? string.Empty;
                if (string.IsNullOrEmpty(selectedPatientText))
                {
                    MessageBox.Show("Por favor seleccione un paciente válido", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var patientDni = selectedPatientText.Split('-')[0].Trim();
                var appointmentDate = dtpAppointmentDate.Value;

                // Establecer el usuario actual antes de crear
                adminConfig.AdminUseCase.SetCurrentUser(currentUser);

                adminConfig.AdminInputs.CreateAppointment(appointmentId, patientDni, appointmentDate);

                MessageBox.Show("Cita creada exitosamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadAppointments();
                txtAppointmentId.Clear();
                cmbPatient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear cita: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
            txtSearch.Clear();
        }
    }
}

