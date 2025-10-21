using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("medical_record");
            builder.HasKey(mr => mr.Id);
            
            builder.Property(mr => mr.Id).ValueGeneratedOnAdd();
            builder.Property(mr => mr.Date).IsRequired();
            builder.Property(mr => mr.ConsultationReason).HasMaxLength(500).IsRequired();
            builder.Property(mr => mr.Symptoms).HasMaxLength(1000).IsRequired();
            builder.Property(mr => mr.Diagnosis).HasMaxLength(1000).IsRequired();
            
            builder.HasOne(mr => mr.Patient)
                   .WithMany(p => p.MedicalRecords)
                   .HasForeignKey("patient_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasOne(mr => mr.Doctor)
                   .WithMany(u => u.MedicalRecordsAsDoctor)
                   .HasForeignKey("doctor_dni")
                   .OnDelete(DeleteBehavior.Restrict);
                   
            builder.HasOne(mr => mr.Order)
                   .WithMany()
                   .HasForeignKey("order_number")
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
