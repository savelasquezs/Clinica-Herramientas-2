using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    class UpdateUser
    {
        private UserPort userPort;

        public void Update(User user)
        {
            user = userPort.FindByDocument(user);

            if(user == null)
            {
                throw new Exception("El usuario no existe");
            }
            userPort.Update(user);
        }

    }
}
