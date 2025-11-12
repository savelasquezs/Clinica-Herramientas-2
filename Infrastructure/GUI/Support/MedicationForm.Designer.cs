namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    partial class MedicationForm
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
            this.grpMedication = new System.Windows.Forms.GroupBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtDose = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblDose = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpMedication.SuspendLayout();
            this.SuspendLayout();
            
            this.grpMedication.Controls.Add(this.txtDuration);
            this.grpMedication.Controls.Add(this.txtDose);
            this.grpMedication.Controls.Add(this.txtCost);
            this.grpMedication.Controls.Add(this.txtName);
            this.grpMedication.Controls.Add(this.txtId);
            this.grpMedication.Controls.Add(this.lblDuration);
            this.grpMedication.Controls.Add(this.lblDose);
            this.grpMedication.Controls.Add(this.lblCost);
            this.grpMedication.Controls.Add(this.lblName);
            this.grpMedication.Controls.Add(this.lblId);
            this.grpMedication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.grpMedication.Location = new System.Drawing.Point(20, 20);
            this.grpMedication.Name = "grpMedication";
            this.grpMedication.Size = new System.Drawing.Size(600, 250);
            this.grpMedication.TabIndex = 0;
            this.grpMedication.TabStop = false;
            this.grpMedication.Text = "Información del Medicamento";
            
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblId.Location = new System.Drawing.Point(20, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(24, 15);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtId.Location = new System.Drawing.Point(50, 27);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 21);
            this.txtId.TabIndex = 1;
            
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblName.Location = new System.Drawing.Point(170, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 15);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nombre:";
            
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtName.Location = new System.Drawing.Point(231, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 21);
            this.txtName.TabIndex = 3;
            
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCost.Location = new System.Drawing.Point(20, 70);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(42, 15);
            this.lblCost.TabIndex = 4;
            this.lblCost.Text = "Costo:";
            
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCost.Location = new System.Drawing.Point(68, 67);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(150, 21);
            this.txtCost.TabIndex = 5;
            
            this.lblDose.AutoSize = true;
            this.lblDose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDose.Location = new System.Drawing.Point(240, 70);
            this.lblDose.Name = "lblDose";
            this.lblDose.Size = new System.Drawing.Size(40, 15);
            this.lblDose.TabIndex = 6;
            this.lblDose.Text = "Dosis:";
            
            this.txtDose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDose.Location = new System.Drawing.Point(286, 67);
            this.txtDose.Name = "txtDose";
            this.txtDose.Size = new System.Drawing.Size(200, 21);
            this.txtDose.TabIndex = 7;
            
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDuration.Location = new System.Drawing.Point(20, 110);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(120, 15);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Duración (días):";
            
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDuration.Location = new System.Drawing.Point(146, 107);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 21);
            this.txtDuration.TabIndex = 9;
            
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(400, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(520, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpMedication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MedicationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Medicamento";
            this.grpMedication.ResumeLayout(false);
            this.grpMedication.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox grpMedication;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblDose;
        private System.Windows.Forms.TextBox txtDose;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}

