using Clinica_Herramientas_2.Domain.Model.Validations;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class Appointment
    {
        private int Id;
        private Patient Patient;
        private DateTime Date;
        
        public Appointment(int id, Patient patient, DateTime date)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id debe ser mayor que cero.");
            }
            ArgumentNullException.ThrowIfNull(patient);
            MyDateValidator.ValidateDateNotInFuture(date, nameof(Date));

            Id = id;
            Patient = patient;
            Date = date;
        }

        public int Id1 { get => Id; private set => Id = value; }
        public DateTime Date1 { get => Date; private set => Date = value; }
        internal Patient Patient1 { get => Patient; private set => Patient = value; }
    }
}
