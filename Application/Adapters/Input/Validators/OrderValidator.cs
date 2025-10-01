using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class OrderValidator : SimpleValidator
    {
        public OrderValidator() { }

        public int ValidateOrderNumber(int orderNumber)
        {
            ValidatePositiveInt(orderNumber, "OrderNumber");
            return orderNumber;
        }

        public DateTime ValidateCreationDate(DateTime creationDate)
        {
            ValidateDateNotInFuture(creationDate, "CreationDate");
            return creationDate;
        }

        public int ValidateItemNumber(int itemNumber)
        {
            ValidatePositiveInt(itemNumber, "ItemNumber");
            return itemNumber;
        }

        public decimal ValidateCost(decimal cost)
        {
            ValidateNonNegativeDecimal(cost, "Cost");
            return cost;
        }

        public void ValidateOrderItemConsistency(int orderNumber, int itemOrderNumber)
        {
            if (itemOrderNumber != orderNumber)
            {
                throw new ArgumentException("El ítem no corresponde al número de esta orden.");
            }
        }
    }
}
