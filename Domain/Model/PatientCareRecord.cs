

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
            if (!string.IsNullOrWhiteSpace(testsPerformed))
            {
                Validations.MyStringValidator.ValidateStringLength(testsPerformed, nameof(testsPerformed), max: 2000, min: 1);
            }
            if (!string.IsNullOrWhiteSpace(notes))
            {
                Validations.MyStringValidator.ValidateStringLength(notes, nameof(notes), max: 2000, min: 1);
            }
            Validations.MyDateValidator.ValidateDateNotInFuture(performedAt, nameof(performedAt));

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
            Validations.MyStringValidator.ValidateStringLength(dose, nameof(Dose), max: 50, min: 1);
            Validations.MyStringValidator.ValidateStringLength(administrationRoute, nameof(AdministrationRoute), max: 50, min: 1);

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
