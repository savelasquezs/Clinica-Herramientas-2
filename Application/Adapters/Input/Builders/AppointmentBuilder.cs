using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    public class AppointmentBuilder
    {
        private AppointmentValidator appointmentValidator;

        public AppointmentBuilder()
        {
            appointmentValidator = new AppointmentValidator();
        }

        internal AppointmentValidator AppointmentValidator { get => appointmentValidator; set => appointmentValidator = value; }

        public Appointment Create(int id, Patient patient, DateTime date)
        {
            return new Appointment(
                appointmentValidator.ValidateId(id),
                patient,
                appointmentValidator.ValidateDate(date)
            );
        }
    }
}
