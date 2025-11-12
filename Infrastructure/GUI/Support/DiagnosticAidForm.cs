using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class DiagnosticAidForm : Form
    {
        private readonly SupportInputs supportInputs;
        private readonly DiagnosticAid? existingDiagnosticAid;

        public DiagnosticAidForm(SupportInputs supportInputs, DiagnosticAid? existingDiagnosticAid = null)
        {
            this.supportInputs = supportInputs;
            this.existingDiagnosticAid = existingDiagnosticAid;
            InitializeComponent();
            if (existingDiagnosticAid != null) LoadDiagnosticAidData();
        }

        private void LoadDiagnosticAidData()
        {
            if (existingDiagnosticAid == null) return;
            txtId.Text = existingDiagnosticAid.Id.ToString();
            txtId.ReadOnly = true;
            txtId.BackColor = System.Drawing.Color.LightGray;
            txtName.Text = existingDiagnosticAid.Name;
            txtCost.Text = existingDiagnosticAid.Cost.ToString();
            txtQuantity.Text = existingDiagnosticAid.Quantity.ToString();
            chkRequiresSpecialist.Checked = existingDiagnosticAid.RequiresSpecialist;
            if (existingDiagnosticAid.SpecialistTypeId.HasValue)
                txtSpecialistTypeId.Text = existingDiagnosticAid.SpecialistTypeId.Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtCost.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos requeridos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtId.Text, out int id) || !decimal.TryParse(txtCost.Text, out decimal cost) || cost < 0 ||
                    !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Por favor ingrese valores numéricos válidos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? specialistTypeId = null;
                if (chkRequiresSpecialist.Checked && !string.IsNullOrWhiteSpace(txtSpecialistTypeId.Text))
                {
                    if (int.TryParse(txtSpecialistTypeId.Text, out int specId))
                        specialistTypeId = specId;
                }

                if (existingDiagnosticAid == null)
                {
                    supportInputs.CreateDiagnosticAid(id, txtName.Text.Trim(), cost, quantity, chkRequiresSpecialist.Checked, specialistTypeId);
                    MessageBox.Show("Ayuda diagnóstica creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var diagnosticAid = new DiagnosticAid(id, txtName.Text.Trim(), cost, quantity, chkRequiresSpecialist.Checked, specialistTypeId);
                    supportInputs.UpdateDiagnosticAid(diagnosticAid);
                    MessageBox.Show("Ayuda diagnóstica actualizada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkRequiresSpecialist_CheckedChanged(object sender, EventArgs e)
        {
            txtSpecialistTypeId.Enabled = chkRequiresSpecialist.Checked;
        }
    }
}

