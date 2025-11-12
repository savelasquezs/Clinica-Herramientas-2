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
<<<<<<< HEAD
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
=======
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSelectPatient = new System.Windows.Forms.Button();
            this.btnRegisterVisit = new System.Windows.Forms.Button();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnViewOrders);
            this.pnlSidebar.Controls.Add(this.btnRegisterVisit);
            this.pnlSidebar.Controls.Add(this.btnSelectPatient);
            this.pnlSidebar.Controls.Add(this.lblUserName);
            this.pnlSidebar.Controls.Add(this.lblRole);
            this.pnlSidebar.Controls.Add(this.lblWelcome);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 650);
            this.pnlSidebar.TabIndex = 0;
            
            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(950, 650);
            this.pnlContent.TabIndex = 1;
            
            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(10, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Bienvenida, Usuario";
            
            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(10, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(120, 17);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Rol: Enfermera";
            
            // lblUserName
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(10, 75);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 15);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Usuario: Nombre";
            
            // btnSelectPatient
            this.btnSelectPatient.BackColor = System.Drawing.Color.White;
            this.btnSelectPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelectPatient.Location = new System.Drawing.Point(10, 120);
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.Size = new System.Drawing.Size(230, 50);
            this.btnSelectPatient.TabIndex = 3;
            this.btnSelectPatient.Text = "Seleccionar Paciente";
            this.btnSelectPatient.UseVisualStyleBackColor = false;
            this.btnSelectPatient.Click += new System.EventHandler(this.btnSelectPatient_Click);
            
            // btnRegisterVisit
            this.btnRegisterVisit.BackColor = System.Drawing.Color.White;
            this.btnRegisterVisit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterVisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegisterVisit.Location = new System.Drawing.Point(10, 180);
            this.btnRegisterVisit.Name = "btnRegisterVisit";
            this.btnRegisterVisit.Size = new System.Drawing.Size(230, 50);
            this.btnRegisterVisit.TabIndex = 4;
            this.btnRegisterVisit.Text = "Registrar Visita";
            this.btnRegisterVisit.UseVisualStyleBackColor = false;
            this.btnRegisterVisit.Click += new System.EventHandler(this.btnRegisterVisit_Click);
            
            // btnViewOrders
            this.btnViewOrders.BackColor = System.Drawing.Color.White;
            this.btnViewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewOrders.Location = new System.Drawing.Point(10, 240);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(230, 50);
            this.btnViewOrders.TabIndex = 5;
            this.btnViewOrders.Text = "Ver Órdenes del Paciente";
            this.btnViewOrders.UseVisualStyleBackColor = false;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            
            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(10, 600);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(230, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            
            // NurseMainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.Name = "NurseMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Enfermera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
>>>>>>> temp-salvado
        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnSelectPatient;
        private System.Windows.Forms.Button btnRegisterVisit;
        private System.Windows.Forms.Button btnViewOrders;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewPatients;
        private System.Windows.Forms.Button btnRegisterPatient;
        private System.Windows.Forms.Button btnMedicalRecords;
        private Panel panel1;
    }
}
