using System;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public class PatientVitalRecord
    {
        public string PatientId { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string BloodPressure { get; set; } = string.Empty;
        public string Temperature { get; set; } = string.Empty;
        public string Pulse { get; set; } = string.Empty;
        public string OxygenLevel { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
