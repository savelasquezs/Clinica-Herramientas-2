using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    class CreateUser(IUserPort userPort)
    {
        private readonly IUserPort userPort=userPort;

        public void Create(User user)
        {
            if(userPort.FindByUserName(user) != null)
            {
                throw new Exception("Ya existe un usuario con este nombre de usuario");
            }
            if(userPort.FindByDocument(user) != null)
            {
                throw new Exception("Ya existe un usuario con esta identificacion");
            }
            if(userPort.FindByEmail(user) != null)
            {
                throw new Exception("Ya existe un usuario con este email");
            }
            userPort.Save(user);
            
        }

    }
}
