using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class AdministeredMedicationConfiguration : IEntityTypeConfiguration<AdministeredMedication>
    {
        public void Configure(EntityTypeBuilder<AdministeredMedication> builder)
        {
            builder.ToTable("administered_medication");
            
            builder.Property(am => am.Dose).HasMaxLength(50).IsRequired();
            builder.Property(am => am.AdministrationRoute).HasMaxLength(50).IsRequired();
            
            builder.HasOne(am => am.Medication)
                   .WithMany()
                   .HasForeignKey("medication_id")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
