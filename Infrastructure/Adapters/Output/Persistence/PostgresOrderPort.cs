using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresOrderPort : IOrderPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresOrderPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public Order FindByOrderNumber(int orderNumber)
        {
            return context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.OrderNumber == orderNumber);
        }
        
        public void Save(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
        
        public void Update(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
        
        public void Delete(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }
        
        public List<Order> FindAll()
        {
            return context.Orders
                .Include(o => o.Items)
                .ToList();
        }
        
        public List<Order> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            return context.Orders
                .Include(o => o.Items)
                .Where(o => o.CreationDate >= startDate && o.CreationDate <= endDate)
                .ToList();
        }
        
        public List<Order> FindByPatient(string patientDni)
        {
            return context.Orders
                .Include(o => o.Items)
                .Where(o => o.Items.Any(i => i.OrderNumber == o.OrderNumber))
                .ToList();
        }
        
        public Order FindByNumber(int orderNumber)
        {
            return FindByOrderNumber(orderNumber);
        }
        
        public List<Order> FindByPatientDni(string patientDni)
        {
            return FindByPatient(patientDni);
        }
        
        public bool ItemExists(int orderNumber, int itemNumber)
        {
            return context.OrderItems
                .Any(i => i.OrderNumber == orderNumber && i.ItemNumber == itemNumber);
        }
        
        public OrderItem Create(CreateOrderItemDTO dto)
        {
            // Esta implementación es básica, debería crear el OrderItem según el tipo
            throw new NotImplementedException("Create method should be implemented based on OrderItem type");
        }
    }
}
