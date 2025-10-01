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
            this.fullname = fullname.Trim();
            this.dni = dni.Trim();
            this.email = email.Trim();
            this.phonenumber = phonenumber.Trim();
            this.birthdate = birthdate;
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
            this.email = email.Trim();
        }

        internal void SetPhone(string phone)
        {
            this.phonenumber = phone.Trim();
        }

        internal void SetAddress(string address)
        {
            this.address = address.Trim();
        }

    }
}
    
