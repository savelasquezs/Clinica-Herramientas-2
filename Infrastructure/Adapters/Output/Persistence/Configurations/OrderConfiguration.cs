using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");
            builder.HasKey(o => o.OrderNumber);
            
            builder.Property(o => o.OrderNumber).ValueGeneratedNever();
            builder.Property(o => o.CreationDate).IsRequired();
            
            // Relación 1:N con OrderItems
            builder.HasMany(o => o.Items)
                   .WithOne()
                   .HasForeignKey("order_number")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
