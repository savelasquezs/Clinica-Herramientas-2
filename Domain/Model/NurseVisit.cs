using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class NurseVisit:PerformedProcedure
    {
        private User nurse;
        private VitalData vitalData;
        private List<AdministeredMedication> administeredMedications;
        private DateTime visitTime;

        public DateTime VisitTime { get => visitTime; set => visitTime = value; }
        internal User Nurse { get => nurse; set => nurse = value; }
        internal VitalData VitalData { get => vitalData; set => vitalData = value; }
        internal List<AdministeredMedication> AdministeredMedications { get => administeredMedications; set => administeredMedications = value; }
    }
    internal class VitalData
    {
        private string _bloodPressure;
        private double _temperature;
        private int _pulse;
        private int _oxygenLevel;

        public string BloodPressure { get => _bloodPressure; set => _bloodPressure = value; }
        public double Temperature { get => _temperature; set => _temperature = value; }
        public int Pulse { get => _pulse; set => _pulse = value; }
        public int OxygenLevel { get => _oxygenLevel; set => _oxygenLevel = value; }
    }
}
