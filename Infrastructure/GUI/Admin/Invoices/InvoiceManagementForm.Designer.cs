namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Invoices
{
    partial class InvoiceManagementForm
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
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpNewInvoice = new System.Windows.Forms.GroupBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.txtOrderNumbers = new System.Windows.Forms.TextBox();
            this.txtDoctorDni = new System.Windows.Forms.TextBox();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblOrderNumbers = new System.Windows.Forms.Label();
            this.lblDoctorDni = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblInvoiceNumber = new System.Windows.Forms.Label();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.grpNewInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(131, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Facturación";
            
            // pnlActions
            this.pnlActions.Controls.Add(this.btnRefresh);
            this.pnlActions.Controls.Add(this.btnViewDetails);
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
            this.txtSearch.PlaceholderText = "Buscar por número, DNI o nombre del paciente...";
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
            this.btnNew.Location = new System.Drawing.Point(830, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 30);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Nueva Factura";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            
            // btnViewDetails
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(960, 15);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 30);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "Ver Detalles";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            
            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1090, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Actualizar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // grpNewInvoice
            this.grpNewInvoice.Controls.Add(this.dtpInvoiceDate);
            this.grpNewInvoice.Controls.Add(this.txtOrderNumbers);
            this.grpNewInvoice.Controls.Add(this.txtDoctorDni);
            this.grpNewInvoice.Controls.Add(this.cmbDoctor);
            this.grpNewInvoice.Controls.Add(this.cmbPatient);
            this.grpNewInvoice.Controls.Add(this.txtInvoiceNumber);
            this.grpNewInvoice.Controls.Add(this.lblInvoiceDate);
            this.grpNewInvoice.Controls.Add(this.lblOrderNumbers);
            this.grpNewInvoice.Controls.Add(this.lblDoctorDni);
            this.grpNewInvoice.Controls.Add(this.lblPatient);
            this.grpNewInvoice.Controls.Add(this.lblInvoiceNumber);
            this.grpNewInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpNewInvoice.Location = new System.Drawing.Point(0, 120);
            this.grpNewInvoice.Name = "grpNewInvoice";
            this.grpNewInvoice.Padding = new System.Windows.Forms.Padding(20);
            this.grpNewInvoice.Size = new System.Drawing.Size(1200, 120);
            this.grpNewInvoice.TabIndex = 2;
            this.grpNewInvoice.TabStop = false;
            this.grpNewInvoice.Text = "Nueva Factura";
            
            // lblInvoiceNumber
            this.lblInvoiceNumber.AutoSize = true;
            this.lblInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInvoiceNumber.Location = new System.Drawing.Point(30, 30);
            this.lblInvoiceNumber.Name = "lblInvoiceNumber";
            this.lblInvoiceNumber.Size = new System.Drawing.Size(60, 15);
            this.lblInvoiceNumber.TabIndex = 0;
            this.lblInvoiceNumber.Text = "Número:";
            
            // txtInvoiceNumber
            this.txtInvoiceNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInvoiceNumber.Location = new System.Drawing.Point(96, 27);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(100, 21);
            this.txtInvoiceNumber.TabIndex = 1;
            
            // lblPatient
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatient.Location = new System.Drawing.Point(210, 30);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(57, 15);
            this.lblPatient.TabIndex = 2;
            this.lblPatient.Text = "Paciente:";
            
            // cmbPatient
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(273, 27);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(300, 23);
            this.cmbPatient.TabIndex = 3;
            
            // cmbDoctor
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.Enabled = false;
            this.cmbDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(600, 27);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(200, 23);
            this.cmbDoctor.TabIndex = 4;
            
            // lblDoctorDni
            this.lblDoctorDni.AutoSize = true;
            this.lblDoctorDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDoctorDni.Location = new System.Drawing.Point(30, 70);
            this.lblDoctorDni.Name = "lblDoctorDni";
            this.lblDoctorDni.Size = new System.Drawing.Size(90, 15);
            this.lblDoctorDni.TabIndex = 5;
            this.lblDoctorDni.Text = "DNI del Médico:";
            
            // txtDoctorDni
            this.txtDoctorDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDoctorDni.Location = new System.Drawing.Point(126, 67);
            this.txtDoctorDni.Name = "txtDoctorDni";
            this.txtDoctorDni.Size = new System.Drawing.Size(150, 21);
            this.txtDoctorDni.TabIndex = 6;
            
            // lblOrderNumbers
            this.lblOrderNumbers.AutoSize = true;
            this.lblOrderNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderNumbers.Location = new System.Drawing.Point(290, 70);
            this.lblOrderNumbers.Name = "lblOrderNumbers";
            this.lblOrderNumbers.Size = new System.Drawing.Size(120, 15);
            this.lblOrderNumbers.TabIndex = 7;
            this.lblOrderNumbers.Text = "Números de Orden:";
            
            // txtOrderNumbers
            this.txtOrderNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrderNumbers.Location = new System.Drawing.Point(416, 67);
            this.txtOrderNumbers.Name = "txtOrderNumbers";
            this.txtOrderNumbers.PlaceholderText = "Ej: 1, 2, 3";
            this.txtOrderNumbers.Size = new System.Drawing.Size(300, 21);
            this.txtOrderNumbers.TabIndex = 8;
            
            // lblInvoiceDate
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInvoiceDate.Location = new System.Drawing.Point(730, 70);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(42, 15);
            this.lblInvoiceDate.TabIndex = 9;
            this.lblInvoiceDate.Text = "Fecha:";
            
            // dtpInvoiceDate
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(778, 67);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(150, 21);
            this.dtpInvoiceDate.TabIndex = 10;
            
            // dgvInvoices
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.Location = new System.Drawing.Point(0, 240);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(1200, 410);
            this.dgvInvoices.TabIndex = 3;
            this.dgvInvoices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellDoubleClick);
            
            // InvoiceManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.grpNewInvoice);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InvoiceManagementForm";
            this.Text = "Facturación";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.grpNewInvoice.ResumeLayout(false);
            this.grpNewInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpNewInvoice;
        private System.Windows.Forms.Label lblInvoiceNumber;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label lblDoctorDni;
        private System.Windows.Forms.TextBox txtDoctorDni;
        private System.Windows.Forms.Label lblOrderNumbers;
        private System.Windows.Forms.TextBox txtOrderNumbers;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.DataGridView dgvInvoices;
    }
}

