using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Patients
{
    public partial class PatientCreateForm : Form
    {
        private readonly AdminConfig adminConfig;
        private readonly User currentUser;

        public PatientCreateForm(AdminConfig adminConfig, User currentUser)
        {
            this.adminConfig = adminConfig;
            this.currentUser = currentUser;
            InitializeComponent();
            LoadGenderOptions();
        }

        private void LoadGenderOptions()
        {
            cmbGender.Items.AddRange(new[] { "Masculino", "Femenino", "Otro" });
            cmbGender.SelectedIndex = 0;
        }

        private Gender GetSelectedGender()
        {
            return cmbGender.SelectedItem?.ToString() switch
            {
                "Masculino" => Gender.Male,
                "Femenino" => Gender.Female,
                "Otro" => Gender.Other,
                _ => Gender.Male
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhonenumber.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtEmergencyFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmergencyLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmergencyRelationship.Text) ||
                    string.IsNullOrWhiteSpace(txtEmergencyPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtInsuranceCompany.Text) ||
                    string.IsNullOrWhiteSpace(txtInsurancePolicy.Text))
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

                // Validar teléfono de emergencia (10 dígitos)
                if (txtEmergencyPhone.Text.Length != 10 || !txtEmergencyPhone.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El teléfono de emergencia debe contener exactamente 10 dígitos", "Error de validación", 
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

                // Validar fecha de nacimiento (máximo 150 años)
                var birthdate = DateOnly.FromDateTime(dtpBirthdate.Value);
                var age = DateTime.Now.Year - birthdate.Year;
                if (DateTime.Now.DayOfYear < birthdate.DayOfYear) age--;
                if (age > 150)
                {
                    MessageBox.Show("La edad no puede ser mayor a 150 años", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var gender = GetSelectedGender();
                var insuranceExpirationDate = dtpInsuranceExpiration.Value;
                var insuranceIsActive = chkInsuranceActive.Checked;

                // Establecer el usuario actual antes de crear
                adminConfig.AdminUseCase.SetCurrentUser(currentUser);

                // Crear el nuevo paciente
                adminConfig.AdminInputs.CreatePatient(
                    txtFullname.Text.Trim(),
                    txtDni.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhonenumber.Text.Trim(),
                    birthdate,
                    txtAddress.Text.Trim(),
                    gender,
                    txtEmergencyFirstName.Text.Trim(),
                    txtEmergencyLastName.Text.Trim(),
                    txtEmergencyRelationship.Text.Trim(),
                    txtEmergencyPhone.Text.Trim(),
                    txtInsuranceCompany.Text.Trim(),
                    txtInsurancePolicy.Text.Trim(),
                    insuranceIsActive,
                    insuranceExpirationDate
                );

                MessageBox.Show("Paciente creado exitosamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear paciente: {ex.Message}", "Error", 
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

