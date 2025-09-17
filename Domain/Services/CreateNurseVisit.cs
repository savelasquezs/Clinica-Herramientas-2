
using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class CreateNurseVisit(INurseVisit nurseVisitPort, IPatientPort patientPort, IUserPort userPort)
    {
        private readonly INurseVisit nurseVisitPort = nurseVisitPort;
        private readonly IPatientPort patientPort = patientPort;
        private readonly IUserPort userPort = userPort;

        public void Create(NurseVisit nurseVisit)
        {
            ArgumentNullException.ThrowIfNull(nurseVisit);

            // Validar Patient por documento
            ArgumentNullException.ThrowIfNull(nurseVisit.Patient);
            _ = patientPort.FindByDocument(nurseVisit.Patient) ?? throw new Exception("El paciente no existe");

            // Validar Nurse por documento y rol
            ArgumentNullException.ThrowIfNull(nurseVisit.Nurse);
            var nurse = userPort.FindByDocument(nurseVisit.Nurse) ?? throw new Exception("La enfermera no existe");
            if (nurse.Role != Role.Nurse)
            {
                throw new Exception("El usuario asignado no tiene rol de enfermera");
            }

            // Validar VitalData
            ArgumentNullException.ThrowIfNull(nurseVisit.VitalData);
       
            ArgumentNullException.ThrowIfNull(nurseVisit.OrderItem);
        

            nurseVisitPort.Save(nurseVisit);
        }
    }
}

