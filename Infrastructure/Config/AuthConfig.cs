using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Services;

namespace Clinica_Herramientas_2.Infrastructure.Config
{
    public class AuthConfig
    {
        public AuthenticateUser AuthenticateUserService { get; private set; }

        public AuthConfig(IUserPort userPort)
        {
            AuthenticateUserService = new AuthenticateUser(userPort);
        }
    }
}
