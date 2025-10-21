using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class MedicationOrderItemConfiguration : IEntityTypeConfiguration<MedicationOrderItem>
    {
        public void Configure(EntityTypeBuilder<MedicationOrderItem> builder)
        {
            builder.ToTable("medication_order_item");
            
            builder.Property(m => m.Dose).HasMaxLength(50).IsRequired();
            builder.Property(m => m.TreatmentDuration).IsRequired();
            
            builder.HasOne(m => m.Medication)
                   .WithMany()
                   .HasForeignKey("medication_id")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
