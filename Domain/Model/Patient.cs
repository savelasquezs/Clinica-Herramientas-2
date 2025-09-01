using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    enum Gender
    {
        Male, Female, Other
    }
    internal class Patient:Person
    {
        private Gender gender;
        private EmergencyContact emergencyContact;
        private HealthInsurance healthInsurance;

        public HealthInsurance HealthInsurance { get => healthInsurance; set => healthInsurance = value; }
        internal Gender Gender { get => gender; set => gender = value; }
        internal EmergencyContact EmergencyContact { get => emergencyContact; set => emergencyContact = value; }
    }
}
