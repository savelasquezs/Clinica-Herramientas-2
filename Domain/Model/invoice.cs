using Clinica_Herramientas_2.Domain.Model.Validations;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class Invoice
    {
        private int invoiceNumber;
        private Patient patient;
        private User doctor;
        private DateTime invoiceDate;

        public Invoice(int invoiceNumber, Patient patient, User doctor, DateTime invoiceDate)
        {
            if (invoiceNumber <= 0)
            {
                throw new ArgumentException("InvoiceNumber debe ser mayor que cero.");
            }
            ArgumentNullException.ThrowIfNull(patient);
            ArgumentNullException.ThrowIfNull(doctor);
            if (doctor.Role != Role.Doctor)
            {
                throw new ArgumentException("El usuario asignado no tiene rol de médico.");
            }
            MyDateValidator.ValidateDateNotInFuture(invoiceDate, nameof(invoiceDate));

            this.invoiceNumber = invoiceNumber;
            this.patient = patient;
            this.doctor = doctor;
            this.invoiceDate = invoiceDate;
        }

        public int InvoiceNumber { get => invoiceNumber; private set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; private set => invoiceDate = value; }
        internal Patient Patient { get => patient; private set => patient = value; }
        internal User Doctor { get => doctor; private set => doctor = value; }
    }
}
