namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Patients
{
    partial class PatientCreateForm
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
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhonenumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.grpEmergencyContact = new System.Windows.Forms.GroupBox();
            this.txtEmergencyPhone = new System.Windows.Forms.TextBox();
            this.txtEmergencyRelationship = new System.Windows.Forms.TextBox();
            this.txtEmergencyLastName = new System.Windows.Forms.TextBox();
            this.txtEmergencyFirstName = new System.Windows.Forms.TextBox();
            this.lblEmergencyPhone = new System.Windows.Forms.Label();
            this.lblEmergencyRelationship = new System.Windows.Forms.Label();
            this.lblEmergencyLastName = new System.Windows.Forms.Label();
            this.lblEmergencyFirstName = new System.Windows.Forms.Label();
            this.grpInsurance = new System.Windows.Forms.GroupBox();
            this.dtpInsuranceExpiration = new System.Windows.Forms.DateTimePicker();
            this.chkInsuranceActive = new System.Windows.Forms.CheckBox();
            this.txtInsurancePolicy = new System.Windows.Forms.TextBox();
            this.txtInsuranceCompany = new System.Windows.Forms.TextBox();
            this.lblInsuranceExpiration = new System.Windows.Forms.Label();
            this.lblInsurancePolicy = new System.Windows.Forms.Label();
            this.lblInsuranceCompany = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpPersonalInfo.SuspendLayout();
            this.grpEmergencyContact.SuspendLayout();
            this.grpInsurance.SuspendLayout();
            this.SuspendLayout();
            
            // grpPersonalInfo
            this.grpPersonalInfo.Controls.Add(this.dtpBirthdate);
            this.grpPersonalInfo.Controls.Add(this.cmbGender);
            this.grpPersonalInfo.Controls.Add(this.txtAddress);
            this.grpPersonalInfo.Controls.Add(this.txtPhonenumber);
            this.grpPersonalInfo.Controls.Add(this.txtEmail);
            this.grpPersonalInfo.Controls.Add(this.txtDni);
            this.grpPersonalInfo.Controls.Add(this.txtFullname);
            this.grpPersonalInfo.Controls.Add(this.lblBirthdate);
            this.grpPersonalInfo.Controls.Add(this.lblGender);
            this.grpPersonalInfo.Controls.Add(this.lblAddress);
            this.grpPersonalInfo.Controls.Add(this.lblPhonenumber);
            this.grpPersonalInfo.Controls.Add(this.lblEmail);
            this.grpPersonalInfo.Controls.Add(this.lblDni);
            this.grpPersonalInfo.Controls.Add(this.lblFullname);
            this.grpPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpPersonalInfo.Location = new System.Drawing.Point(20, 20);
            this.grpPersonalInfo.Name = "grpPersonalInfo";
            this.grpPersonalInfo.Size = new System.Drawing.Size(700, 280);
            this.grpPersonalInfo.TabIndex = 0;
            this.grpPersonalInfo.TabStop = false;
            this.grpPersonalInfo.Text = "Información Personal";
            
            // txtFullname
            this.txtFullname.Location = new System.Drawing.Point(150, 30);
            this.txtFullname.Name = "txtFullname";
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
            
            // cmbGender
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(150, 205);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(200, 23);
            this.cmbGender.TabIndex = 11;
            
            // lblGender
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGender.Location = new System.Drawing.Point(20, 208);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(52, 15);
            this.lblGender.TabIndex = 10;
            this.lblGender.Text = "Género:";
            
            // dtpBirthdate
            this.dtpBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(150, 240);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 21);
            this.dtpBirthdate.TabIndex = 13;
            
            // lblBirthdate
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBirthdate.Location = new System.Drawing.Point(20, 243);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(118, 15);
            this.lblBirthdate.TabIndex = 12;
            this.lblBirthdate.Text = "Fecha de Nacimiento:";
            
            // grpEmergencyContact
            this.grpEmergencyContact.Controls.Add(this.txtEmergencyPhone);
            this.grpEmergencyContact.Controls.Add(this.txtEmergencyRelationship);
            this.grpEmergencyContact.Controls.Add(this.txtEmergencyLastName);
            this.grpEmergencyContact.Controls.Add(this.txtEmergencyFirstName);
            this.grpEmergencyContact.Controls.Add(this.lblEmergencyPhone);
            this.grpEmergencyContact.Controls.Add(this.lblEmergencyRelationship);
            this.grpEmergencyContact.Controls.Add(this.lblEmergencyLastName);
            this.grpEmergencyContact.Controls.Add(this.lblEmergencyFirstName);
            this.grpEmergencyContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpEmergencyContact.Location = new System.Drawing.Point(20, 320);
            this.grpEmergencyContact.Name = "grpEmergencyContact";
            this.grpEmergencyContact.Size = new System.Drawing.Size(700, 180);
            this.grpEmergencyContact.TabIndex = 1;
            this.grpEmergencyContact.TabStop = false;
            this.grpEmergencyContact.Text = "Contacto de Emergencia";
            
            // txtEmergencyFirstName
            this.txtEmergencyFirstName.Location = new System.Drawing.Point(150, 30);
            this.txtEmergencyFirstName.Name = "txtEmergencyFirstName";
            this.txtEmergencyFirstName.Size = new System.Drawing.Size(250, 23);
            this.txtEmergencyFirstName.TabIndex = 1;
            
            // lblEmergencyFirstName
            this.lblEmergencyFirstName.AutoSize = true;
            this.lblEmergencyFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmergencyFirstName.Location = new System.Drawing.Point(20, 33);
            this.lblEmergencyFirstName.Name = "lblEmergencyFirstName";
            this.lblEmergencyFirstName.Size = new System.Drawing.Size(58, 15);
            this.lblEmergencyFirstName.TabIndex = 0;
            this.lblEmergencyFirstName.Text = "Nombres:";
            
            // txtEmergencyLastName
            this.txtEmergencyLastName.Location = new System.Drawing.Point(150, 65);
            this.txtEmergencyLastName.Name = "txtEmergencyLastName";
            this.txtEmergencyLastName.Size = new System.Drawing.Size(250, 23);
            this.txtEmergencyLastName.TabIndex = 3;
            
            // lblEmergencyLastName
            this.lblEmergencyLastName.AutoSize = true;
            this.lblEmergencyLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmergencyLastName.Location = new System.Drawing.Point(20, 68);
            this.lblEmergencyLastName.Name = "lblEmergencyLastName";
            this.lblEmergencyLastName.Size = new System.Drawing.Size(58, 15);
            this.lblEmergencyLastName.TabIndex = 2;
            this.lblEmergencyLastName.Text = "Apellidos:";
            
            // txtEmergencyRelationship
            this.txtEmergencyRelationship.Location = new System.Drawing.Point(150, 100);
            this.txtEmergencyRelationship.Name = "txtEmergencyRelationship";
            this.txtEmergencyRelationship.Size = new System.Drawing.Size(300, 23);
            this.txtEmergencyRelationship.TabIndex = 5;
            
            // lblEmergencyRelationship
            this.lblEmergencyRelationship.AutoSize = true;
            this.lblEmergencyRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmergencyRelationship.Location = new System.Drawing.Point(20, 103);
            this.lblEmergencyRelationship.Name = "lblEmergencyRelationship";
            this.lblEmergencyRelationship.Size = new System.Drawing.Size(60, 15);
            this.lblEmergencyRelationship.TabIndex = 4;
            this.lblEmergencyRelationship.Text = "Relación:";
            
            // txtEmergencyPhone
            this.txtEmergencyPhone.Location = new System.Drawing.Point(150, 135);
            this.txtEmergencyPhone.Name = "txtEmergencyPhone";
            this.txtEmergencyPhone.Size = new System.Drawing.Size(200, 23);
            this.txtEmergencyPhone.TabIndex = 7;
            
            // lblEmergencyPhone
            this.lblEmergencyPhone.AutoSize = true;
            this.lblEmergencyPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmergencyPhone.Location = new System.Drawing.Point(20, 138);
            this.lblEmergencyPhone.Name = "lblEmergencyPhone";
            this.lblEmergencyPhone.Size = new System.Drawing.Size(61, 15);
            this.lblEmergencyPhone.TabIndex = 6;
            this.lblEmergencyPhone.Text = "Teléfono:";
            
            // grpInsurance
            this.grpInsurance.Controls.Add(this.dtpInsuranceExpiration);
            this.grpInsurance.Controls.Add(this.chkInsuranceActive);
            this.grpInsurance.Controls.Add(this.txtInsurancePolicy);
            this.grpInsurance.Controls.Add(this.txtInsuranceCompany);
            this.grpInsurance.Controls.Add(this.lblInsuranceExpiration);
            this.grpInsurance.Controls.Add(this.lblInsurancePolicy);
            this.grpInsurance.Controls.Add(this.lblInsuranceCompany);
            this.grpInsurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpInsurance.Location = new System.Drawing.Point(20, 520);
            this.grpInsurance.Name = "grpInsurance";
            this.grpInsurance.Size = new System.Drawing.Size(700, 150);
            this.grpInsurance.TabIndex = 2;
            this.grpInsurance.TabStop = false;
            this.grpInsurance.Text = "Seguro Médico";
            
            // txtInsuranceCompany
            this.txtInsuranceCompany.Location = new System.Drawing.Point(150, 30);
            this.txtInsuranceCompany.Name = "txtInsuranceCompany";
            this.txtInsuranceCompany.Size = new System.Drawing.Size(500, 23);
            this.txtInsuranceCompany.TabIndex = 1;
            
            // lblInsuranceCompany
            this.lblInsuranceCompany.AutoSize = true;
            this.lblInsuranceCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInsuranceCompany.Location = new System.Drawing.Point(20, 33);
            this.lblInsuranceCompany.Name = "lblInsuranceCompany";
            this.lblInsuranceCompany.Size = new System.Drawing.Size(124, 15);
            this.lblInsuranceCompany.TabIndex = 0;
            this.lblInsuranceCompany.Text = "Compañía de Seguros:";
            
            // txtInsurancePolicy
            this.txtInsurancePolicy.Location = new System.Drawing.Point(150, 65);
            this.txtInsurancePolicy.Name = "txtInsurancePolicy";
            this.txtInsurancePolicy.Size = new System.Drawing.Size(300, 23);
            this.txtInsurancePolicy.TabIndex = 3;
            
            // lblInsurancePolicy
            this.lblInsurancePolicy.AutoSize = true;
            this.lblInsurancePolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInsurancePolicy.Location = new System.Drawing.Point(20, 68);
            this.lblInsurancePolicy.Name = "lblInsurancePolicy";
            this.lblInsurancePolicy.Size = new System.Drawing.Size(100, 15);
            this.lblInsurancePolicy.TabIndex = 2;
            this.lblInsurancePolicy.Text = "Número de Póliza:";
            
            // chkInsuranceActive
            this.chkInsuranceActive.AutoSize = true;
            this.chkInsuranceActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkInsuranceActive.Location = new System.Drawing.Point(150, 100);
            this.chkInsuranceActive.Name = "chkInsuranceActive";
            this.chkInsuranceActive.Size = new System.Drawing.Size(65, 19);
            this.chkInsuranceActive.TabIndex = 5;
            this.chkInsuranceActive.Text = "Activa";
            this.chkInsuranceActive.UseVisualStyleBackColor = true;
            
            // dtpInsuranceExpiration
            this.dtpInsuranceExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpInsuranceExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInsuranceExpiration.Location = new System.Drawing.Point(150, 120);
            this.dtpInsuranceExpiration.Name = "dtpInsuranceExpiration";
            this.dtpInsuranceExpiration.Size = new System.Drawing.Size(200, 21);
            this.dtpInsuranceExpiration.TabIndex = 7;
            
            // lblInsuranceExpiration
            this.lblInsuranceExpiration.AutoSize = true;
            this.lblInsuranceExpiration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInsuranceExpiration.Location = new System.Drawing.Point(20, 123);
            this.lblInsuranceExpiration.Name = "lblInsuranceExpiration";
            this.lblInsuranceExpiration.Size = new System.Drawing.Size(119, 15);
            this.lblInsuranceExpiration.TabIndex = 6;
            this.lblInsuranceExpiration.Text = "Fecha de Vencimiento:";
            
            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(500, 690);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(620, 690);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // PatientCreateForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 750);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpInsurance);
            this.Controls.Add(this.grpEmergencyContact);
            this.Controls.Add(this.grpPersonalInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PatientCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Crear Nuevo Paciente";
            this.grpPersonalInfo.ResumeLayout(false);
            this.grpPersonalInfo.PerformLayout();
            this.grpEmergencyContact.ResumeLayout(false);
            this.grpEmergencyContact.PerformLayout();
            this.grpInsurance.ResumeLayout(false);
            this.grpInsurance.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.GroupBox grpEmergencyContact;
        private System.Windows.Forms.TextBox txtEmergencyFirstName;
        private System.Windows.Forms.Label lblEmergencyFirstName;
        private System.Windows.Forms.TextBox txtEmergencyLastName;
        private System.Windows.Forms.Label lblEmergencyLastName;
        private System.Windows.Forms.TextBox txtEmergencyRelationship;
        private System.Windows.Forms.Label lblEmergencyRelationship;
        private System.Windows.Forms.TextBox txtEmergencyPhone;
        private System.Windows.Forms.Label lblEmergencyPhone;
        private System.Windows.Forms.GroupBox grpInsurance;
        private System.Windows.Forms.TextBox txtInsuranceCompany;
        private System.Windows.Forms.Label lblInsuranceCompany;
        private System.Windows.Forms.TextBox txtInsurancePolicy;
        private System.Windows.Forms.Label lblInsurancePolicy;
        private System.Windows.Forms.CheckBox chkInsuranceActive;
        private System.Windows.Forms.DateTimePicker dtpInsuranceExpiration;
        private System.Windows.Forms.Label lblInsuranceExpiration;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

