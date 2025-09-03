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
        private HealthInsurance insurance;

        public HealthInsurance Insurance { get => insurance; set => insurance = value; }
        internal Gender Gender { get => gender; set => gender = value; }
        internal EmergencyContact EmergencyContact { get => emergencyContact; set => emergencyContact = value; }
    }

    class EmergencyContact
    {
        private string firtname;
        private string lastname;
        private string relationship;
        private string phoneNumber;

        public string Firtname { get => firtname; set => firtname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Relationship { get => relationship; set => relationship = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }

    public class HealthInsurance
    {
        private string _companyName;
        private string _policyNumber;
        private bool _isActive;
        private DateTime _expirationDate;

        public string CompanyName { get => _companyName; set => _companyName = value; }
        public string PolicyNumber { get => _policyNumber; set => _policyNumber = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public DateTime ExpirationDate { get => _expirationDate; set => _expirationDate = value; }
    }
}
