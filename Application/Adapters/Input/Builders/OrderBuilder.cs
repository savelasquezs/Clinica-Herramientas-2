using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    public class OrderBuilder
    {
        private OrderValidator orderValidator;

        public OrderBuilder()
        {
            orderValidator = new OrderValidator();
        }

        internal OrderValidator OrderValidator { get => orderValidator; set => orderValidator = value; }

        public Order Create(int orderNumber, DateTime creationDate, List<OrderItem> items)
        {
            return new Order(
                orderValidator.ValidateOrderNumber(orderNumber),
                orderValidator.ValidateCreationDate(creationDate),
                items
            );
        }

        public OrderItem CreateOrderItem(int orderNumber, int itemNumber, decimal cost)
        {
            return new OrderItem(
                orderValidator.ValidateOrderNumber(orderNumber),
                orderValidator.ValidateItemNumber(itemNumber),
                orderValidator.ValidateCost(cost)
            );
        }

        public MedicationOrderItem CreateMedicationOrderItem(int orderNumber, int itemNumber, decimal cost, Medication medication, string dose, int treatmentDuration)
        {
            return new MedicationOrderItem(
                orderValidator.ValidateOrderNumber(orderNumber),
                orderValidator.ValidateItemNumber(itemNumber),
                orderValidator.ValidateCost(cost),
                medication,
                dose,
                treatmentDuration
            );
        }

        public ProcedureOrderItem CreateProcedureOrderItem(int orderNumber, int itemNumber, decimal cost, Procedure procedure, int frequency, bool requiresSpecialist, int? specialistTypeId)
        {
            return new ProcedureOrderItem(
                orderValidator.ValidateOrderNumber(orderNumber),
                orderValidator.ValidateItemNumber(itemNumber),
                orderValidator.ValidateCost(cost),
                procedure,
                frequency,
                requiresSpecialist,
                specialistTypeId
            );
        }

        public DiagnosticAidOrderItem CreateDiagnosticAidOrderItem(int orderNumber, int itemNumber, decimal cost, DiagnosticAid diagnosticAid, int quantity, bool requiresSpecialist, int? specialistTypeId)
        {
            return new DiagnosticAidOrderItem(
                orderValidator.ValidateOrderNumber(orderNumber),
                orderValidator.ValidateItemNumber(itemNumber),
                orderValidator.ValidateCost(cost),
                diagnosticAid,
                quantity,
                requiresSpecialist,
                specialistTypeId
            );
        }
    }
}
