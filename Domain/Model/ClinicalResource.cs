using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
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
        
        public ClinicalResource(int id, string name, decimal cost)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id debe ser mayor que cero.");
            }
            MyStringValidator.ValidateStringLength(name, nameof(Name), max: 200, min: 1);
            if (cost < 0)
            {
                throw new ArgumentException("Cost no puede ser negativo.");
            }
            this.id = id;
            this.name = name.Trim();
            this.cost = cost;
        }

        public int Id { get => id; private set => id = value; }
        public string Name { get => name; private set => name = value; }
        public decimal Cost { get => cost; private set => cost = value; }
    }

    internal class Medication : ClinicalResource
    {
        private string dose;
        private int treatmentDuration;
        
        public Medication(int id, string name, decimal cost, string defaultDose, int treatmentDurationDays)
            : base(id, name, cost)
        {
            MyStringValidator.ValidateStringLength(defaultDose, nameof(Dose), max: 50, min: 1);
            if (treatmentDurationDays <= 0)
            {
                throw new ArgumentException("TreatmentDuration debe ser mayor que cero.");
            }
            dose = defaultDose.Trim();
            treatmentDuration = treatmentDurationDays;
        }

        public string Dose { get => dose; private set => dose = value; }
        public int TreatmentDuration { get => treatmentDuration; private set => treatmentDuration = value; }
    }
    internal class Procedure : ClinicalResource
    {
        private int frequency;
        private bool requiresSpecialist;
        private int? specialistTypeId;
        
        public Procedure(int id, string name, decimal cost, int frequency, bool requiresSpecialist, int? specialistTypeId)
            : base(id, name, cost)
        {
            if (frequency <= 0)
            {
                throw new ArgumentException("Frequency debe ser mayor que cero.");
            }
            if (!requiresSpecialist && specialistTypeId.HasValue)
            {
                throw new ArgumentException("SpecialistTypeId solo aplica cuando RequiresSpecialist es verdadero.");
            }
            this.frequency = frequency;
            this.requiresSpecialist = requiresSpecialist;
            this.specialistTypeId = specialistTypeId;
        }

        public int Frequency { get => frequency; private set => frequency = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; private set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; private set => specialistTypeId = value; }
    }
    internal class DiagnosticAid : ClinicalResource
    {
        private int quantity;
        private bool requiresSpecialist;
        private int? specialistTypeId;
        
        public DiagnosticAid(int id, string name, decimal cost, int quantity, bool requiresSpecialist, int? specialistTypeId)
            : base(id, name, cost)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity debe ser mayor que cero.");
            }
            if (!requiresSpecialist && specialistTypeId.HasValue)
            {
                throw new ArgumentException("SpecialistTypeId solo aplica cuando RequiresSpecialist es verdadero.");
            }
            this.quantity = quantity;
            this.requiresSpecialist = requiresSpecialist;
            this.specialistTypeId = specialistTypeId;
        }

        public int Quantity { get => quantity; private set => quantity = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; private set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; private set => specialistTypeId = value; }
    }
}
