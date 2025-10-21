using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence;
using Clinica_Herramientas_2.Infrastructure.Config;
using System.Windows.Forms;

namespace Clinica_Herramientas_2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // Leer configuración
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            
            var connectionString = configuration.GetConnectionString("ClinicaDb");
            
            // Configurar DbContext
            var optionsBuilder = new DbContextOptionsBuilder<ClinicaDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            
            // Crear DbContext
            using var dbContext = new ClinicaDbContext(optionsBuilder.Options);
            
            // Crear Config
            var config = new Config(dbContext);
            
            // Iniciar aplicación
            System.Windows.Forms.Application.Run(new Form1(config));
        }
    }
}