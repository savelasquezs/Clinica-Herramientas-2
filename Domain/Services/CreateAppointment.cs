using Clinica_Herramientas_2.Domain.Model;

using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class CreateAppointment(IAppointmentPort appointmentPort, IPatientPort patientPort)
    {
        private readonly IAppointmentPort appointmentPort = appointmentPort;
        private readonly IPatientPort patientPort = patientPort;

        public void Create(Appointment appointment, string patientDni)
        {
            _ = patientPort.FindByDocument(patientDni) ?? throw new Exception("El paciente no existe");
            if (appointment.Date1 < DateTime.Now)
            {
                throw new Exception("La fecha de la cita no puede ser en el pasado");
            }
        
            appointmentPort.SaveAppointment(appointment);
        }
    }
}
