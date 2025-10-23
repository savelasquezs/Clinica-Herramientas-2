using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class NurseMainForm : Form
    {
        private readonly User currentUser;

        public NurseMainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblRole.Text = "Rol: Enfermera";
            lblUserName.Text = $"Usuario: {currentUser.Fullname}";
            lblWelcome.Text = $"Bienvenida, {currentUser.Fullname}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(Program.Config);
            loginForm.Show();
            this.Close();
        }
    }
}
