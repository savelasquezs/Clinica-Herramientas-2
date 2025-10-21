using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClinicaDbContext>
    {
        public ClinicaDbContext CreateDbContext(string[] args)
        {
            // Leer configuración desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("ClinicaDb");

            var optionsBuilder = new DbContextOptionsBuilder<ClinicaDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ClinicaDbContext(optionsBuilder.Options);
        }
    }
}
