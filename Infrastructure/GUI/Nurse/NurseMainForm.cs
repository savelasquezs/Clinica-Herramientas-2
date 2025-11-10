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
            var result = MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var loginForm = new LoginForm(Program.Config);
                loginForm.Show();
                this.Close();
            }
        }

        private void btnViewPatients_Click(object sender, EventArgs e)
        {
            // Abre la ventana creada `PatientViewForm`
            var form = new PatientViewForm();
            form.ShowDialog(this);
        }

        private void btnRegisterPatient_Click(object sender, EventArgs e)
        {
            // Abre la ventana creada `PatientRegisterForm`
            var form = new PatientRegisterForm();
            form.ShowDialog(this);
        }

        private void btnMedicalRecords_Click(object sender, EventArgs e)
        {
            // Abre la ventana creada `MedicalRegisterForm`
            var form = new MedicalRegisterForm();
            form.ShowDialog(this);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
