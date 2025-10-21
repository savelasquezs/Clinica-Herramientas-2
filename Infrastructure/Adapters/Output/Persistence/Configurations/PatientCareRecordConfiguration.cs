using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class PatientCareRecordConfiguration : IEntityTypeConfiguration<PatientCareRecord>
    {
        public void Configure(EntityTypeBuilder<PatientCareRecord> builder)
        {
            builder.ToTable("patient_care_record");
            builder.HasKey(pcr => pcr.Id);
            
            builder.Property(pcr => pcr.Id).ValueGeneratedOnAdd();
            builder.Property(pcr => pcr.TestsPerformed).HasMaxLength(500);
            builder.Property(pcr => pcr.Notes).HasMaxLength(1000);
            builder.Property(pcr => pcr.PerformedAt).IsRequired();
            
            // Relación con OrderItem
            builder.HasOne(pcr => pcr.OrderItem)
                   .WithMany()
                   .HasForeignKey("order_number", "item_number")
                   .OnDelete(DeleteBehavior.Restrict);
            
            // TPT para subclases
            builder.UseTptMappingStrategy();
        }
    }
}
