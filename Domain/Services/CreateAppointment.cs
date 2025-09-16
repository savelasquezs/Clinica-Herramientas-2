using Clinica_Herramientas_2.Domain.Model;

using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class CreateAppointment
    {
        private AppointmentPort appointmentPort;
        private PatientPort patientPort;

        public void Create(Appointment appointment, Patient patient)
        {
            patient = patientPort.FindByDocument(patient);

            if (patient == null)
            {
                throw new Exception("El paciente no existe");
            }
            appointmentPort.SaveAppointment(appointment);
        }
    }
}
