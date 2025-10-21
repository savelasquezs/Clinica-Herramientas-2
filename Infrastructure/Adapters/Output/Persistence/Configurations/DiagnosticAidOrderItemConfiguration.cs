using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class DiagnosticAidOrderItemConfiguration : IEntityTypeConfiguration<DiagnosticAidOrderItem>
    {
        public void Configure(EntityTypeBuilder<DiagnosticAidOrderItem> builder)
        {
            builder.ToTable("diagnostic_aid_order_item");
            
            builder.Property(d => d.Quantity).IsRequired();
            builder.Property(d => d.RequiresSpecialist).IsRequired();
            builder.Property(d => d.SpecialistTypeId);
            
            builder.HasOne(d => d.DiagnosticAid)
                   .WithMany()
                   .HasForeignKey("diagnostic_aid_id")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
