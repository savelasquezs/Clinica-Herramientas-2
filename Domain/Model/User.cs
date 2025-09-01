using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{

    enum Role
    {
        Admin,
        Doctor,
        Nurse,
        RRHH
    }
    class User:Person
    {
        private  Role role;
        private string username;
        private string password;

        public Role Role { get => role; set => role = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
