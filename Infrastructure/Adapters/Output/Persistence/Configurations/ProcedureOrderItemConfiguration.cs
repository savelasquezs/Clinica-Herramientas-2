using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class ProcedureOrderItemConfiguration : IEntityTypeConfiguration<ProcedureOrderItem>
    {
        public void Configure(EntityTypeBuilder<ProcedureOrderItem> builder)
        {
            builder.ToTable("procedure_order_item");
            
            builder.Property(p => p.Frequency).IsRequired();
            builder.Property(p => p.RequiresSpecialist).IsRequired();
            builder.Property(p => p.SpecialistTypeId);
            
            builder.HasOne(p => p.Procedure)
                   .WithMany()
                   .HasForeignKey("procedure_id")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
