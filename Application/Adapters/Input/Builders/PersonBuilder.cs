using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    internal class PersonBuilder
    {
        private PersonValidator personValidator;

        public PersonBuilder()
        {
            personValidator = new PersonValidator();
        }

        internal PersonValidator PersonValidator { get => personValidator; set => personValidator = value; }

        public Person Create(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address)
        {
            return new Person(
                personValidator.ValidateFullname(fullname),
                personValidator.ValidateDni(dni),
                personValidator.ValidateEmail(email),
                personValidator.ValidatePhoneNumber(phonenumber),
                personValidator.ValidateBirthdate(birthdate),
                personValidator.ValidateAddress(address)
            );
        }
    }
}
