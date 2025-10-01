namespace Clinica_Herramientas_2.Domain.Model
{

    enum Role
    {
        Admin,
        Doctor,
        Nurse,
        RRHH,
        Support
    }
    class User:Person
    {
        private  Role role;
        private string username;
        private string password;
        
        public User(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address,
            Role role, string username, string password)
            : base(fullname, dni, email, phonenumber, birthdate, address)
        {
            this.role = role;
            this.username = username.Trim();
            this.password = password;
        }

        public Role Role { get => role; private set => role = value; }
        public string Username { get => username; private set => username = value; }
        public string Password { get => password; private set => password = value; }
    }
}
