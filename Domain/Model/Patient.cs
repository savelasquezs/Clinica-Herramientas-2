using Clinica_Herramientas_2.Application.Adapters.Input.Validators;

namespace Clinica_Herramientas_2.Domain.Model
{
    enum Gender
    {
        Male, Female, Other
    }
    internal class Patient(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address,
        Gender gender, EmergencyContact emergencyContact, HealthInsurance insurance) : Person(fullname, dni, email, phonenumber, birthdate, address)
    {
        private Gender gender = gender;
        private EmergencyContact emergencyContact = emergencyContact ?? throw new ArgumentNullException(nameof(emergencyContact), "Debe registrar un contacto de emergencia.");
        private HealthInsurance insurance = insurance;

        public HealthInsurance Insurance { get => insurance; private set => insurance = value; }
        internal Gender Gender { get => gender; private set => gender = value; }
        internal EmergencyContact EmergencyContact { get => emergencyContact; private set => emergencyContact = value; }
        public void UpdateBasicInfo(string email, string phone, string address)
        {
            SetEmail(email);
            SetPhone(phone);
            SetAddress(address);
        }
    }

    class EmergencyContact
    {
        private string firtname;
        private string lastname;
        private string relationship;
        private string phoneNumber;
        
        public EmergencyContact(string firstname, string lastname, string relationship, string phoneNumber)
        {
            MyStringValidator.ValidateStringLength(firstname, nameof(Firtname), max: 100, min: 1);
            MyStringValidator.ValidateStringLength(lastname, nameof(Lastname), max: 100, min: 1);
            MyStringValidator.ValidateStringLength(relationship, nameof(Relationship), max: 50, min: 1);
            MyStringValidator.ValidateStringIsNumeric(phoneNumber, nameof(PhoneNumber));
            MyStringValidator.ValidateStringLength(phoneNumber, nameof(PhoneNumber), max: 10, min: 10);

            this.firtname = firstname.Trim();
            this.lastname = lastname.Trim();
            this.relationship = relationship.Trim();
            this.phoneNumber = phoneNumber.Trim();
        }

        public string Firtname { get => firtname; private set => firtname = value; }
        public string Lastname { get => lastname; private set => lastname = value; }
        public string Relationship { get => relationship; private set => relationship = value; }
        public string PhoneNumber { get => phoneNumber; private set => phoneNumber = value; }
    }

    public class HealthInsurance
    {
        private string _companyName;
        private string _policyNumber;
        private bool _isActive;
        private DateTime _expirationDate;
        
        public HealthInsurance(string companyName, string policyNumber, bool isActive, DateTime expirationDate)
        {
            MyStringValidator.ValidateStringLength(companyName, nameof(CompanyName), max: 100, min: 1);
            MyStringValidator.ValidateStringLength(policyNumber, nameof(PolicyNumber), max: 50, min: 1);
            MyDateValidator.ValidateDateNotInFuture(expirationDate, nameof(ExpirationDate));

            _companyName = companyName.Trim();
            _policyNumber = policyNumber.Trim();
            _isActive = isActive;
            _expirationDate = expirationDate;
        }

        public string CompanyName { get => _companyName; private set => _companyName = value; }
        public string PolicyNumber { get => _policyNumber; private set => _policyNumber = value; }
        public bool IsActive { get => _isActive; private set => _isActive = value; }
        public DateTime ExpirationDate { get => _expirationDate; private set => _expirationDate = value; }
    }
}
