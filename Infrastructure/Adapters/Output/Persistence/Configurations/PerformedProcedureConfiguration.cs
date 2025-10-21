using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class PerformedProcedureConfiguration : IEntityTypeConfiguration<PerformedProcedure>
    {
        public void Configure(EntityTypeBuilder<PerformedProcedure> builder)
        {
            builder.ToTable("performed_procedure");
        }
    }
}
