using Clinica_Herramientas_2.Domain.Model.Validations;
using Clinica_Herramientas_2.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private DateOnly dateOfBirth;
        private string address;

        public string Name { get => name; set => name = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Email { get => email; set => email = value; }
        public string Cellphone { get => cellphone; set => cellphone = value; }
        public DateOnly DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Address { get => address; set => address = value; }
    }
}
    
