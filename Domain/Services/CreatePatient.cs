using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;


namespace Clinica_Herramientas_2.Domain.Services
{
    class CreatePatient( IPatientPort patientPort)
    {
        private readonly IPatientPort patientPort = patientPort;

        public void Create( User user, Patient patient)
        {
            if (user.Role != Role.Admin)
            {
                throw new Exception("Solo el administrador puede crear pacientes");
            }
            if (patientPort.FindByDocument(patient.Dni) != null)
            {
                throw new Exception("El paciente ya existe");
            }
               
            patientPort.Save(patient);
        }
    }
}
