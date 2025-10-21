using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresNurseVisitPort : INurseVisit
    {
        private readonly ClinicaDbContext context;
        
        public PostgresNurseVisitPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public NurseVisit FindById(int id)
        {
            return context.NurseVisits
                .Include(nv => nv.Nurse)
                .Include(nv => nv.Patient)
                .Include(nv => nv.VitalData)
                .Include(nv => nv.AdministeredMedications)
                .FirstOrDefault(nv => nv.Id == id);
        }
        
        public void Save(NurseVisit nurseVisit)
        {
            context.NurseVisits.Add(nurseVisit);
            context.SaveChanges();
        }
        
        public void Update(NurseVisit nurseVisit)
        {
            context.NurseVisits.Update(nurseVisit);
            context.SaveChanges();
        }
        
        public void Delete(NurseVisit nurseVisit)
        {
            context.NurseVisits.Remove(nurseVisit);
            context.SaveChanges();
        }
        
        public List<NurseVisit> FindAll()
        {
            return context.NurseVisits
                .Include(nv => nv.Nurse)
                .Include(nv => nv.Patient)
                .Include(nv => nv.VitalData)
                .Include(nv => nv.AdministeredMedications)
                .ToList();
        }
        
        public List<NurseVisit> FindByNurse(string nurseDni)
        {
            return context.NurseVisits
                .Include(nv => nv.Nurse)
                .Include(nv => nv.Patient)
                .Include(nv => nv.VitalData)
                .Include(nv => nv.AdministeredMedications)
                .Where(nv => nv.Nurse.Dni == nurseDni)
                .ToList();
        }
        
        public List<NurseVisit> FindByPatient(string patientDni)
        {
            return context.NurseVisits
                .Include(nv => nv.Nurse)
                .Include(nv => nv.Patient)
                .Include(nv => nv.VitalData)
                .Include(nv => nv.AdministeredMedications)
                .Where(nv => nv.Patient.Dni == patientDni)
                .ToList();
        }
        
        public List<NurseVisit> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            return context.NurseVisits
                .Include(nv => nv.Nurse)
                .Include(nv => nv.Patient)
                .Include(nv => nv.VitalData)
                .Include(nv => nv.AdministeredMedications)
                .Where(nv => nv.VisitTime >= startDate && nv.VisitTime <= endDate)
                .ToList();
        }
        
        public bool IsValidVitalData(VitalData vitalData)
        {
            // Implementar validación básica de datos vitales
            return vitalData != null && 
                   !string.IsNullOrEmpty(vitalData.BloodPressure) && 
                   vitalData.Pulse > 0 && 
                   vitalData.Temperature > 0;
        }
        
        public NurseVisit FindById(NurseVisit nurseVisit)
        {
            return FindById(nurseVisit.Id);
        }
        
        public void DeleteById(NurseVisit nurseVisit)
        {
            Delete(nurseVisit);
        }
        
        public bool OrderItemExists(OrderItem orderItem)
        {
            return context.OrderItems
                .Any(oi => oi.OrderNumber == orderItem.OrderNumber && 
                          oi.ItemNumber == orderItem.ItemNumber);
        }
    }
}
