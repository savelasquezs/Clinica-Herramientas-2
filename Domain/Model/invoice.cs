using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class invoice
    {
        private int invoiceNumber;
        private Patient patient;
        private User doctor;
        private DateTime invoiceDate;

        public int InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        internal Patient Patient { get => patient; set => patient = value; }
        internal User Doctor { get => doctor; set => doctor = value; }
    }
}
