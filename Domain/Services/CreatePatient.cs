using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    class CreatePatient
    {
        private PatientPort patientPort;

        public void Create(Patient patient)
        {
            if (patientPort.FindByDocument(patient) != null)
            {
                throw new Exception("El paciente ya existe");
            }
            if (patient.EmergencyContact == null)
            {
                throw new Exception("El paciente debe tener un contacto de emergencia");
            }
            patientPort.Save(patient);
        }
    }
}
