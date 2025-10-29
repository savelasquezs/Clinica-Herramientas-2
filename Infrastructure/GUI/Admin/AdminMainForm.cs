using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.GUI.Auth;
using Clinica_Herramientas_2.Infrastructure.GUI.Admin.Patients;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin
{
    public partial class AdminMainForm : Form
    {
        private readonly User currentUser;
        private Form? currentChildForm;

        public AdminMainForm(User user)
        {
            this.currentUser = user;
            InitializeComponent();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            lblRole.Text = "Rol: Administrador";
            lblUserName.Text = $"Usuario: {currentUser.Fullname}";
            lblWelcome.Text = $"Bienvenido, {currentUser.Fullname}";
        }

        private void OpenChildForm(Form childForm)
        {
            // Cerrar el formulario actual si existe
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

        private void btnPatients_Click(object sender, EventArgs e)
        {
            var patientForm = new PatientManagementForm(currentUser, Program.Config.AdminConfig);
            OpenChildForm(patientForm);
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de citas médicas - Próximamente", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implementar AppointmentManagementForm
            // var appointmentForm = new AppointmentManagementForm(currentUser, Program.Config.AdminConfig);
            // OpenChildForm(appointmentForm);
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de facturación - Próximamente", "Información", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Implementar InvoiceManagementForm
            // var invoiceForm = new InvoiceManagementForm(currentUser, Program.Config.AdminConfig);
            // OpenChildForm(invoiceForm);
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
