using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresProcedurePort : IProcedurePort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresProcedurePort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public Procedure? FindById(int id)
        {
            return context.Procedures.FirstOrDefault(p => p.Id == id);
        }
        
        public void Save(Procedure procedure)
        {
            context.Procedures.Add(procedure);
            context.SaveChanges();
        }
        
        public void Update(Procedure procedure)
        {
            context.Procedures.Update(procedure);
            context.SaveChanges();
        }
        
        public void Delete(Procedure procedure)
        {
            context.Procedures.Remove(procedure);
            context.SaveChanges();
        }
        
        public List<Procedure> FindAll()
        {
            return context.Procedures.ToList();
        }
        
        public List<Procedure> FindByName(string name)
        {
            return context.Procedures
                .Where(p => p.Name.Contains(name))
                .ToList();
        }
        
        public List<Procedure> FindByRequiresSpecialist(bool requiresSpecialist)
        {
            return context.Procedures
                .Where(p => p.RequiresSpecialist == requiresSpecialist)
                .ToList();
        }
        
        public List<Procedure> FindByFrequency(int frequency)
        {
            return context.Procedures
                .Where(p => p.Frequency == frequency)
                .ToList();
        }
        
        public void Delete(int id)
        {
            var procedure = FindById(id);
            if (procedure != null)
            {
                Delete(procedure);
            }
        }
        
        public IEnumerable<Procedure> GetAll()
        {
            return FindAll();
        }
    }
}
