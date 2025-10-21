using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresDiagnosticAidPort : IDiagnosticAidPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresDiagnosticAidPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public DiagnosticAid? FindById(int id)
        {
            return context.DiagnosticAids.FirstOrDefault(d => d.Id == id);
        }
        
        public void Save(DiagnosticAid diagnosticAid)
        {
            context.DiagnosticAids.Add(diagnosticAid);
            context.SaveChanges();
        }
        
        public void Update(DiagnosticAid diagnosticAid)
        {
            context.DiagnosticAids.Update(diagnosticAid);
            context.SaveChanges();
        }
        
        public void Delete(DiagnosticAid diagnosticAid)
        {
            context.DiagnosticAids.Remove(diagnosticAid);
            context.SaveChanges();
        }
        
        public List<DiagnosticAid> FindAll()
        {
            return context.DiagnosticAids.ToList();
        }
        
        public List<DiagnosticAid> FindByName(string name)
        {
            return context.DiagnosticAids
                .Where(d => d.Name.Contains(name))
                .ToList();
        }
        
        public List<DiagnosticAid> FindByRequiresSpecialist(bool requiresSpecialist)
        {
            return context.DiagnosticAids
                .Where(d => d.RequiresSpecialist == requiresSpecialist)
                .ToList();
        }
        
        public List<DiagnosticAid> FindByQuantityRange(int minQuantity, int maxQuantity)
        {
            return context.DiagnosticAids
                .Where(d => d.Quantity >= minQuantity && d.Quantity <= maxQuantity)
                .ToList();
        }
        
        public void Delete(int id)
        {
            var diagnosticAid = FindById(id);
            if (diagnosticAid != null)
            {
                Delete(diagnosticAid);
            }
        }
        
        public IEnumerable<DiagnosticAid> GetAll()
        {
            return FindAll();
        }
    }
}
