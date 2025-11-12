using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;
using Clinica_Herramientas_2.Infrastructure.GUI.Doctor;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Doctor
{
    public partial class DoctorMainForm : Form
    {
        private readonly User currentUser;
        private Form? currentChildForm;

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
            var patientForm = new PatientSelectionForm(Program.Config.DoctorConfig.DoctorInputs, currentUser);
            OpenChildForm(patientForm);
        }

        private void btnMedicalHistory_Click(object sender, EventArgs e)
        {
            var historyForm = new MedicalHistoryForm(Program.Config.DoctorConfig.DoctorInputs, currentUser);
            OpenChildForm(historyForm);
        }

        private void btnCreateRecord_Click(object sender, EventArgs e)
        {
            var recordForm = new MedicalRecordForm(Program.Config.DoctorConfig.DoctorInputs, currentUser);
            OpenChildForm(recordForm);
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
