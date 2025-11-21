using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class PatientRegisterForm : Form
    {
        private readonly NurseInputs? nurseInputs;
        private readonly User? currentUser;

        public PatientRegisterForm(NurseInputs? nurseInputs = null, User? currentUser = null)
        {
            this.nurseInputs = nurseInputs;
            this.currentUser = currentUser;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(txtPatientId.Text) ||
                    string.IsNullOrWhiteSpace(txtPatientName.Text) ||
                    string.IsNullOrWhiteSpace(txtBloodPressure.Text) ||
                    string.IsNullOrWhiteSpace(txtTemperature.Text) ||
                    string.IsNullOrWhiteSpace(txtPulse.Text) ||
                    string.IsNullOrWhiteSpace(txtOxygenLevel.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos requeridos", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar valores numéricos
                if (!double.TryParse(txtTemperature.Text, out double temperature))
                {
                    MessageBox.Show("Por favor ingrese un valor numérico válido para la temperatura", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPulse.Text, out int pulse))
                {
                    MessageBox.Show("Por favor ingrese un valor numérico válido para el pulso", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtOxygenLevel.Text, out int oxygenLevel))
                {
                    MessageBox.Show("Por favor ingrese un valor numérico válido para el nivel de oxígeno", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar rangos razonables
                if (temperature < 30 || temperature > 45)
                {
                    MessageBox.Show("La temperatura debe estar entre 30 y 45 grados", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pulse < 30 || pulse > 200)
                {
                    MessageBox.Show("El pulso debe estar entre 30 y 200 bpm", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (oxygenLevel < 0 || oxygenLevel > 100)
                {
                    MessageBox.Show("El nivel de oxígeno debe estar entre 0 y 100%", "Error de validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear y guardar el registro de signos vitales
                var record = new PatientVitalRecord
                {
                    PatientId = txtPatientId.Text.Trim(),
                    PatientName = txtPatientName.Text.Trim(),
                    BloodPressure = txtBloodPressure.Text.Trim(),
                    Temperature = temperature.ToString("F1"),
                    Pulse = pulse.ToString(),
                    OxygenLevel = oxygenLevel.ToString(),
                    CreatedAt = DateTime.Now
                };

                NurseDataStore.AddRecord(record);

                MessageBox.Show("Signos vitales registrados exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los signos vitales: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Evento vacío, solo para evitar errores
        }
    }
}
