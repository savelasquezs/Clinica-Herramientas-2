using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options) { }
        
        // DbSets - Entidades principales
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MedicationOrderItem> MedicationOrderItems { get; set; }
        public DbSet<ProcedureOrderItem> ProcedureOrderItems { get; set; }
        public DbSet<DiagnosticAidOrderItem> DiagnosticAidOrderItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        
        // PatientCareRecords jerarquía
        public DbSet<PatientCareRecord> PatientCareRecords { get; set; }
        public DbSet<AdministeredMedication> AdministeredMedications { get; set; }
        public DbSet<PerformedProcedure> PerformedProcedures { get; set; }
        public DbSet<NurseVisit> NurseVisits { get; set; }
        
        // ClinicalResources jerarquía
        public DbSet<ClinicalResource> ClinicalResources { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<DiagnosticAid> DiagnosticAids { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configurar convenciones de nomenclatura snake_case
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Tablas en snake_case singular
                var tableName = entity.GetTableName();
                if (tableName != null)
                {
                    entity.SetTableName(ToSnakeCase(tableName));
                }
                
                // Columnas en snake_case
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }
            }
            
            // Aplicar configuraciones específicas
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicaDbContext).Assembly);
        }
        
        private static string ToSnakeCase(string name)
        {
            return string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();
        }
    }
}
