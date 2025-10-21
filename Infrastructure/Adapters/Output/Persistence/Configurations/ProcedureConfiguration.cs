using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("procedure");
            
            builder.Property(p => p.Frequency).IsRequired();
            builder.Property(p => p.RequiresSpecialist).IsRequired();
            builder.Property(p => p.SpecialistTypeId);
        }
    }
}
