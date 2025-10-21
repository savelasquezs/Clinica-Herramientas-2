using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class ViewPatientInformation
    {
        private readonly IPatientPort patientPort;
        private readonly IAppointmentPort appointmentPort;
        private readonly IOrderPort orderPort;

        public ViewPatientInformation(IPatientPort patientPort, IAppointmentPort appointmentPort, IOrderPort orderPort)
        {
            this.patientPort = patientPort;
            this.appointmentPort = appointmentPort;
            this.orderPort = orderPort;
        }

        public Patient GetPatientByDni(string dni)
        {
            return patientPort.FindByDocument(dni) ?? throw new Exception("El paciente no existe");
        }

        public List<Appointment> GetPatientAppointments(string patientDni)
        {
            _ = patientPort.FindByDocument(patientDni) ?? throw new Exception("El paciente no existe");
            return appointmentPort.FindByPatientDni(patientDni);
        }

        public List<Order> GetPatientOrders(string patientDni)
        {
            _ = patientPort.FindByDocument(patientDni) ?? throw new Exception("El paciente no existe");
            return orderPort.FindByPatientDni(patientDni);
        }

        public List<Patient> GetAllPatients()
        {
            return patientPort.FindAll();
        }
    }
}
