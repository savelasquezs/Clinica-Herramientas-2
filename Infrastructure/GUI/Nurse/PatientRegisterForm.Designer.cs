using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    partial class PatientRegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPatientId;
        private TextBox txtPatientId;
        private Label lblPatientName;
        private TextBox txtPatientName;
        private Label lblBloodPressure;
        private TextBox txtBloodPressure;
        private Label lblTemperature;
        private TextBox txtTemperature;
        private Label lblPulse;
        private TextBox txtPulse;
        private Label lblOxygenLevel;
        private TextBox txtOxygenLevel;
        private Button btnSave;
        private Button btnCancel;

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
            lblPatientId = new Label();
            txtPatientId = new TextBox();
            lblPatientName = new Label();
            txtPatientName = new TextBox();
            lblBloodPressure = new Label();
            txtBloodPressure = new TextBox();
            lblTemperature = new Label();
            txtTemperature = new TextBox();
            lblPulse = new Label();
            txtPulse = new TextBox();
            lblOxygenLevel = new Label();
            txtOxygenLevel = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Location = new Point(73, 147);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new Size(66, 15);
            lblPatientId.TabIndex = 0;
            lblPatientId.Text = "ID Paciente";
            // 
            // txtPatientId
            // 
            txtPatientId.Location = new Point(203, 143);
            txtPatientId.Name = "txtPatientId";
            txtPatientId.Size = new Size(300, 23);
            txtPatientId.TabIndex = 1;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Location = new Point(73, 187);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(99, 15);
            lblPatientName.TabIndex = 2;
            lblPatientName.Text = "Nombre Paciente";
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(203, 183);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(300, 23);
            txtPatientName.TabIndex = 3;
            // 
            // lblBloodPressure
            // 
            lblBloodPressure.AutoSize = true;
            lblBloodPressure.Location = new Point(73, 227);
            lblBloodPressure.Name = "lblBloodPressure";
            lblBloodPressure.Size = new Size(87, 15);
            lblBloodPressure.TabIndex = 4;
            lblBloodPressure.Text = "Presión Arterial";
            // 
            // txtBloodPressure
            // 
            txtBloodPressure.Location = new Point(203, 223);
            txtBloodPressure.Name = "txtBloodPressure";
            txtBloodPressure.Size = new Size(200, 23);
            txtBloodPressure.TabIndex = 5;
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Location = new Point(73, 267);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(74, 15);
            lblTemperature.TabIndex = 6;
            lblTemperature.Text = "Temperatura";
            // 
            // txtTemperature
            // 
            txtTemperature.Location = new Point(203, 263);
            txtTemperature.Name = "txtTemperature";
            txtTemperature.Size = new Size(200, 23);
            txtTemperature.TabIndex = 7;
            // 
            // lblPulse
            // 
            lblPulse.AutoSize = true;
            lblPulse.Location = new Point(73, 307);
            lblPulse.Name = "lblPulse";
            lblPulse.Size = new Size(36, 15);
            lblPulse.TabIndex = 8;
            lblPulse.Text = "Pulso";
            // 
            // txtPulse
            // 
            txtPulse.Location = new Point(203, 303);
            txtPulse.Name = "txtPulse";
            txtPulse.Size = new Size(200, 23);
            txtPulse.TabIndex = 9;
            // 
            // lblOxygenLevel
            // 
            lblOxygenLevel.AutoSize = true;
            lblOxygenLevel.Location = new Point(45, 346);
            lblOxygenLevel.Name = "lblOxygenLevel";
            lblOxygenLevel.Size = new Size(152, 15);
            lblOxygenLevel.TabIndex = 10;
            lblOxygenLevel.Text = "Nivel de Oxígeno en Sangre";
            // 
            // txtOxygenLevel
            // 
            txtOxygenLevel.Location = new Point(203, 343);
            txtOxygenLevel.Name = "txtOxygenLevel";
            txtOxygenLevel.Size = new Size(200, 23);
            txtOxygenLevel.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(203, 387);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 12;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(313, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 77);
            label1.Name = "label1";
            label1.Size = new Size(264, 15);
            label1.TabIndex = 20;
            label1.Text = "Registre los datos medicos tomados del paciente";
            label1.Click += label1_Click;
            // 
            // PatientRegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 548);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtOxygenLevel);
            Controls.Add(lblOxygenLevel);
            Controls.Add(txtPulse);
            Controls.Add(lblPulse);
            Controls.Add(txtTemperature);
            Controls.Add(lblTemperature);
            Controls.Add(txtBloodPressure);
            Controls.Add(lblBloodPressure);
            Controls.Add(txtPatientName);
            Controls.Add(lblPatientName);
            Controls.Add(txtPatientId);
            Controls.Add(lblPatientId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PatientRegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registrar Pacientes";
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private Label label1;
    }
}