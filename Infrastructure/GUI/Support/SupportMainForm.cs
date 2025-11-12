using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class SupportMainForm : Form
    {
        private readonly User currentUser;
        private Form? currentChildForm;

        public SupportMainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblRole.Text = "Rol: Soporte Técnico";
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

        private void btnMedications_Click(object sender, EventArgs e)
        {
            var medicationForm = new MedicationManagementForm(Program.Config.SupportConfig.SupportInputs, currentUser);
            OpenChildForm(medicationForm);
        }

        private void btnProcedures_Click(object sender, EventArgs e)
        {
            var procedureForm = new ProcedureManagementForm(Program.Config.SupportConfig.SupportInputs, currentUser);
            OpenChildForm(procedureForm);
        }

        private void btnDiagnosticAids_Click(object sender, EventArgs e)
        {
            var diagnosticForm = new DiagnosticAidManagementForm(Program.Config.SupportConfig.SupportInputs, currentUser);
            OpenChildForm(diagnosticForm);
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
