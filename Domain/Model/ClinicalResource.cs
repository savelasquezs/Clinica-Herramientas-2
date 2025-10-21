using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Clinica_Herramientas_2.Domain.Model
{
    public class ClinicalResource
    {
        private int id;
        private string name;
        private decimal cost;
        
        public ClinicalResource(int id, string name, decimal cost)
        {
            this.id = id;
            this.name = name.Trim();
            this.cost = cost;
        }

        // Constructor protegido para EF Core
        protected ClinicalResource() { }

        public int Id { get => id; private set => id = value; }
        public string Name { get => name; private set => name = value; }
        public decimal Cost { get => cost; private set => cost = value; }
    }

    public class Medication : ClinicalResource
    {
        private string dose;
        private int treatmentDuration;
        
        public Medication(int id, string name, decimal cost, string defaultDose, int treatmentDurationDays)
            : base(id, name, cost)
        {
            dose = defaultDose.Trim();
            treatmentDuration = treatmentDurationDays;
        }

        // Constructor protegido para EF Core
        protected Medication() { }

        public string Dose { get => dose; private set => dose = value; }
        public int TreatmentDuration { get => treatmentDuration; private set => treatmentDuration = value; }
    }
    public class Procedure : ClinicalResource
    {
        private int frequency;
        private bool requiresSpecialist;
        private int? specialistTypeId;
        
        public Procedure(int id, string name, decimal cost, int frequency, bool requiresSpecialist, int? specialistTypeId)
            : base(id, name, cost)
        {
            this.frequency = frequency;
            this.requiresSpecialist = requiresSpecialist;
            this.specialistTypeId = specialistTypeId;
        }

        // Constructor protegido para EF Core
        protected Procedure() { }

        public int Frequency { get => frequency; private set => frequency = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; private set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; private set => specialistTypeId = value; }
    }
    public class DiagnosticAid : ClinicalResource
    {
        private int quantity;
        private bool requiresSpecialist;
        private int? specialistTypeId;
        
        public DiagnosticAid(int id, string name, decimal cost, int quantity, bool requiresSpecialist, int? specialistTypeId)
            : base(id, name, cost)
        {
            this.quantity = quantity;
            this.requiresSpecialist = requiresSpecialist;
            this.specialistTypeId = specialistTypeId;
        }

        // Constructor protegido para EF Core
        protected DiagnosticAid() { }

        public int Quantity { get => quantity; private set => quantity = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; private set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; private set => specialistTypeId = value; }
    }
}
