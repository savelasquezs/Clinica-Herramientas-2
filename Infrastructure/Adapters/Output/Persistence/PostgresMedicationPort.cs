using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresMedicationPort : IMedicationPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresMedicationPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public Medication? FindById(int id)
        {
            return context.Medications.FirstOrDefault(m => m.Id == id);
        }
        
        public void Save(Medication medication)
        {
            context.Medications.Add(medication);
            context.SaveChanges();
        }
        
        public void Update(Medication medication)
        {
            context.Medications.Update(medication);
            context.SaveChanges();
        }
        
        public void Delete(Medication medication)
        {
            context.Medications.Remove(medication);
            context.SaveChanges();
        }
        
        public List<Medication> FindAll()
        {
            return context.Medications.ToList();
        }
        
        public List<Medication> FindByName(string name)
        {
            return context.Medications
                .Where(m => m.Name.Contains(name))
                .ToList();
        }
        
        public List<Medication> FindByTreatmentDuration(int minDays, int maxDays)
        {
            return context.Medications
                .Where(m => m.TreatmentDuration >= minDays && m.TreatmentDuration <= maxDays)
                .ToList();
        }
        
        public void Delete(int id)
        {
            var medication = FindById(id);
            if (medication != null)
            {
                Delete(medication);
            }
        }
        
        public IEnumerable<Medication> GetAll()
        {
            return FindAll();
        }
    }
}
