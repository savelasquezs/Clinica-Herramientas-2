using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Patients
{
    public partial class PatientEditForm : Form
    {
        private readonly AdminConfig adminConfig;
        private readonly Patient patient;
        private readonly User currentUser;

        public PatientEditForm(Patient patient, AdminConfig adminConfig, User currentUser)
        {
            this.patient = patient;
            this.adminConfig = adminConfig;
            this.currentUser = currentUser;
            InitializeComponent();
            LoadPatientData();
        }

        private void LoadPatientData()
        {
            // Información de solo lectura
            txtDni.Text = patient.Dni;
            txtDni.ReadOnly = true;
            txtDni.BackColor = System.Drawing.Color.LightGray;
            
            txtFullname.Text = patient.Fullname;
            txtFullname.ReadOnly = true;
            txtFullname.BackColor = System.Drawing.Color.LightGray;
            
            dtpBirthdate.Value = new DateTime(patient.Birthdate.Year, patient.Birthdate.Month, patient.Birthdate.Day);
            dtpBirthdate.Enabled = false;
            
            // Información editable
            txtEmail.Text = patient.Email;
            txtPhonenumber.Text = patient.Phonenumber;
            txtAddress.Text = patient.Address;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhonenumber.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos requeridos", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar formato de email
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Por favor ingrese un email válido", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar teléfono (10 dígitos)
                if (txtPhonenumber.Text.Length != 10 || !txtPhonenumber.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El teléfono debe contener exactamente 10 dígitos", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar dirección (máximo 30 caracteres)
                if (txtAddress.Text.Length > 30)
                {
                    MessageBox.Show("La dirección no puede tener más de 30 caracteres", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Establecer el usuario actual antes de actualizar
                adminConfig.AdminUseCase.SetCurrentUser(currentUser);

                // Actualizar el paciente
                adminConfig.AdminInputs.UpdatePatient(
                    patient,
                    txtEmail.Text.Trim(),
                    txtPhonenumber.Text.Trim(),
                    txtAddress.Text.Trim()
                );

                MessageBox.Show("Paciente actualizado exitosamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar paciente: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

