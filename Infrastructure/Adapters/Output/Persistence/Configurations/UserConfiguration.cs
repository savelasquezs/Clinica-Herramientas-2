using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            
            builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(255).IsRequired();
            builder.Property(u => u.Role).HasConversion<string>().IsRequired();
            
            // Índices únicos
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            
            // Relaciones
            builder.HasMany(u => u.MedicalRecordsAsDoctor)
                   .WithOne(m => m.Doctor)
                   .HasForeignKey("doctor_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasMany(u => u.NurseVisits)
                   .WithOne(nv => nv.Nurse)
                   .HasForeignKey("nurse_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasMany(u => u.InvoicesAsDoctor)
                   .WithOne(i => i.Doctor)
                   .HasForeignKey("doctor_dni")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
