using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class UpdateUser(IUserPort userPort)
    {
        private readonly IUserPort userPort= userPort;

        public void Update(User performingUser, User user)
        {
            if (performingUser == null || performingUser.Role != Role.RRHH)
            {
                throw new Exception("Solo RRHH puede actualizar usuarios.");
            }
            user = userPort.FindByDocument(user.Dni);

            if(user == null)
            {
                throw new Exception("El usuario no existe");
            }
            userPort.Update(user);
        }

    }
}
