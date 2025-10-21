using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");
            builder.HasKey(p => p.Dni);
            
            builder.Property(p => p.Dni).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Fullname).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Phonenumber).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Birthdate).IsRequired();
            
            // TPT: Configurar herencia
            builder.UseTptMappingStrategy();
        }
    }
}
