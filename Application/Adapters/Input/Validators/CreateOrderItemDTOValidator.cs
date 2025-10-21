using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class CreateOrderItemDTOValidator : SimpleValidator
    {
        public CreateOrderItemDTOValidator() { }

        public int ValidateOrderNumber(int orderNumber)
        {
            ValidatePositiveInt(orderNumber, "OrderNumber");
            return orderNumber;
        }

        public decimal ValidateCost(decimal cost)
        {
            ValidateNonNegativeDecimal(cost, "Cost");
            return cost;
        }

        public string ValidateDose(string dose)
        {
            if (!string.IsNullOrWhiteSpace(dose))
            {
                ValidateStringLength(dose, "Dose", max: 50, min: 1);
            }
            return dose?.Trim() ?? string.Empty;
        }

        public int ValidateTreatmentDuration(int? treatmentDuration)
        {
            if (treatmentDuration.HasValue)
            {
                ValidatePositiveInt(treatmentDuration.Value, "TreatmentDuration");
                return treatmentDuration.Value;
            }
            return 0;
        }

        public int ValidateFrequency(int? frequency)
        {
            if (frequency.HasValue)
            {
                ValidatePositiveInt(frequency.Value, "Frequency");
                return frequency.Value;
            }
            return 0;
        }

        public int ValidateQuantity(int? quantity)
        {
            if (quantity.HasValue)
            {
                ValidatePositiveInt(quantity.Value, "Quantity");
                return quantity.Value;
            }
            return 0;
        }

        public void ValidateSpecialistRequirement(bool? requiresSpecialist, int? specialistTypeId)
        {
            if (requiresSpecialist.HasValue && !requiresSpecialist.Value && specialistTypeId.HasValue)
            {
                throw new ArgumentException("SpecialistTypeId solo aplica cuando RequiresSpecialist es verdadero.");
            }
        }
    }
}
