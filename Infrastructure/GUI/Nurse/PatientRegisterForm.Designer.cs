namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    partial class PatientRegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpPatientInfo;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.GroupBox grpVitals;
        private System.Windows.Forms.Label lblBloodPressure;
        private System.Windows.Forms.TextBox txtBloodPressure;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.Label lblPulse;
        private System.Windows.Forms.TextBox txtPulse;
        private System.Windows.Forms.Label lblOxygenLevel;
        private System.Windows.Forms.TextBox txtOxygenLevel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.grpPatientInfo = new System.Windows.Forms.GroupBox();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.grpVitals = new System.Windows.Forms.GroupBox();
            this.lblBloodPressure = new System.Windows.Forms.Label();
            this.txtBloodPressure = new System.Windows.Forms.TextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.lblPulse = new System.Windows.Forms.Label();
            this.txtPulse = new System.Windows.Forms.TextBox();
            this.lblOxygenLevel = new System.Windows.Forms.Label();
            this.txtOxygenLevel = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpPatientInfo.SuspendLayout();
            this.grpVitals.SuspendLayout();
            this.SuspendLayout();
            
            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(700, 60);
            this.pnlHeader.TabIndex = 0;
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Registrar Signos Vitales";
            
            // grpPatientInfo
            this.grpPatientInfo.Controls.Add(this.lblPatientName);
            this.grpPatientInfo.Controls.Add(this.txtPatientName);
            this.grpPatientInfo.Controls.Add(this.lblPatientId);
            this.grpPatientInfo.Controls.Add(this.txtPatientId);
            this.grpPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpPatientInfo.Location = new System.Drawing.Point(20, 80);
            this.grpPatientInfo.Name = "grpPatientInfo";
            this.grpPatientInfo.Size = new System.Drawing.Size(660, 100);
            this.grpPatientInfo.TabIndex = 1;
            this.grpPatientInfo.TabStop = false;
            this.grpPatientInfo.Text = "Información del Paciente";
            
            // lblPatientId
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatientId.Location = new System.Drawing.Point(20, 30);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(66, 15);
            this.lblPatientId.TabIndex = 0;
            this.lblPatientId.Text = "ID Paciente:";
            
            // txtPatientId
            this.txtPatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPatientId.Location = new System.Drawing.Point(120, 27);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(300, 21);
            this.txtPatientId.TabIndex = 1;
            
            // lblPatientName
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPatientName.Location = new System.Drawing.Point(20, 65);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(99, 15);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "Nombre Paciente:";
            
            // txtPatientName
            this.txtPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPatientName.Location = new System.Drawing.Point(120, 62);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(500, 21);
            this.txtPatientName.TabIndex = 3;
            
            // grpVitals
            this.grpVitals.Controls.Add(this.lblOxygenLevel);
            this.grpVitals.Controls.Add(this.txtOxygenLevel);
            this.grpVitals.Controls.Add(this.lblPulse);
            this.grpVitals.Controls.Add(this.txtPulse);
            this.grpVitals.Controls.Add(this.lblTemperature);
            this.grpVitals.Controls.Add(this.txtTemperature);
            this.grpVitals.Controls.Add(this.lblBloodPressure);
            this.grpVitals.Controls.Add(this.txtBloodPressure);
            this.grpVitals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpVitals.Location = new System.Drawing.Point(20, 200);
            this.grpVitals.Name = "grpVitals";
            this.grpVitals.Size = new System.Drawing.Size(660, 200);
            this.grpVitals.TabIndex = 2;
            this.grpVitals.TabStop = false;
            this.grpVitals.Text = "Signos Vitales";
            
            // lblBloodPressure
            this.lblBloodPressure.AutoSize = true;
            this.lblBloodPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBloodPressure.Location = new System.Drawing.Point(20, 30);
            this.lblBloodPressure.Name = "lblBloodPressure";
            this.lblBloodPressure.Size = new System.Drawing.Size(120, 15);
            this.lblBloodPressure.TabIndex = 0;
            this.lblBloodPressure.Text = "Presión Arterial:";
            
            // txtBloodPressure
            this.txtBloodPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtBloodPressure.Location = new System.Drawing.Point(150, 27);
            this.txtBloodPressure.Name = "txtBloodPressure";
            this.txtBloodPressure.Size = new System.Drawing.Size(200, 21);
            this.txtBloodPressure.TabIndex = 1;
            this.txtBloodPressure.PlaceholderText = "Ej: 120/80";
            
            // lblTemperature
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTemperature.Location = new System.Drawing.Point(20, 70);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(90, 15);
            this.lblTemperature.TabIndex = 2;
            this.lblTemperature.Text = "Temperatura (°C):";
            
            // txtTemperature
            this.txtTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTemperature.Location = new System.Drawing.Point(150, 67);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(200, 21);
            this.txtTemperature.TabIndex = 3;
            
            // lblPulse
            this.lblPulse.AutoSize = true;
            this.lblPulse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPulse.Location = new System.Drawing.Point(20, 110);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(50, 15);
            this.lblPulse.TabIndex = 4;
            this.lblPulse.Text = "Pulso:";
            
            // txtPulse
            this.txtPulse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPulse.Location = new System.Drawing.Point(150, 107);
            this.txtPulse.Name = "txtPulse";
            this.txtPulse.Size = new System.Drawing.Size(200, 21);
            this.txtPulse.TabIndex = 5;
            
            // lblOxygenLevel
            this.lblOxygenLevel.AutoSize = true;
            this.lblOxygenLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOxygenLevel.Location = new System.Drawing.Point(20, 150);
            this.lblOxygenLevel.Name = "lblOxygenLevel";
            this.lblOxygenLevel.Size = new System.Drawing.Size(160, 15);
            this.lblOxygenLevel.TabIndex = 6;
            this.lblOxygenLevel.Text = "Nivel de Oxígeno en Sangre (%):";
            
            // txtOxygenLevel
            this.txtOxygenLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOxygenLevel.Location = new System.Drawing.Point(190, 147);
            this.txtOxygenLevel.Name = "txtOxygenLevel";
            this.txtOxygenLevel.Size = new System.Drawing.Size(160, 21);
            this.txtOxygenLevel.TabIndex = 7;
            
            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(72)))), ((int)(((byte)(153)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(450, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(580, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // PatientRegisterForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(242)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpVitals);
            this.Controls.Add(this.grpPatientInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientRegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Signos Vitales";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpPatientInfo.ResumeLayout(false);
            this.grpPatientInfo.PerformLayout();
            this.grpVitals.ResumeLayout(false);
            this.grpVitals.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
