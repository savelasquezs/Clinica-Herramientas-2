
using Clinica_Herramientas_2.Domain.Model.Validations;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class NurseVisit:PerformedProcedure
    {
        private User nurse;
        private Patient patient;
        private VitalData vitalData;
        private List<AdministeredMedication> administeredMedications;
        private DateTime visitTime;

        public NurseVisit(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt,
            User nurse, VitalData vitalData, List<AdministeredMedication> administeredMedications, DateTime visitTime, Patient patient)
            : base(orderItem, testsPerformed, notes, performedAt)
        {
            ArgumentNullException.ThrowIfNull(nurse);
            if (nurse.Role != Role.Nurse)
            {
                throw new ArgumentException("El usuario asignado no tiene rol de enfermera.");
            }
            ArgumentNullException.ThrowIfNull(vitalData);
            MyDateValidator.ValidateDateNotInFuture(visitTime, nameof(VisitTime));

            this.nurse = nurse;
            this.patient = patient;
            this.vitalData = vitalData;
            this.administeredMedications = administeredMedications ?? [];
            if (this.administeredMedications.Any(m => m == null))
            {
                throw new ArgumentException("La lista de medicamentos administrados contiene elementos nulos.");
            }
            this.visitTime = visitTime;
            this.OrderItem = orderItem; 
        }

        public DateTime VisitTime { get => visitTime; private set => visitTime = value; }
        public OrderItem OrderItem { get; internal set; }
        internal Patient Patient { get => patient; private set => patient = value; }
        internal User Nurse { get => nurse; private set => nurse = value; }
        internal VitalData VitalData { get => vitalData; private set => vitalData = value; }
        internal List<AdministeredMedication> AdministeredMedications { get => administeredMedications; private set => administeredMedications = value; }
    }
    internal class VitalData
    {
        private string _bloodPressure;
        private double _temperature;
        private int _pulse;
        private int _oxygenLevel;
        
        public VitalData(string bloodPressure, double temperature, int pulse, int oxygenLevel)
        {
            // Presión arterial en formato "SYS/DIA" con valores razonables
            MyStringValidator.ValidateStringNotEmpty(bloodPressure, nameof(BloodPressure));
            var parts = bloodPressure.Split('/');
            if (parts.Length != 2 || !int.TryParse(parts[0], out var sys) || !int.TryParse(parts[1], out var dia) || sys < 50 || sys > 250 || dia < 30 || dia > 150)
            {
                throw new ArgumentException("BloodPressure debe tener formato SYS/DIA con valores válidos.");
            }
            _bloodPressure = bloodPressure;

            // Temperatura en °C (rango clínico común 30..45)
            if (temperature < 30 || temperature > 45)
            {
                throw new ArgumentException("Temperature debe estar entre 30 y 45 °C.");
            }
            _temperature = temperature;

            // Pulso (30..220)
            if (pulse < 30 || pulse > 220)
            {
                throw new ArgumentException("Pulse debe estar entre 30 y 220.");
            }
            _pulse = pulse;

            // Oxígeno (0..100)
            if (oxygenLevel < 0 || oxygenLevel > 100)
            {
                throw new ArgumentException("OxygenLevel debe estar entre 0 y 100.");
            }
            _oxygenLevel = oxygenLevel;
        }

        public string BloodPressure { get => _bloodPressure; private set => _bloodPressure = value; }
        public double Temperature { get => _temperature; private set => _temperature = value; }
        public int Pulse { get => _pulse; private set => _pulse = value; }
        public int OxygenLevel { get => _oxygenLevel; private set => _oxygenLevel = value; }
    }
}
