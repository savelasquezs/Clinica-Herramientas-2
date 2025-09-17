using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    class UpdatePatient(IPatientPort patientPort)
    {
        private readonly IPatientPort patientPort=patientPort;

        public void Update(Patient patient)
        {
            
            if (patientPort.FindByDocument(patient) == null)
            {
                throw new Exception("El paciente no existe");
            }
            if(patient.EmergencyContact == null)
            {
                throw new Exception("El paciente debe tener un contacto de emergencia");
            }
            patientPort.Update(patient);
        }
    }
}
