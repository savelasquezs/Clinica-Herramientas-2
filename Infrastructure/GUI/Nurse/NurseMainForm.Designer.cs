namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    partial class NurseMainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblRole = new Label();
            lblUserName = new Label();
            btnLogout = new Button();
            btnViewPatients = new Button();
            btnRegisterPatient = new Button();
            btnMedicalRecords = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblWelcome.Location = new Point(76, 80);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(197, 24);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bienvenida, Usuario";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Microsoft Sans Serif", 12F);
            lblRole.Location = new Point(76, 130);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(116, 20);
            lblRole.TabIndex = 1;
            lblRole.Text = "Rol: Enfermera";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Microsoft Sans Serif", 12F);
            lblUserName.Location = new Point(76, 160);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(128, 20);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Usuario: Nombre";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(156, 507);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Cerrar Sesión";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnViewPatients
            // 
            btnViewPatients.Location = new Point(122, 338);
            btnViewPatients.Name = "btnViewPatients";
            btnViewPatients.Size = new Size(180, 36);
            btnViewPatients.TabIndex = 3;
            btnViewPatients.Text = "Visualizar Pacientes";
            btnViewPatients.UseVisualStyleBackColor = true;
            btnViewPatients.Click += btnViewPatients_Click;
            // 
            // btnRegisterPatient
            // 
            btnRegisterPatient.Location = new Point(122, 262);
            btnRegisterPatient.Name = "btnRegisterPatient";
            btnRegisterPatient.Size = new Size(180, 36);
            btnRegisterPatient.TabIndex = 4;
            btnRegisterPatient.Text = "Registrar Pacientes";
            btnRegisterPatient.UseVisualStyleBackColor = true;
            btnRegisterPatient.Click += btnRegisterPatient_Click;
            // 
            // btnMedicalRecords
            // 
            btnMedicalRecords.Location = new Point(122, 425);
            btnMedicalRecords.Name = "btnMedicalRecords";
            btnMedicalRecords.Size = new Size(180, 36);
            btnMedicalRecords.TabIndex = 5;
            btnMedicalRecords.Text = "Registros Médicos";
            btnMedicalRecords.UseVisualStyleBackColor = true;
            btnMedicalRecords.Click += btnMedicalRecords_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(btnMedicalRecords);
            panel1.Controls.Add(lblWelcome);
            panel1.Controls.Add(btnRegisterPatient);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(btnViewPatients);
            panel1.Controls.Add(lblUserName);
            panel1.Controls.Add(btnLogout);
            panel1.Location = new Point(-16, -25);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 635);
            panel1.TabIndex = 7;
            // 
            // NurseMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 581);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NurseMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Enfermera";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewPatients;
        private System.Windows.Forms.Button btnRegisterPatient;
        private System.Windows.Forms.Button btnMedicalRecords;
        private Panel panel1;
    }
}
