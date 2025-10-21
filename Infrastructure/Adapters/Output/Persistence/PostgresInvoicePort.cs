using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresInvoicePort : IInvoicePort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresInvoicePort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public Invoice FindByInvoiceNumber(int invoiceNumber)
        {
            return context.Invoices
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Orders)
                .FirstOrDefault(i => i.InvoiceNumber == invoiceNumber);
        }
        
        public void Save(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
        }
        
        public void Update(Invoice invoice)
        {
            context.Invoices.Update(invoice);
            context.SaveChanges();
        }
        
        public void Delete(Invoice invoice)
        {
            context.Invoices.Remove(invoice);
            context.SaveChanges();
        }
        
        public List<Invoice> FindAll()
        {
            return context.Invoices
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Orders)
                .ToList();
        }
        
        public List<Invoice> FindByPatient(string patientDni)
        {
            return context.Invoices
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Orders)
                .Where(i => i.Patient.Dni == patientDni)
                .ToList();
        }
        
        public List<Invoice> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            return context.Invoices
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .Include(i => i.Orders)
                .Where(i => i.InvoiceDate >= startDate && i.InvoiceDate <= endDate)
                .ToList();
        }
        
        public Invoice FindByNumber(int invoiceNumber)
        {
            return FindByInvoiceNumber(invoiceNumber);
        }
        
        public decimal GetAnnualCopaymentAccumulated(string patientDni, int year)
        {
            // Por ahora retornamos 0, esto debería implementarse con una tabla de acumulados anuales
            return 0;
        }
        
        public void UpdateAnnualCopaymentAccumulated(string patientDni, int year, decimal newAmount)
        {
            // Por ahora no implementamos nada, esto debería actualizar una tabla de acumulados anuales
        }
    }
}
