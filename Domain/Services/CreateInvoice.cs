using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class CreateInvoice(IInvoicePort invoicePort, IPatientPort patientPort, IUserPort userPort, IOrderPort orderPort, BillingRulesService billingRulesService)
    {
        private readonly IInvoicePort invoicePort = invoicePort;
        private readonly IPatientPort patientPort = patientPort;
        private readonly IUserPort userPort = userPort;
        private readonly IOrderPort orderPort = orderPort;
        private readonly BillingRulesService billingRulesService = billingRulesService;

        public Invoice Create(int invoiceNumber, string patientDni, string doctorDni, List<int> orderNumbers, DateTime invoiceDate)
        {
          
            var existingPatient = patientPort.FindByDocument(patientDni) ?? throw new Exception("El paciente no existe.");

            // Validar que el doctor existe y tiene rol correcto
           
            var existingDoctor = userPort.FindByDocument(doctorDni) ?? throw new Exception("El médico no existe.");
            if (existingDoctor.Role != Role.Doctor)
            {
                throw new Exception("El usuario no tiene rol de médico.");
            }

            // Validar y obtener las órdenes
            var orders = new List<Order>();
            foreach (var orderNumber in orderNumbers)
            {
                var order = orderPort.FindByNumber(orderNumber) ?? throw new Exception($"La orden {orderNumber} no existe.");
                orders.Add(order);
            }

            // Crear la factura
            var invoice = new Invoice(invoiceNumber, existingPatient, existingDoctor, invoiceDate, orders);

            // Calcular el copago acumulado anual
            var currentYear = invoiceDate.Year;
            var annualCopaymentAccumulated = invoicePort.GetAnnualCopaymentAccumulated(patientDni, currentYear);

            // Calcular la facturación según las reglas de negocio
            var billingResult = BillingRulesService.CalculateBilling(existingPatient, invoice.TotalAmount, annualCopaymentAccumulated);
            
            // Aplicar los resultados al modelo
            invoice.SetBillingAmounts(billingResult.CopaymentAmount, billingResult.InsuranceAmount, billingResult.AnnualCopaymentAccumulated);

            // Actualizar el copago acumulado anual
            var newAccumulated = annualCopaymentAccumulated + billingResult.CopaymentAmount;
            invoicePort.UpdateAnnualCopaymentAccumulated(patientDni, currentYear, newAccumulated);

            // Guardar la factura
            invoicePort.Save(invoice);

            return invoice;
        }
    }
}
