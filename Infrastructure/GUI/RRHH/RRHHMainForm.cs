using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;

namespace Clinica_Herramientas_2.Infrastructure.GUI.RRHH
{
    public partial class RRHHMainForm : Form
    {
        private readonly User currentUser;

        public RRHHMainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblRole.Text = "Rol: Recursos Humanos";
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
