using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;


namespace Clinica_Herramientas_2.Domain.Services
{
    public class CreatePatient( IPatientPort patientPort)
    {
        private readonly IPatientPort patientPort = patientPort;

        public void Create( User user, Patient patient)
        {
            // Validar usuario
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El usuario no puede ser null");
            }
            
            if (user.Role != Role.Admin)
            {
                throw new Exception("Solo el administrador puede crear pacientes");
            }
            
            // Validar paciente
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "El paciente no puede ser null");
            }
            
            // Validar DNI
            if (string.IsNullOrWhiteSpace(patient.Dni))
            {
                throw new Exception("El DNI del paciente no puede estar vacío");
            }
            
            // Verificar si el paciente ya existe usando método sin tracking para evitar conflictos
            if (patientPort.ExistsByDocument(patient.Dni))
            {
                throw new Exception($"El paciente con DNI '{patient.Dni}' ya existe en el sistema");
            }
               
            // Guardar el paciente
            patientPort.Save(patient);
        }
    }
}
