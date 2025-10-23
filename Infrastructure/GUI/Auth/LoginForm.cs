using Clinica_Herramientas_2.Infrastructure.Config;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Admin;
using Clinica_Herramientas_2.Infrastructure.GUI.Doctor;
using Clinica_Herramientas_2.Infrastructure.GUI.Nurse;
using Clinica_Herramientas_2.Infrastructure.GUI.RRHH;
using Clinica_Herramientas_2.Infrastructure.GUI.Support;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Auth
{
    public partial class LoginForm : Form
    {
        private readonly Clinica_Herramientas_2.Infrastructure.Config.Config config;
        
        public LoginForm(Clinica_Herramientas_2.Infrastructure.Config.Config config)
        {
            this.config = config;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Por favor ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = config.AuthConfig.AuthenticateUserService.Authenticate(username, password);

                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir formulario según el rol del usuario
                Form roleForm = user.Role switch
                {
                    Role.Admin => new AdminMainForm(user),
                    Role.Doctor => new DoctorMainForm(user),
                    Role.Nurse => new NurseMainForm(user),
                    Role.RRHH => new RRHHMainForm(user),
                    Role.Support => new SupportMainForm(user),
                    _ => throw new Exception("Rol no válido")
                };

                roleForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
