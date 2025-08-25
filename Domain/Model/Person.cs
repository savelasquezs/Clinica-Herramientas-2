using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class Person
    {

        private string name;
        private string dni;
        private string email;
        private string cellphone;

        public string Name { get => name; set => name = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Email { get => email; set => email = value; }
        public string Cellphone { get => cellphone; set => cellphone = value; }
    }
}
