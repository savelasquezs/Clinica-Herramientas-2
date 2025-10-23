using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class AuthenticateUser
    {
        private readonly IUserPort userPort;

        public AuthenticateUser(IUserPort userPort)
        {
            this.userPort = userPort;
        }

        public User? Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var user = userPort.FindByUsername(username);
            
            if (user == null)
            {
                return null;
            }

            // Para fines educativos, comparación simple de contraseñas
            if (user.Password == password)
            {
                return user;
            }

            return null;
        }
    }
}
