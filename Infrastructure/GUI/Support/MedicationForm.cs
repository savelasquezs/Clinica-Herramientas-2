using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class MedicationForm : Form
    {
        private readonly SupportInputs supportInputs;
        private readonly Medication? existingMedication;

        public MedicationForm(SupportInputs supportInputs, Medication? existingMedication = null)
        {
            this.supportInputs = supportInputs;
            this.existingMedication = existingMedication;
            InitializeComponent();
            if (existingMedication != null)
            {
                LoadMedicationData();
            }
        }

        private void LoadMedicationData()
        {
            if (existingMedication == null) return;
            txtId.Text = existingMedication.Id.ToString();
            txtId.ReadOnly = true;
            txtId.BackColor = System.Drawing.Color.LightGray;
            txtName.Text = existingMedication.Name;
            txtCost.Text = existingMedication.Cost.ToString();
            txtDose.Text = existingMedication.Dose;
            txtDuration.Text = existingMedication.TreatmentDuration.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtCost.Text) || string.IsNullOrWhiteSpace(txtDose.Text) ||
                    string.IsNullOrWhiteSpace(txtDuration.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID debe ser un número válido", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtCost.Text, out decimal cost) || cost < 0)
                {
                    MessageBox.Show("El costo debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDuration.Text, out int duration) || duration <= 0)
                {
                    MessageBox.Show("La duración debe ser un número válido mayor a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (existingMedication == null)
                {
                    supportInputs.CreateMedication(id, txtName.Text.Trim(), cost, txtDose.Text.Trim(), duration);
                    MessageBox.Show("Medicamento creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var medication = new Medication(id, txtName.Text.Trim(), cost, txtDose.Text.Trim(), duration);
                    supportInputs.UpdateMedication(medication);
                    MessageBox.Show("Medicamento actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}

