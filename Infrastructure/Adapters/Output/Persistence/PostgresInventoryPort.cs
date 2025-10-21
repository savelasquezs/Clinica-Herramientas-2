using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresInventoryPort : IInventoryPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresInventoryPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public List<Medication> GetAllMedications()
        {
            return context.Medications.ToList();
        }
        
        public List<Procedure> GetAllProcedures()
        {
            return context.Procedures.ToList();
        }
        
        public List<DiagnosticAid> GetAllDiagnosticAids()
        {
            return context.DiagnosticAids.ToList();
        }
        
        public Medication GetMedicationById(int id)
        {
            return context.Medications.FirstOrDefault(m => m.Id == id);
        }
        
        public Procedure GetProcedureById(int id)
        {
            return context.Procedures.FirstOrDefault(p => p.Id == id);
        }
        
        public DiagnosticAid GetDiagnosticAidById(int id)
        {
            return context.DiagnosticAids.FirstOrDefault(d => d.Id == id);
        }
        
        public void UpdateMedication(Medication medication)
        {
            context.Medications.Update(medication);
            context.SaveChanges();
        }
        
        public void UpdateProcedure(Procedure procedure)
        {
            context.Procedures.Update(procedure);
            context.SaveChanges();
        }
        
        public void UpdateDiagnosticAid(DiagnosticAid diagnosticAid)
        {
            context.DiagnosticAids.Update(diagnosticAid);
            context.SaveChanges();
        }
        
        public Medication FindMedicationById(int id)
        {
            return GetMedicationById(id);
        }
        
        public Procedure FindProcedureById(int id)
        {
            return GetProcedureById(id);
        }
        
        public DiagnosticAid FindDiagnosticAidById(int id)
        {
            return GetDiagnosticAidById(id);
        }
    }
}
