
using Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence;

namespace Clinica_Herramientas_2.Infrastructure.Config
{
    public class Config
    {
        private readonly ConfigFactory configFactory;
        
        public AdminConfig AdminConfig => configFactory.AdminConfig;
        public DoctorConfig DoctorConfig => configFactory.DoctorConfig;
        public NurseConfig NurseConfig => configFactory.NurseConfig;
        public RRHHConfig RRHHConfig => configFactory.RRHHConfig;
        public SupportConfig SupportConfig => configFactory.SupportConfig;
        public AuthConfig AuthConfig => configFactory.AuthConfig;
        
        public Config(ClinicaDbContext dbContext)
        {
            var portsFactory = new PortsFactory(dbContext);
            configFactory = new ConfigFactory(portsFactory);
        }
    }
}
