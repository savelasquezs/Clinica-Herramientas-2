using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class EmergencyContactValidator : SimpleValidator
    {
        public EmergencyContactValidator() { }

        public string ValidateFirstName(string firstName)
        {
            ValidateStringLength(firstName, "FirstName", max: 100, min: 1);
            return firstName.Trim();
        }

        public string ValidateLastName(string lastName)
        {
            ValidateStringLength(lastName, "LastName", max: 100, min: 1);
            return lastName.Trim();
        }

        public string ValidateRelationship(string relationship)
        {
            ValidateStringLength(relationship, "Relationship", max: 50, min: 1);
            return relationship.Trim();
        }

        public string ValidatePhoneNumber(string phoneNumber)
        {
            ValidateStringIsNumeric(phoneNumber, "PhoneNumber");
            ValidateStringLength(phoneNumber, "PhoneNumber", max: 10, min: 10);
            return phoneNumber.Trim();
        }
    }
}
