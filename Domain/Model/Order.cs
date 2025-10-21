using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Clinica_Herramientas_2.Domain.Model
{
  


public class Order
    {
        private int orderNumber;
        private DateTime creationDate;
        private List<OrderItem> items;

        public Order(int orderNumber, DateTime creationDate, List<OrderItem> items)
        {
            if (items != null && items.Any(i => i == null))
            {
                throw new ArgumentException("La lista de items contiene elementos nulos.");
            }

            this.orderNumber = orderNumber;
            this.creationDate = creationDate;
            this.items = items ?? [];

            // Reglas cross-item se validarán en el servicio de reglas.
        }

        // Constructor protegido para EF Core
        protected Order() { }

        public int OrderNumber { get => orderNumber; private set => orderNumber = value; }
        public DateTime CreationDate { get => creationDate; private set => creationDate = value; }
        internal List<OrderItem> Items { get => items; private set => items = value; }

        internal void AddItem(OrderItem item)
        {
           ArgumentNullException.ThrowIfNull(item);
            if (item.OrderNumber != this.orderNumber)
            {
                throw new ArgumentException("El ítem no corresponde al número de esta orden.");
            }
            this.items.Add(item);
        }
    
       

            // Reglas cross-item se validarán en el servicio de reglas.
        


        
    }
}
