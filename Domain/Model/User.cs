using Clinica_Herramientas_2.Domain.Model.Validations;

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
            // Rol requerido
            this.role = role;

            // Username: único (a nivel de repositorio), máx 15, alfanumérico
            MyStringValidator.ValidateStringLength(username, nameof(Username), max: 15, min: 1);
            MyStringValidator.ValidateStringIsAlphaNumeric(username, nameof(Username));
            this.username = username.Trim();

            // Password: >=8, con mayúscula, número y carácter especial
            MyStringValidator.ValidateStringLength(password, nameof(Password), max: null, min: 8);
            if (!password.Any(char.IsUpper) || !password.Any(char.IsDigit) || password.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("La contraseña debe incluir una mayúscula, un número y un carácter especial.");
            }
            this.password = password;
        }

        public Role Role { get => role; private set => role = value; }
        public string Username { get => username; private set => username = value; }
        public string Password { get => password; private set => password = value; }
    }
}
