using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class ClinicalResource
    {
        private int id;
        private string name;
        private decimal cost;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Cost { get => cost; set => cost = value; }
    }

    internal class Medications : ClinicalResource
    {
        private Medications medication;
        private string dose;
        private int treatmentDuration;

        public string Dose { get => dose; set => dose = value; }
        public int TreatmentDuration { get => treatmentDuration; set => treatmentDuration = value; }
        internal Medications Medication { get => medication; set => medication = value; }
    }
    internal class Procedures : ClinicalResource
    {
        private Procedures procedure;
        private int frequency;
        private bool requiresSpecialist;
        private int? specialistTypeId;

        public int Frequency { get => frequency; set => frequency = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; set => specialistTypeId = value; }
        internal Procedures Procedure { get => procedure; set => procedure = value; }
    }
    internal class DiagnosticsAid : ClinicalResource
    {
        private DiagnosticsAid diagnosticAid;
        private int quantity;
        private bool requiresSpecialist;
        private int? specialistTypeId;

        public int Quantity { get => quantity; set => quantity = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; set => specialistTypeId = value; }
        internal DiagnosticsAid DiagnosticAid { get => diagnosticAid; set => diagnosticAid = value; }
    }
}
