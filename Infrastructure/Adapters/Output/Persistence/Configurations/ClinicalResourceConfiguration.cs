using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class ClinicalResourceConfiguration : IEntityTypeConfiguration<ClinicalResource>
    {
        public void Configure(EntityTypeBuilder<ClinicalResource> builder)
        {
            builder.ToTable("clinical_resource");
            builder.HasKey(cr => cr.Id);
            
            builder.Property(cr => cr.Name).HasMaxLength(200).IsRequired();
            builder.Property(cr => cr.Cost).HasPrecision(10, 2).IsRequired();
            
            // TPT para subclases
            builder.UseTptMappingStrategy();
        }
    }
}
