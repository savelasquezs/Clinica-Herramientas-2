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
    }
}
