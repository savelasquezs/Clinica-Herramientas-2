namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    partial class SupportMainForm
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
            this.btnMedications = new System.Windows.Forms.Button();
            this.btnProcedures = new System.Windows.Forms.Button();
            this.btnDiagnosticAids = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnDiagnosticAids);
            this.pnlSidebar.Controls.Add(this.btnProcedures);
            this.pnlSidebar.Controls.Add(this.btnMedications);
            this.pnlSidebar.Controls.Add(this.lblUserName);
            this.pnlSidebar.Controls.Add(this.lblRole);
            this.pnlSidebar.Controls.Add(this.lblWelcome);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 650);
            this.pnlSidebar.TabIndex = 0;
            
            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
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
            this.lblWelcome.Text = "Bienvenido, Usuario";
            
            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(10, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(160, 17);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Rol: Soporte Técnico";
            
            // lblUserName
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(10, 75);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(130, 15);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Usuario: Nombre";
            
            // btnMedications
            this.btnMedications.BackColor = System.Drawing.Color.White;
            this.btnMedications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedications.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMedications.Location = new System.Drawing.Point(10, 120);
            this.btnMedications.Name = "btnMedications";
            this.btnMedications.Size = new System.Drawing.Size(230, 50);
            this.btnMedications.TabIndex = 3;
            this.btnMedications.Text = "Gestión de Medicamentos";
            this.btnMedications.UseVisualStyleBackColor = false;
            this.btnMedications.Click += new System.EventHandler(this.btnMedications_Click);
            
            // btnProcedures
            this.btnProcedures.BackColor = System.Drawing.Color.White;
            this.btnProcedures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcedures.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProcedures.Location = new System.Drawing.Point(10, 180);
            this.btnProcedures.Name = "btnProcedures";
            this.btnProcedures.Size = new System.Drawing.Size(230, 50);
            this.btnProcedures.TabIndex = 4;
            this.btnProcedures.Text = "Gestión de Procedimientos";
            this.btnProcedures.UseVisualStyleBackColor = false;
            this.btnProcedures.Click += new System.EventHandler(this.btnProcedures_Click);
            
            // btnDiagnosticAids
            this.btnDiagnosticAids.BackColor = System.Drawing.Color.White;
            this.btnDiagnosticAids.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiagnosticAids.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDiagnosticAids.Location = new System.Drawing.Point(10, 240);
            this.btnDiagnosticAids.Name = "btnDiagnosticAids";
            this.btnDiagnosticAids.Size = new System.Drawing.Size(230, 50);
            this.btnDiagnosticAids.TabIndex = 5;
            this.btnDiagnosticAids.Text = "Gestión de Ayudas Diagnósticas";
            this.btnDiagnosticAids.UseVisualStyleBackColor = false;
            this.btnDiagnosticAids.Click += new System.EventHandler(this.btnDiagnosticAids_Click);
            
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
            
            // SupportMainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = true;
            this.Name = "SupportMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Soporte Técnico";
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
        private System.Windows.Forms.Button btnMedications;
        private System.Windows.Forms.Button btnProcedures;
        private System.Windows.Forms.Button btnDiagnosticAids;
        private System.Windows.Forms.Button btnLogout;
    }
}
