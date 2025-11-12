using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresPatientPort : IPatientPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresPatientPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public Patient? FindByDocument(string patientDni)
        {
            return context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.MedicalRecords)
                .Include(p => p.NurseVisits)
                .Include(p => p.Invoices)
                .FirstOrDefault(p => p.Dni == patientDni);
        }
        
        public void Save(Patient patient)
        {
            // Verificar el estado actual de la entidad
            var entry = context.Entry(patient);
            
            // Si la entidad ya está siendo rastreada
            if (entry.State != EntityState.Detached)
            {
                // Si ya está marcada como Added, solo guardar
                if (entry.State == EntityState.Added)
                {
                    context.SaveChanges();
                    return;
                }
                // Si está en otro estado, cambiar a Added
                entry.State = EntityState.Added;
                context.SaveChanges();
                return;
            }
            
            // Si la entidad no está siendo rastreada, verificar si ya existe otra con el mismo DNI
            var trackedPatient = context.ChangeTracker.Entries<Patient>()
                .FirstOrDefault(e => e.Entity.Dni == patient.Dni && !ReferenceEquals(e.Entity, patient));
            
            if (trackedPatient != null)
            {
                // Ya existe otra entidad con el mismo DNI siendo rastreada
                throw new InvalidOperationException($"Ya existe una entidad Patient con DNI '{patient.Dni}' siendo rastreada por el contexto.");
            }
            
            // Verificar si ya existe en la base de datos (sin rastrear para evitar conflictos)
            var exists = context.Patients
                .AsNoTracking()
                .Any(p => p.Dni == patient.Dni);
            
            if (exists)
            {
                throw new Exception("El paciente ya existe");
            }
            
            // Agregar la nueva entidad
            context.Patients.Add(patient);
            context.SaveChanges();
        }
        
        public void Update(Patient patient)
        {
            context.Patients.Update(patient);
            context.SaveChanges();
        }
        
        public void Delete(Patient patient)
        {
            context.Patients.Remove(patient);
            context.SaveChanges();
        }
        
        public List<Patient> FindAll()
        {
            return context.Patients.ToList();
        }
        
        public List<Patient> FindByGender(Gender gender)
        {
            return context.Patients.Where(p => p.Gender == gender).ToList();
        }
        
        public List<Patient> FindByInsuranceCompany(string companyName)
        {
            return context.Patients
                .Where(p => p.Insurance.CompanyName.Contains(companyName))
                .ToList();
        }
    }
}
