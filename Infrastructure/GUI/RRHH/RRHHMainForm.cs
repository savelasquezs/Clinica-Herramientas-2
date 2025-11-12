using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;
using Clinica_Herramientas_2.Infrastructure.Config;
using Clinica_Herramientas_2.Infrastructure.GUI.RRHH.Users;
using Clinica_Herramientas_2.Application.Adapters.Input;

namespace Clinica_Herramientas_2.Infrastructure.GUI.RRHH
{
    public partial class RRHHMainForm : Form
    {
        private readonly User currentUser;
        private readonly RRHHInputs rrhhInputs;
        private Form? currentChildForm;

        public RRHHMainForm(RRHHInputs rrhhInputs, User user)
        {
            this.currentUser = user;
            this.rrhhInputs = rrhhInputs;
            InitializeComponent();
            LoadUserInfo();
            // Establecer el usuario actual en el use case
            rrhhInputs.SetCurrentUser(user);
        }

        private void LoadUserInfo()
        {
            lblRole.Text = "Rol: Recursos Humanos";
            lblUserName.Text = $"Usuario: {currentUser.Fullname}";
            lblWelcome.Text = $"Bienvenido, {currentUser.Fullname}";
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var userForm = new UserManagementForm(rrhhInputs, currentUser);
            OpenChildForm(userForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                var loginForm = new LoginForm(Program.Config);
                loginForm.Show();
                this.Close();
            }
        }
    }
}
