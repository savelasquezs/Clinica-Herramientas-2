

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class PatientCareRecord
    {
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
    }
    class AdministeredMedication : PatientCareRecord
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

        public string Dose { get => dose; private set => dose = value; }
        public string AdministrationRoute { get => administrationRoute; private set => administrationRoute = value; }
    }
    class PerformedProcedure(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt) : PatientCareRecord(orderItem, testsPerformed, notes, performedAt)
    {
    }

}
