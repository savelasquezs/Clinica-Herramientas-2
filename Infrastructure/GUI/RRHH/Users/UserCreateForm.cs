using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Application.Adapters.Input;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.RRHH.Users
{
    public partial class UserCreateForm : Form
    {
        private readonly RRHHInputs rrhhInputs;
        private readonly User currentUser;

        public UserCreateForm(RRHHInputs rrhhInputs, User currentUser)
        {
            this.rrhhInputs = rrhhInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            LoadRoles();
        }

        private void LoadRoles()
        {
            cmbRole.Items.AddRange(new[] { "Admin", "Doctor", "Nurse", "RRHH", "Support" });
            cmbRole.SelectedIndex = 0;
        }

        private Role GetSelectedRole()
        {
            return cmbRole.SelectedItem?.ToString() switch
            {
                "Admin" => Role.Admin,
                "Doctor" => Role.Doctor,
                "Nurse" => Role.Nurse,
                "RRHH" => Role.RRHH,
                "Support" => Role.Support,
                _ => Role.RRHH
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén completos
                if (string.IsNullOrWhiteSpace(txtFullname.Text) ||
                    string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhonenumber.Text) ||
                    string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos", "Error de validación", 
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

                // Verificar que el username no exista
                var existingUser = rrhhInputs.FindByUsername(txtUsername.Text);
                if (existingUser != null)
                {
                    MessageBox.Show("Este nombre de usuario ya existe. Por favor elija otro.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Establecer el usuario actual antes de crear
                rrhhInputs.SetCurrentUser(currentUser);
                
                // Crear el nuevo usuario
                var birthdate = DateOnly.FromDateTime(dtpBirthdate.Value);
                var role = GetSelectedRole();
                
                rrhhInputs.CreateUser(
                    txtFullname.Text,
                    txtDni.Text,
                    txtEmail.Text,
                    txtPhonenumber.Text,
                    birthdate,
                    txtAddress.Text,
                    role,
                    txtUsername.Text,
                    txtPassword.Text
                );

                MessageBox.Show("Usuario creado exitosamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", 
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

