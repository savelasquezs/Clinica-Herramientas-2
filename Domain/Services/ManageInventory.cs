using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class ManageInventory
    {
        private readonly IMedicationPort medicationPort;
        private readonly IProcedurePort procedurePort;
        private readonly IDiagnosticAidPort diagnosticAidPort;

        public ManageInventory(IMedicationPort medicationPort, IProcedurePort procedurePort, IDiagnosticAidPort diagnosticAidPort)
        {
            this.medicationPort = medicationPort;
            this.procedurePort = procedurePort;
            this.diagnosticAidPort = diagnosticAidPort;
        }

        public void CreateMedication(Medication medication)
        {
            if (medicationPort.FindById(medication.Id) != null)
            {
                throw new Exception("Ya existe un medicamento con este ID");
            }
            medicationPort.Save(medication);
        }

        public void UpdateMedication(Medication medication)
        {
            _ = medicationPort.FindById(medication.Id) ?? throw new Exception("El medicamento no existe");
            medicationPort.Update(medication);
        }

        public void CreateProcedure(Procedure procedure)
        {
            if (procedurePort.FindById(procedure.Id) != null)
            {
                throw new Exception("Ya existe un procedimiento con este ID");
            }
            procedurePort.Save(procedure);
        }

        public void UpdateProcedure(Procedure procedure)
        {
            _ = procedurePort.FindById(procedure.Id) ?? throw new Exception("El procedimiento no existe");
            procedurePort.Update(procedure);
        }

        public void CreateDiagnosticAid(DiagnosticAid diagnosticAid)
        {
            if (diagnosticAidPort.FindById(diagnosticAid.Id) != null)
            {
                throw new Exception("Ya existe una ayuda diagnóstica con este ID");
            }
            diagnosticAidPort.Save(diagnosticAid);
        }

        public void UpdateDiagnosticAid(DiagnosticAid diagnosticAid)
        {
            _ = diagnosticAidPort.FindById(diagnosticAid.Id) ?? throw new Exception("La ayuda diagnóstica no existe");
            diagnosticAidPort.Update(diagnosticAid);
        }

        public List<Medication> GetAllMedications()
        {
            return medicationPort.FindAll();
        }

        public List<Procedure> GetAllProcedures()
        {
            return procedurePort.FindAll();
        }

        public List<DiagnosticAid> GetAllDiagnosticAids()
        {
            return diagnosticAidPort.FindAll();
        }
    }
}
