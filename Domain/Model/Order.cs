using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
  
    internal class Order(int orderNumber, DateTime creationDate, List<OrderItem> items)
    {
        private int orderNumber = orderNumber;
        private DateTime creationDate = creationDate;
        private List<OrderItem> items = items;

        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        internal List<OrderItem> Items { get => items; set => items = value; }
    }
}
