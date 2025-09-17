using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    interface IUserPort
    {

        public User FindByDocument(User user);
        public User FindByUserName(User user);
        public User FindByEmail(User user);
        public void Save(User user);
        public void Update(User user);
        public void Delete(User user);


    }
}
