using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class UpdatePatient(IPatientPort patientPort)
    {
        private readonly IPatientPort patientPort=patientPort;

        public void Update(User user, Patient patient)
        {
            
            if (user.Role != Role.Admin)
            {
                throw new Exception("Solo el administrador puede actualizar pacientes");
            }
            if (patientPort.FindByDocument(patient.Dni) == null)
            {
                throw new Exception("El paciente no existe");
            }
            
            patientPort.Update(patient);
        }
    }
}
