using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class PersonValidator : SimpleValidator
    {
        public PersonValidator() { }

        public string ValidateFullname(string fullname)
        {
            ValidateStringLength(fullname, "Fullname", max: 200, min: 1);
            return fullname.Trim();
        }

        public string ValidateDni(string dni)
        {
            ValidateStringIsNumeric(dni, "Dni");
            ValidateStringLength(dni, "Dni", max: 10, min: 1);
            return dni.Trim();
        }

        public string ValidateEmail(string email)
        {
            ValidateEmailConstruction(email, "Email");
            return email.Trim();
        }

        public string ValidatePhoneNumber(string phoneNumber)
        {
            ValidateStringIsNumeric(phoneNumber, "PhoneNumber");
            ValidateStringLength(phoneNumber, "PhoneNumber", max: 10, min: 10);
            return phoneNumber.Trim();
        }

        public DateOnly ValidateBirthdate(DateOnly birthdate)
        {
            var birthdateDt = new DateTime(birthdate.Year, birthdate.Month, birthdate.Day);
            ValidateDateOfBirth(birthdateDt, "Birthdate", 0, 150);
            return birthdate;
        }

        public string ValidateAddress(string address)
        {
            ValidateStringLength(address, "Address", max: 30, min: 1);
            return address.Trim();
        }
    }
}
