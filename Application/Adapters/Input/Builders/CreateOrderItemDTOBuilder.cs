using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    public class CreateOrderItemDTOBuilder
    {
        private CreateOrderItemDTOValidator createOrderItemDTOValidator;

        public CreateOrderItemDTOBuilder()
        {
            createOrderItemDTOValidator = new CreateOrderItemDTOValidator();
        }

        internal CreateOrderItemDTOValidator CreateOrderItemDTOValidator { get => createOrderItemDTOValidator; set => createOrderItemDTOValidator = value; }

        public CreateOrderItemDTO Create(int orderNumber, decimal cost, OrderItemType itemType)
        {
            return new CreateOrderItemDTO
            {
                OrderNumber = createOrderItemDTOValidator.ValidateOrderNumber(orderNumber),
                Cost = createOrderItemDTOValidator.ValidateCost(cost),
                ItemType = itemType
            };
        }

        public CreateOrderItemDTO CreateMedication(int orderNumber, decimal cost, int medicationId, string dose, int treatmentDuration)
        {
            return new CreateOrderItemDTO
            {
                OrderNumber = createOrderItemDTOValidator.ValidateOrderNumber(orderNumber),
                Cost = createOrderItemDTOValidator.ValidateCost(cost),
                ItemType = OrderItemType.Medication,
                MedicationId = medicationId,
                Dose = createOrderItemDTOValidator.ValidateDose(dose),
                TreatmentDuration = createOrderItemDTOValidator.ValidateTreatmentDuration(treatmentDuration)
            };
        }

        public CreateOrderItemDTO CreateProcedure(int orderNumber, decimal cost, int procedureId, int frequency, bool requiresSpecialist, int? specialistTypeId)
        {
            createOrderItemDTOValidator.ValidateSpecialistRequirement(requiresSpecialist, specialistTypeId);

            return new CreateOrderItemDTO
            {
                OrderNumber = createOrderItemDTOValidator.ValidateOrderNumber(orderNumber),
                Cost = createOrderItemDTOValidator.ValidateCost(cost),
                ItemType = OrderItemType.Procedure,
                ProcedureId = procedureId,
                Frequency = createOrderItemDTOValidator.ValidateFrequency(frequency),
                RequiresSpecialist = requiresSpecialist,
                SpecialistTypeId = specialistTypeId
            };
        }

        public CreateOrderItemDTO CreateDiagnosticAid(int orderNumber, decimal cost, int diagnosticAidId, int quantity, bool requiresSpecialist, int? specialistTypeId)
        {
            createOrderItemDTOValidator.ValidateSpecialistRequirement(requiresSpecialist, specialistTypeId);

            return new CreateOrderItemDTO
            {
                OrderNumber = createOrderItemDTOValidator.ValidateOrderNumber(orderNumber),
                Cost = createOrderItemDTOValidator.ValidateCost(cost),
                ItemType = OrderItemType.DiagnosticAid,
                DiagnosticAidId = diagnosticAidId,
                Quantity = createOrderItemDTOValidator.ValidateQuantity(quantity),
                RequiresSpecialist = requiresSpecialist,
                SpecialistTypeId = specialistTypeId
            };
        }
    }
}
