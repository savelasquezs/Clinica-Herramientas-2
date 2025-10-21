using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");
            builder.HasKey(i => i.InvoiceNumber);
            
            builder.Property(i => i.InvoiceNumber).ValueGeneratedNever();
            builder.Property(i => i.InvoiceDate).IsRequired();
            builder.Property(i => i.TotalAmount).HasPrecision(10, 2).IsRequired();
            builder.Property(i => i.CopaymentAmount).HasPrecision(10, 2).IsRequired();
            builder.Property(i => i.InsuranceAmount).HasPrecision(10, 2).IsRequired();
            builder.Property(i => i.AnnualCopaymentAccumulated).HasPrecision(10, 2).IsRequired();
            
            builder.HasOne(i => i.Patient)
                   .WithMany(p => p.Invoices)
                   .HasForeignKey("patient_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasOne(i => i.Doctor)
                   .WithMany(u => u.InvoicesAsDoctor)
                   .HasForeignKey("doctor_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasMany(i => i.Orders)
                   .WithMany()
                   .UsingEntity("invoice_order");
        }
    }
}
