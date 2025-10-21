using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class OrderRulesService
    {
        public static void ValidateOrder(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            // Unicidad por itemNumber
            var duplicate = order.Items.GroupBy(i => i.ItemNumber).FirstOrDefault(g => g.Count() > 1);
            if (duplicate != null)
            {
                throw new Exception("No puede existir dos elementos dentro de la misma orden con el mismo ítem.");
            }
            // Exclusividad diagnóstica
            bool hasDiag = order.Items.OfType<DiagnosticAidOrderItem>().Any();
            bool hasMed = order.Items.OfType<MedicationOrderItem>().Any();
            bool hasProc = order.Items.OfType<ProcedureOrderItem>().Any();
            if (hasDiag && (hasMed || hasProc))
            {
                throw new Exception("Cuando se receta una ayuda diagnóstica no puede recetarse medicamento ni procedimiento.");
            }
            // Todos los items deben referenciar el mismo número de orden
            foreach (var item in order.Items)
            {
                if (item.OrderNumber != order.OrderNumber)
                {
                    throw new Exception("Todos los ítems deben referenciar el mismo número de orden.");
                }
            }
        }
    }
}

