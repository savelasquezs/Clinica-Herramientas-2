using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item");
            builder.HasKey(oi => new { oi.OrderNumber, oi.ItemNumber }); // PK compuesta
            
            builder.Property(oi => oi.Cost).HasPrecision(10, 2).IsRequired();
            
            // TPT para subclases
            builder.UseTptMappingStrategy();
        }
    }
}
