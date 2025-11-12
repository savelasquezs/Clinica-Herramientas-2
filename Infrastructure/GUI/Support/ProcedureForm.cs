using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class ProcedureForm : Form
    {
        private readonly SupportInputs supportInputs;
        private readonly Procedure? existingProcedure;

        public ProcedureForm(SupportInputs supportInputs, Procedure? existingProcedure = null)
        {
            this.supportInputs = supportInputs;
            this.existingProcedure = existingProcedure;
            InitializeComponent();
            if (existingProcedure != null) LoadProcedureData();
        }

        private void LoadProcedureData()
        {
            if (existingProcedure == null) return;
            txtId.Text = existingProcedure.Id.ToString();
            txtId.ReadOnly = true;
            txtId.BackColor = System.Drawing.Color.LightGray;
            txtName.Text = existingProcedure.Name;
            txtCost.Text = existingProcedure.Cost.ToString();
            txtFrequency.Text = existingProcedure.Frequency.ToString();
            chkRequiresSpecialist.Checked = existingProcedure.RequiresSpecialist;
            if (existingProcedure.SpecialistTypeId.HasValue)
                txtSpecialistTypeId.Text = existingProcedure.SpecialistTypeId.Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtCost.Text) || string.IsNullOrWhiteSpace(txtFrequency.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos requeridos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtId.Text, out int id) || !decimal.TryParse(txtCost.Text, out decimal cost) || cost < 0 ||
                    !int.TryParse(txtFrequency.Text, out int frequency) || frequency <= 0)
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

                if (existingProcedure == null)
                {
                    supportInputs.CreateProcedure(id, txtName.Text.Trim(), cost, frequency, chkRequiresSpecialist.Checked, specialistTypeId);
                    MessageBox.Show("Procedimiento creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var procedure = new Procedure(id, txtName.Text.Trim(), cost, frequency, chkRequiresSpecialist.Checked, specialistTypeId);
                    supportInputs.UpdateProcedure(procedure);
                    MessageBox.Show("Procedimiento actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

