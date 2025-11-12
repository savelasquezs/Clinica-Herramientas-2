namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Appointments
{
    partial class AppointmentManagementForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpNewAppointment = new System.Windows.Forms.GroupBox();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.txtAppointmentId = new System.Windows.Forms.TextBox();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblAppointmentId = new System.Windows.Forms.Label();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.grpNewAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(178, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestión de Citas";
            
            // pnlActions
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnNew);
            this.pnlActions.Controls.Add(this.txtSearch);
            this.pnlActions.Controls.Add(this.btnSearch);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 60);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(10);
            this.pnlActions.Size = new System.Drawing.Size(1200, 60);
            this.pnlActions.TabIndex = 1;
            
            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(20, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Buscar por DNI o nombre del paciente...";
            this.txtSearch.Size = new System.Drawing.Size(400, 23);
            this.txtSearch.TabIndex = 0;
            
            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(430, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            
            // btnNew
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(950, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 30);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nueva Cita";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            
            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1080, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Actualizar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // grpNewAppointment
            this.grpNewAppointment.Controls.Add(this.dtpAppointmentDate);
            this.grpNewAppointment.Controls.Add(this.cmbPatient);
            this.grpNewAppointment.Controls.Add(this.txtAppointmentId);
            this.grpNewAppointment.Controls.Add(this.lblAppointmentDate);
            this.grpNewAppointment.Controls.Add(this.lblPatient);
            this.grpNewAppointment.Controls.Add(this.lblAppointmentId);
            this.grpNewAppointment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNewAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpNewAppointment.Location = new System.Drawing.Point(0, 120);
            this.grpNewAppointment.Name = "grpNewAppointment";
            this.grpNewAppointment.Padding = new System.Windows.Forms.Padding(20);
            this.grpNewAppointment.Size = new System.Drawing.Size(1200, 100);
            this.grpNewAppointment.TabIndex = 2;
            this.grpNewAppointment.TabStop = false;
            this.grpNewAppointment.Text = "Nueva Cita";
            
            // lblAppointmentId
            this.lblAppointmentId.AutoSize = true;
            this.lblAppointmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAppointmentId.Location = new System.Drawing.Point(30, 35);
            this.lblAppointmentId.Name = "lblAppointmentId";
            this.lblAppointmentId.Size = new System.Drawing.Size(24, 15);
            this.lblAppointmentId.TabIndex = 0;
            this.lblAppointmentId.Text = "ID:";
            
            // txtAppointmentId
            this.txtAppointmentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAppointmentId.Location = new System.Drawing.Point(60, 32);
            this.txtAppointmentId.Name = "txtAppointmentId";
            this.txtAppointmentId.Size = new System.Drawing.Size(100, 21);
            this.txtAppointmentId.TabIndex = 1;
            
            // lblPatient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatient.Location = new System.Drawing.Point(180, 35);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(57, 15);
            this.lblPatient.TabIndex = 2;
            this.lblPatient.Text = "Paciente:";
            
            // cmbPatient
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(243, 32);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(400, 23);
            this.cmbPatient.TabIndex = 3;
            
            // lblAppointmentDate
            this.lblAppointmentDate.AutoSize = true;
            this.lblAppointmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAppointmentDate.Location = new System.Drawing.Point(660, 35);
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.Size = new System.Drawing.Size(42, 15);
            this.lblAppointmentDate.TabIndex = 4;
            this.lblAppointmentDate.Text = "Fecha:";
            
            // dtpAppointmentDate
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpAppointmentDate.ShowUpDown = true;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(708, 32);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(200, 21);
            this.dtpAppointmentDate.TabIndex = 5;
            
            // dgvAppointments
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAppointments.Location = new System.Drawing.Point(0, 220);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(1200, 430);
            this.dgvAppointments.TabIndex = 3;
            
            // AppointmentManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.grpNewAppointment);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppointmentManagementForm";
            this.Text = "Gestión de Citas";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.grpNewAppointment.ResumeLayout(false);
            this.grpNewAppointment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpNewAppointment;
        private System.Windows.Forms.Label lblAppointmentId;
        private System.Windows.Forms.TextBox txtAppointmentId;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.Label lblAppointmentDate;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.DataGridView dgvAppointments;
    }
}

