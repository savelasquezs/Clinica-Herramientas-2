using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    internal class UserBuilder
    {
        private PersonValidator personValidator;
        private UserValidator userValidator;

        public UserBuilder()
        {
            personValidator = new PersonValidator();
            userValidator = new UserValidator();
        }

        internal PersonValidator PersonValidator { get => personValidator; set => personValidator = value; }
        internal UserValidator UserValidator { get => userValidator; set => userValidator = value; }

        public User Create(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address,
            Role role, string username, string password)
        {
            return new User(
                personValidator.ValidateFullname(fullname),
                personValidator.ValidateDni(dni),
                personValidator.ValidateEmail(email),
                personValidator.ValidatePhoneNumber(phonenumber),
                personValidator.ValidateBirthdate(birthdate),
                personValidator.ValidateAddress(address),
                role,
                userValidator.ValidateUsername(username),
                userValidator.ValidatePassword(password)
            );
        }
    }
}
