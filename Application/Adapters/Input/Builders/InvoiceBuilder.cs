using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    internal class InvoiceBuilder
    {
        private InvoiceValidator invoiceValidator;

        public InvoiceBuilder()
        {
            invoiceValidator = new InvoiceValidator();
        }

        internal InvoiceValidator InvoiceValidator { get => invoiceValidator; set => invoiceValidator = value; }

        public Invoice Create(int invoiceNumber, Patient patient, User doctor, DateTime invoiceDate, List<Order> orders)
        {
            invoiceValidator.ValidateDoctorRole(doctor);
            
            return new Invoice(
                invoiceValidator.ValidateInvoiceNumber(invoiceNumber),
                patient,
                doctor,
                invoiceValidator.ValidateInvoiceDate(invoiceDate),
                orders
            );
        }
    }
}
