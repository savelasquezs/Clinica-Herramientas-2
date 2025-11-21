using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        
        // Método auxiliar para verificar existencia sin tracking
        public bool ExistsByDocument(string patientDni)
        {
            return context.Patients
                .AsNoTracking()
                .Any(p => p.Dni == patientDni);
        }
        
        public void Save(Patient patient)
        {
            // Validar que el paciente no sea null
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "El paciente no puede ser null");
            }
            
            // Validar que el DNI no esté vacío
            if (string.IsNullOrWhiteSpace(patient.Dni))
            {
                throw new Exception("El DNI del paciente no puede estar vacío");
            }
            
            // PASO 1: Verificar primero si ya existe en la base de datos (sin rastrear para evitar conflictos)
            var exists = context.Patients
                .AsNoTracking()
                .Any(p => p.Dni == patient.Dni);
            
            if (exists)
            {
                throw new Exception($"El paciente con DNI '{patient.Dni}' ya existe en el sistema");
            }
            
            // PASO 2: Limpiar TODAS las entidades Patient rastreadas con el mismo DNI
            // Esto previene el error "Ya existe una entidad Patient con DNI siendo rastreada"
            var trackedPatients = context.ChangeTracker.Entries<Patient>()
                .Where(e => e.Entity.Dni == patient.Dni)
                .ToList();
            
            foreach (var trackedEntry in trackedPatients)
            {
                trackedEntry.State = EntityState.Detached;
            }
            
            // PASO 3: Verificar si la entidad específica que queremos guardar ya está siendo rastreada
            var existingEntry = context.ChangeTracker.Entries<Patient>()
                .FirstOrDefault(e => ReferenceEquals(e.Entity, patient));
            
            // Si la entidad ya está siendo rastreada, detachla primero
            if (existingEntry != null)
            {
                existingEntry.State = EntityState.Detached;
            }
            
            // PASO 4: Asegurarse de que el paciente y sus entidades relacionadas no estén siendo rastreadas
            // Esto es crítico porque EmergencyContact y HealthInsurance son owned entities
            // y pueden causar problemas de tracking si ya están rastreadas
            
            // Intentar agregar el paciente
            try
            {
                // Verificar el estado de la entidad antes de agregar
                var entryBeforeAdd = context.Entry(patient);
                
                // Si de alguna manera está siendo rastreada, detachla
                if (entryBeforeAdd.State != EntityState.Detached)
                {
                    entryBeforeAdd.State = EntityState.Detached;
                }
                
                // Agregar la nueva entidad como nueva (sin tracking previo)
                context.Patients.Add(patient);
                
                // Guardar cambios
                context.SaveChanges();
            }
            catch (InvalidOperationException ex) when (
                ex.Message.Contains("siendo rastreada") || 
                ex.Message.Contains("being tracked") ||
                ex.Message.Contains("is already being tracked") ||
                ex.Message.Contains("The instance of entity type") && ex.Message.Contains("cannot be tracked"))
            {
                // Error de tracking detectado - limpiar y reintentar
                context.ChangeTracker.Clear();
                
                // Verificar nuevamente si existe (por si acaso se creó en otro proceso)
                var stillExists = context.Patients
                    .AsNoTracking()
                    .Any(p => p.Dni == patient.Dni);
                
                if (stillExists)
                {
                    throw new Exception($"El paciente con DNI '{patient.Dni}' ya existe en el sistema");
                }
                
                // Reintentar agregar después de limpiar el tracker
                context.Patients.Add(patient);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Si hay un error de constraint o base de datos
                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                
                if (errorMessage.Contains("duplicate key") || 
                    errorMessage.Contains("unique constraint") ||
                    errorMessage.Contains("violates unique constraint") ||
                    errorMessage.Contains("23505")) // PostgreSQL unique violation error code
                {
                    throw new Exception($"El paciente con DNI '{patient.Dni}' ya existe en el sistema");
                }
                else if (errorMessage.Contains("siendo rastreada") || 
                         errorMessage.Contains("being tracked") ||
                         errorMessage.Contains("is already being tracked"))
                {
                    // Limpiar y reintentar
                    context.ChangeTracker.Clear();
                    
                    var stillExists = context.Patients
                        .AsNoTracking()
                        .Any(p => p.Dni == patient.Dni);
                    
                    if (stillExists)
                    {
                        throw new Exception($"El paciente con DNI '{patient.Dni}' ya existe en el sistema");
                    }
                    
                    context.Patients.Add(patient);
                    context.SaveChanges();
                }
                else
                {
                    // Re-lanzar otros errores de base de datos con más contexto
                    throw new Exception($"Error al guardar el paciente en la base de datos: {errorMessage}", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejar otros tipos de excepciones
                throw new Exception($"Error inesperado al guardar el paciente: {ex.Message}", ex);
            }
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
