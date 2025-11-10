using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    partial class PatientViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPatientVitals;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvPatientVitals = new DataGridView();
            colPatientId = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colBloodPressure = new DataGridViewTextBoxColumn();
            colTemperature = new DataGridViewTextBoxColumn();
            colPulse = new DataGridViewTextBoxColumn();
            colOxygen = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
            ((ISupportInitialize)dgvPatientVitals).BeginInit();
            SuspendLayout();
            // 
            // dgvPatientVitals
            // 
            dgvPatientVitals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatientVitals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatientVitals.Columns.AddRange(new DataGridViewColumn[] { colPatientId, colPatientName, colBloodPressure, colTemperature, colPulse, colOxygen });
            dgvPatientVitals.Location = new Point(12, 12);
            dgvPatientVitals.Name = "dgvPatientVitals";
            dgvPatientVitals.ReadOnly = true;
            dgvPatientVitals.RowHeadersVisible = false;
            dgvPatientVitals.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPatientVitals.Size = new Size(603, 380);
            dgvPatientVitals.TabIndex = 0;
            dgvPatientVitals.CellContentClick += dgvPatientVitals_CellContentClick;
            // 
            // colPatientId
            // 
            colPatientId.Name = "colPatientId";
            colPatientId.ReadOnly = true;
            // 
            // colPatientName
            // 
            colPatientName.Name = "colPatientName";
            colPatientName.ReadOnly = true;
            // 
            // colBloodPressure
            // 
            colBloodPressure.Name = "colBloodPressure";
            colBloodPressure.ReadOnly = true;
            // 
            // colTemperature
            // 
            colTemperature.Name = "colTemperature";
            colTemperature.ReadOnly = true;
            // 
            // colPulse
            // 
            colPulse.Name = "colPulse";
            colPulse.ReadOnly = true;
            // 
            // colOxygen
            // 
            colOxygen.Name = "colOxygen";
            colOxygen.ReadOnly = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Location = new Point(672, 405);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Actualizar";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // PatientViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 451);
            Controls.Add(btnRefresh);
            Controls.Add(dgvPatientVitals);
            Name = "PatientViewForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Visualizar Pacientes";
            ((ISupportInitialize)dgvPatientVitals).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn colPatientId;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colBloodPressure;
        private DataGridViewTextBoxColumn colTemperature;
        private DataGridViewTextBoxColumn colPulse;
        private DataGridViewTextBoxColumn colOxygen;
    }
}