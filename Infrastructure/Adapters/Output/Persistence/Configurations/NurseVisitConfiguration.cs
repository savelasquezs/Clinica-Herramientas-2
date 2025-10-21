using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class NurseVisitConfiguration : IEntityTypeConfiguration<NurseVisit>
    {
        public void Configure(EntityTypeBuilder<NurseVisit> builder)
        {
            builder.ToTable("nurse_visit");
            
            builder.Property(nv => nv.VisitTime).IsRequired();
            
            // Owned Entity: VitalData
            builder.OwnsOne(nv => nv.VitalData, vd =>
            {
                vd.Property(v => v.BloodPressure).HasColumnName("vital_blood_pressure").HasMaxLength(20);
                vd.Property(v => v.Temperature).HasColumnName("vital_temperature");
                vd.Property(v => v.Pulse).HasColumnName("vital_pulse");
                vd.Property(v => v.OxygenLevel).HasColumnName("vital_oxygen_level");
            });
            
            // Relaciones
            builder.HasOne(nv => nv.Nurse)
                   .WithMany(u => u.NurseVisits)
                   .HasForeignKey("nurse_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasOne(nv => nv.Patient)
                   .WithMany(p => p.NurseVisits)
                   .HasForeignKey("patient_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasMany(nv => nv.AdministeredMedications)
                   .WithOne()
                   .HasForeignKey("nurse_visit_id")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
