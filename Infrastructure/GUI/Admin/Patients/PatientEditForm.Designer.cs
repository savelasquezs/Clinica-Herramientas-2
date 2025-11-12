namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Patients
{
    partial class PatientEditForm
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
            this.grpPersonalInfo = new System.Windows.Forms.GroupBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhonenumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpPersonalInfo.SuspendLayout();
            this.SuspendLayout();
            
            // grpPersonalInfo
            this.grpPersonalInfo.Controls.Add(this.dtpBirthdate);
            this.grpPersonalInfo.Controls.Add(this.txtAddress);
            this.grpPersonalInfo.Controls.Add(this.txtPhonenumber);
            this.grpPersonalInfo.Controls.Add(this.txtEmail);
            this.grpPersonalInfo.Controls.Add(this.txtDni);
            this.grpPersonalInfo.Controls.Add(this.txtFullname);
            this.grpPersonalInfo.Controls.Add(this.lblBirthdate);
            this.grpPersonalInfo.Controls.Add(this.lblAddress);
            this.grpPersonalInfo.Controls.Add(this.lblPhonenumber);
            this.grpPersonalInfo.Controls.Add(this.lblEmail);
            this.grpPersonalInfo.Controls.Add(this.lblDni);
            this.grpPersonalInfo.Controls.Add(this.lblFullname);
            this.grpPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpPersonalInfo.Location = new System.Drawing.Point(20, 20);
            this.grpPersonalInfo.Name = "grpPersonalInfo";
            this.grpPersonalInfo.Size = new System.Drawing.Size(700, 250);
            this.grpPersonalInfo.TabIndex = 0;
            this.grpPersonalInfo.TabStop = false;
            this.grpPersonalInfo.Text = "Información del Paciente";
            
            // txtFullname
            this.txtFullname.Location = new System.Drawing.Point(150, 30);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.ReadOnly = true;
            this.txtFullname.Size = new System.Drawing.Size(500, 23);
            this.txtFullname.TabIndex = 1;
            
            // lblFullname
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFullname.Location = new System.Drawing.Point(20, 33);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(110, 15);
            this.lblFullname.TabIndex = 0;
            this.lblFullname.Text = "Nombre Completo:";
            
            // txtDni
            this.txtDni.Location = new System.Drawing.Point(150, 65);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(200, 23);
            this.txtDni.TabIndex = 3;
            
            // lblDni
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDni.Location = new System.Drawing.Point(20, 68);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(32, 15);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "DNI:";
            
            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 23);
            this.txtEmail.TabIndex = 5;
            
            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(20, 103);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 15);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            
            // txtPhonenumber
            this.txtPhonenumber.Location = new System.Drawing.Point(150, 135);
            this.txtPhonenumber.Name = "txtPhonenumber";
            this.txtPhonenumber.Size = new System.Drawing.Size(200, 23);
            this.txtPhonenumber.TabIndex = 7;
            
            // lblPhonenumber
            this.lblPhonenumber.AutoSize = true;
            this.lblPhonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhonenumber.Location = new System.Drawing.Point(20, 138);
            this.lblPhonenumber.Name = "lblPhonenumber";
            this.lblPhonenumber.Size = new System.Drawing.Size(61, 15);
            this.lblPhonenumber.TabIndex = 6;
            this.lblPhonenumber.Text = "Teléfono:";
            
            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(150, 170);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(500, 23);
            this.txtAddress.TabIndex = 9;
            
            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAddress.Location = new System.Drawing.Point(20, 173);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 15);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Dirección:";
            
            // dtpBirthdate
            this.dtpBirthdate.Enabled = false;
            this.dtpBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(150, 205);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 21);
            this.dtpBirthdate.TabIndex = 11;
            
            // lblBirthdate
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBirthdate.Location = new System.Drawing.Point(20, 208);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(118, 15);
            this.lblBirthdate.TabIndex = 10;
            this.lblBirthdate.Text = "Fecha de Nacimiento:";
            
            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(500, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(620, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // PatientEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 350);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpPersonalInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PatientEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Paciente";
            this.grpPersonalInfo.ResumeLayout(false);
            this.grpPersonalInfo.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpPersonalInfo;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPhonenumber;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

