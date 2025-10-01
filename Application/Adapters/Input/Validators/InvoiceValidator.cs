using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class InvoiceValidator : SimpleValidator
    {
        public InvoiceValidator() { }

        public int ValidateInvoiceNumber(int invoiceNumber)
        {
            ValidatePositiveInt(invoiceNumber, "InvoiceNumber");
            return invoiceNumber;
        }

        public DateTime ValidateInvoiceDate(DateTime invoiceDate)
        {
            ValidateDateNotInFuture(invoiceDate, "InvoiceDate");
            return invoiceDate;
        }

        public void ValidateDoctorRole(object doctor)
        {
            // Esta validación se manejará en el dominio ya que requiere acceso al enum Role
            // Solo validamos que no sea null
            ValidateNotNull(doctor, "Doctor");
        }
    }
}
