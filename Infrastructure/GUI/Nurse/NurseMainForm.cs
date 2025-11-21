using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class NurseMainForm : Form
    {
        private readonly User currentUser;
        private Form? currentChildForm;

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

        private void btnSelectPatient_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientSelectionForm(Program.Config.NurseConfig.NurseInputs, currentUser);
            OpenChildForm(patientForm);
        }

        private void btnRegisterVisit_Click(object sender, EventArgs e)
        {
            var visitForm = new NurseVisitForm(Program.Config.NurseConfig.NurseInputs, currentUser);
            OpenChildForm(visitForm);
        }

        private void btnViewOrders_Click(object sender, EventArgs e)
        {
            var ordersForm = new PatientOrdersViewForm(Program.Config.NurseConfig.NurseInputs, currentUser);
            OpenChildForm(ordersForm);
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
