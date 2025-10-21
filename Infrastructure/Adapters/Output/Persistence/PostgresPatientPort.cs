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
