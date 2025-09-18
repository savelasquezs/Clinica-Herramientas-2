using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class InventoryService(
        IMedicationPort medicationPort,
        IProcedurePort procedurePort,
        IDiagnosticAidPort diagnosticAidPort)
    {
        private readonly IMedicationPort medicationPort = medicationPort;
        private readonly IProcedurePort procedurePort = procedurePort;
        private readonly IDiagnosticAidPort diagnosticAidPort = diagnosticAidPort;

        public void AddMedication(User user, Medication medication)
        {
            EnsureSupportRole(user);

            if (medicationPort.FindById(medication.Id) != null)
                throw new Exception("Ya existe un medicamento con este Id");

            medicationPort.Save(medication);
        }

        public void UpdateMedication(User user, Medication medication)
        {
            EnsureSupportRole(user);

            if (medicationPort.FindById(medication.Id) == null)
                throw new Exception("El medicamento no existe");

            medicationPort.Update(medication);
        }

        public void AddProcedure(User user, Procedure procedure)
        {
            EnsureSupportRole(user);

            if (procedurePort.FindById(procedure.Id) != null)
                throw new Exception("Ya existe un procedimiento con este Id");

            procedurePort.Save(procedure);
        }

        public void UpdateProcedure(User user, Procedure procedure)
        {
            EnsureSupportRole(user);

            if (procedurePort.FindById(procedure.Id) == null)
                throw new Exception("El procedimiento no existe");

            procedurePort.Update(procedure);
        }

        public void AddDiagnosticAid(User user, DiagnosticAid aid)
        {
            EnsureSupportRole(user);

            if (diagnosticAidPort.FindById(aid.Id) != null)
                throw new Exception("Ya existe una ayuda diagnóstica con este Id");

            diagnosticAidPort.Save(aid);
        }

        public void UpdateDiagnosticAid(User user, DiagnosticAid aid)
        {
            EnsureSupportRole(user);

            if (diagnosticAidPort.FindById(aid.Id) == null)
                throw new Exception("La ayuda diagnóstica no existe");

            diagnosticAidPort.Update(aid);
        }

        private static void EnsureSupportRole(User user)
        {
            if (user == null || user.Role != Role.Support) // ⚠️ Aquí revisa: ¿Quieres Role.Support en tu enum?
                throw new Exception("Solo Soporte de Información puede modificar inventarios");
        }
    }
}
