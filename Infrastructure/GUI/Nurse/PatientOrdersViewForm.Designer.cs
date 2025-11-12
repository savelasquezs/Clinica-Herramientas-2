namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    partial class PatientOrdersViewForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlPatient = new System.Windows.Forms.Panel();
            this.lblPatientInfo = new System.Windows.Forms.Label();
            this.btnSelectPatient = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(236, 72, 153);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Órdenes del Paciente";
            this.pnlPatient.Controls.Add(this.btnViewDetails);
            this.pnlPatient.Controls.Add(this.lblPatientInfo);
            this.pnlPatient.Controls.Add(this.btnSelectPatient);
            this.pnlPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatient.Location = new System.Drawing.Point(0, 60);
            this.pnlPatient.Name = "pnlPatient";
            this.pnlPatient.Padding = new System.Windows.Forms.Padding(10);
            this.pnlPatient.Size = new System.Drawing.Size(1200, 60);
            this.pnlPatient.TabIndex = 1;
            this.btnSelectPatient.BackColor = System.Drawing.Color.FromArgb(236, 72, 153);
            this.btnSelectPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectPatient.ForeColor = System.Drawing.Color.White;
            this.btnSelectPatient.Location = new System.Drawing.Point(20, 15);
            this.btnSelectPatient.Name = "btnSelectPatient";
            this.btnSelectPatient.Size = new System.Drawing.Size(150, 30);
            this.btnSelectPatient.TabIndex = 0;
            this.btnSelectPatient.Text = "Buscar Paciente";
            this.btnSelectPatient.UseVisualStyleBackColor = false;
            this.btnSelectPatient.Click += new System.EventHandler(this.btnSelectPatient_Click);
            this.lblPatientInfo.AutoSize = true;
            this.lblPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPatientInfo.Location = new System.Drawing.Point(190, 20);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(150, 17);
            this.lblPatientInfo.TabIndex = 1;
            this.lblPatientInfo.Text = "Seleccione un paciente";
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(1080, 15);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(100, 30);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "Ver Detalles";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 120);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1200, 530);
            this.dgvOrders.TabIndex = 2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(253, 242, 248);
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pnlPatient);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientOrdersViewForm";
            this.Text = "Órdenes del Paciente";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPatient.ResumeLayout(false);
            this.pnlPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlPatient;
        private System.Windows.Forms.Button btnSelectPatient;
        private System.Windows.Forms.Label lblPatientInfo;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.DataGridView dgvOrders;
    }
}

