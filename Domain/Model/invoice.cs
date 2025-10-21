namespace Clinica_Herramientas_2.Domain.Model
{
    public class Invoice
    {
        private int invoiceNumber;
        private Patient patient;
        private User doctor;
        private DateTime invoiceDate;
        private List<Order> orders;
        private decimal totalAmount;
        private decimal copaymentAmount;
        private decimal insuranceAmount;
        private decimal annualCopaymentAccumulated;

        public Invoice(int invoiceNumber, Patient patient, User doctor, DateTime invoiceDate, List<Order> orders)
        {
            ArgumentNullException.ThrowIfNull(patient);
            ArgumentNullException.ThrowIfNull(doctor);
            if (doctor.Role != Role.Doctor)
            {
                throw new ArgumentException("El usuario asignado no tiene rol de médico.");
            }
            ArgumentNullException.ThrowIfNull(orders);

            this.invoiceNumber = invoiceNumber;
            this.patient = patient;
            this.doctor = doctor;
            this.invoiceDate = invoiceDate;
            this.orders = orders;
            this.totalAmount = 0;
            this.copaymentAmount = 0;
            this.insuranceAmount = 0;
            this.annualCopaymentAccumulated = 0;
        }

        // Constructor protegido para EF Core
        protected Invoice() { }

        public int InvoiceNumber { get => invoiceNumber; private set => invoiceNumber = value; }
        public DateTime InvoiceDate { get => invoiceDate; private set => invoiceDate = value; }
        internal Patient Patient { get => patient; private set => patient = value; }
        internal User Doctor { get => doctor; private set => doctor = value; }
        internal List<Order> Orders { get => orders; private set => orders = value; }
        public decimal TotalAmount { get => totalAmount; private set => totalAmount = value; }
        public decimal CopaymentAmount { get => copaymentAmount; private set => copaymentAmount = value; }
        public decimal InsuranceAmount { get => insuranceAmount; private set => insuranceAmount = value; }
        public decimal AnnualCopaymentAccumulated { get => annualCopaymentAccumulated; private set => annualCopaymentAccumulated = value; }

        internal void SetBillingAmounts(decimal copaymentAmount, decimal insuranceAmount, decimal annualCopaymentAccumulated)
        {
            this.copaymentAmount = copaymentAmount;
            this.insuranceAmount = insuranceAmount;
            this.annualCopaymentAccumulated = annualCopaymentAccumulated;
        }

        internal void CalculateTotalAmount()
        {
            this.totalAmount = orders.Sum(static o => { Func<OrderItem, decimal> selector = i => i.Cost; return o.Items.Sum(selector); });
        }
    }
}
