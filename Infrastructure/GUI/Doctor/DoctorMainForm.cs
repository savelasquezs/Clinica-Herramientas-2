using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Doctor
{
    public partial class DoctorMainForm : Form
    {
        private readonly User currentUser;

        public DoctorMainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblRole.Text = "Rol: Doctor";
            lblUserName.Text = $"Usuario: {currentUser.Fullname}";
            lblWelcome.Text = $"Bienvenido, {currentUser.Fullname}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(Program.Config);
            loginForm.Show();
            this.Close();
        }
    }
}
