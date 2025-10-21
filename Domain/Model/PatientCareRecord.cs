

namespace Clinica_Herramientas_2.Domain.Model
{
    public class PatientCareRecord
    {
        private int id;
        private readonly OrderItem orderItem;
        private readonly string testsPerformed;
        private readonly string notes;
        private readonly DateTime performedAt;
        
        public PatientCareRecord(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt)
        {
            ArgumentNullException.ThrowIfNull(orderItem);

            this.orderItem = orderItem;
            this.testsPerformed = testsPerformed;
            this.notes = notes;
            this.performedAt = performedAt;
        }

        // Constructor protegido para EF Core
        protected PatientCareRecord() : this(null!, "", "", DateTime.MinValue) { }

        public int Id { get => id; private set => id = value; }
        public OrderItem OrderItem { get => orderItem; }
        public string TestsPerformed { get => testsPerformed; }
        public string Notes { get => notes; }
        public DateTime PerformedAt { get => performedAt; }
    }
    public class AdministeredMedication : PatientCareRecord
    {
        private readonly Medication medication;
        private string dose;
        private string administrationRoute;
        
        public AdministeredMedication(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt,
            Medication medication, string dose, string administrationRoute)
            : base(orderItem, testsPerformed, notes, performedAt)
        {
            ArgumentNullException.ThrowIfNull(medication);

            this.medication = medication;
            this.dose = dose.Trim();
            this.administrationRoute = administrationRoute.Trim();
        }

        // Constructor protegido para EF Core
        protected AdministeredMedication() : base(null!, "", "", DateTime.MinValue) { }

        public Medication Medication { get => medication; }
        public string Dose { get => dose; private set => dose = value; }
        public string AdministrationRoute { get => administrationRoute; private set => administrationRoute = value; }
    }
    public class PerformedProcedure : PatientCareRecord
    {
        public PerformedProcedure(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt) 
            : base(orderItem, testsPerformed, notes, performedAt)
        {
        }

        // Constructor protegido para EF Core
        protected PerformedProcedure() : base(null!, "", "", DateTime.MinValue) { }
    }

}
