using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresMedicalRecordPort : IMedicalRecordPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresMedicalRecordPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public MedicalRecord? FindById(int id)
        {
            return context.MedicalRecords
                .Include(mr => mr.Patient)
                .Include(mr => mr.Doctor)
                .Include(mr => mr.Order)
                .FirstOrDefault(mr => mr.Id == id);
        }
        
        public void Save(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Add(medicalRecord);
            context.SaveChanges();
        }
        
        public void Update(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Update(medicalRecord);
            context.SaveChanges();
        }
        
        public void Delete(MedicalRecord medicalRecord)
        {
            context.MedicalRecords.Remove(medicalRecord);
            context.SaveChanges();
        }
        
        public List<MedicalRecord> FindAll()
        {
            return context.MedicalRecords
                .Include(mr => mr.Patient)
                .Include(mr => mr.Doctor)
                .Include(mr => mr.Order)
                .ToList();
        }
        
        public List<MedicalRecord> FindByPatient(string patientDni)
        {
            return context.MedicalRecords
                .Include(mr => mr.Patient)
                .Include(mr => mr.Doctor)
                .Include(mr => mr.Order)
                .Where(mr => mr.Patient.Dni == patientDni)
                .ToList();
        }
        
        public List<MedicalRecord> FindByDoctor(string doctorDni)
        {
            return context.MedicalRecords
                .Include(mr => mr.Patient)
                .Include(mr => mr.Doctor)
                .Include(mr => mr.Order)
                .Where(mr => mr.Doctor.Dni == doctorDni)
                .ToList();
        }
        
        public List<MedicalRecord> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            return context.MedicalRecords
                .Include(mr => mr.Patient)
                .Include(mr => mr.Doctor)
                .Include(mr => mr.Order)
                .Where(mr => mr.Date >= startDate && mr.Date <= endDate)
                .ToList();
        }
        
        public List<MedicalRecord> FindByPatientDni(string patientDni)
        {
            return FindByPatient(patientDni);
        }
        
        public List<MedicalRecord> FindByDoctorDni(string doctorDni)
        {
            return FindByDoctor(doctorDni);
        }
        
        public void Delete(int id)
        {
            var medicalRecord = FindById(id);
            if (medicalRecord != null)
            {
                Delete(medicalRecord);
            }
        }
    }
}
