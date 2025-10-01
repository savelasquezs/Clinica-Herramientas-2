using Clinica_Herramientas_2.Application.Adapters.Input.Validators;

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

        public Person(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address)
        {
            // Nombre completo
            MyStringValidator.ValidateStringLength(fullname, nameof(Fullname), max: 200, min: 1);
            this.fullname = fullname.Trim();

            // DNI: numérico, 1..10 dígitos
            MyStringValidator.ValidateStringIsNumeric(dni, nameof(Dni));
            MyStringValidator.ValidateStringLength(dni, nameof(Dni), max: 10, min: 1);
            this.dni = dni.Trim();

            // Email
            MyStringValidator.ValidateEmailConstruction(email, nameof(Email));
            this.email = email.Trim();

            // Teléfono: exactamente 10 dígitos
            MyStringValidator.ValidateStringIsNumeric(phonenumber, nameof(Phonenumber));
            MyStringValidator.ValidateStringLength(phonenumber, nameof(Phonenumber), max: 10, min: 10);
            this.phonenumber = phonenumber.Trim();

            // Fecha de nacimiento: máximo 150 años
            var birthdateDt = new DateTime(birthdate.Year, birthdate.Month, birthdate.Day);
            MyDateValidator.ValidateDateOfBith(birthdateDt, nameof(Birthdate), 0, 150);
            this.birthdate = birthdate;

            // Dirección: máximo 30 caracteres
            MyStringValidator.ValidateStringLength(address, nameof(Address), max: 30, min: 1);
            this.address = address.Trim();
        }

        public string Fullname { get => fullname; private set => fullname = value; }
        public string Dni { get => dni; private set => dni = value; }
        public string Email { get => email; private set => email = value; }
        public string Phonenumber { get => phonenumber; private set => phonenumber = value; }
        public DateOnly Birthdate { get => birthdate; private set => birthdate = value; }
        public string Address { get => address; private set => address = value; }

        internal void SetEmail(string email)
        {
            MyStringValidator.ValidateEmailConstruction(email, nameof(Email));
            this.email = email.Trim();
        }

        internal void SetPhone(string phone)
        {
            MyStringValidator.ValidateStringIsNumeric(phone, nameof(Phonenumber));
            MyStringValidator.ValidateStringLength(phone, nameof(Phonenumber), max: 10, min: 10);
            this.phonenumber = phone.Trim();
        }

        internal void SetAddress(string address)
        {
            MyStringValidator.ValidateStringLength(address, nameof(Address), max: 30, min: 1);
            this.address = address.Trim();
        }

    }
}
    
