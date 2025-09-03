using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
  
    internal class Order
    {
        private int orderNumber;
        private DateTime creationDate;
        private List<OrderItem> items;
        
       


        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        internal List<OrderItem> Items { get => items; set => items = value; }
    }
}
