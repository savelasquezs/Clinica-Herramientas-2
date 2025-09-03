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

        private string fullname;
        private string dni;
        private string email;
        private string phonenumber;
        private DateOnly birthdate;
        private string address;

        public string Fullname { get => fullname; set => fullname = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Email { get => email; set => email = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public DateOnly Birthdate { get => birthdate; set => birthdate = value; }
        public string Address { get => address; set => address = value; }
    }
}
    
