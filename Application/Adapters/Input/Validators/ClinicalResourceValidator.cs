using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class ClinicalResourceValidator : SimpleValidator
    {
        public ClinicalResourceValidator() { }

        public int ValidateId(int id)
        {
            ValidatePositiveInt(id, "Id");
            return id;
        }

        public string ValidateName(string name)
        {
            ValidateStringLength(name, "Name", max: 200, min: 1);
            return name.Trim();
        }

        public decimal ValidateCost(decimal cost)
        {
            ValidateNonNegativeDecimal(cost, "Cost");
            return cost;
        }

        public string ValidateDose(string dose)
        {
            ValidateStringLength(dose, "Dose", max: 50, min: 1);
            return dose.Trim();
        }

        public int ValidateTreatmentDuration(int treatmentDuration)
        {
            ValidatePositiveInt(treatmentDuration, "TreatmentDuration");
            return treatmentDuration;
        }

        public int ValidateFrequency(int frequency)
        {
            ValidatePositiveInt(frequency, "Frequency");
            return frequency;
        }

        public int ValidateQuantity(int quantity)
        {
            ValidatePositiveInt(quantity, "Quantity");
            return quantity;
        }

        public void ValidateSpecialistRequirement(bool requiresSpecialist, int? specialistTypeId)
        {
            if (!requiresSpecialist && specialistTypeId.HasValue)
            {
                throw new ArgumentException("SpecialistTypeId solo aplica cuando RequiresSpecialist es verdadero.");
            }
        }
    }
}
