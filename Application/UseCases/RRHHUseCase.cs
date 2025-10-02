using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.UseCases
{
    internal class RRHHUseCase
    {
        private CreateUser createUser;
        private UpdateUser updateUser;
        private DeleteUser deleteUser;
        private User currentUser;

        internal CreateUser CreateUser { get => createUser; set => createUser = value; }
        internal UpdateUser UpdateUser { get => updateUser; set => updateUser = value; }
        internal DeleteUser DeleteUser { get => deleteUser; set => deleteUser = value; }
        internal User CurrentUser { get => currentUser; set => currentUser = value; }

        public RRHHUseCase(CreateUser createUser, UpdateUser updateUser, DeleteUser deleteUser)
        {
            this.CreateUser = createUser;
            this.UpdateUser = updateUser;
            this.DeleteUser = deleteUser;
        }

        public void SetCurrentUser(User user)
        {
            if (user.Role != Role.RRHH)
            {
                throw new Exception("Solo usuarios de RRHH pueden acceder a esta funcionalidad");
            }
            this.CurrentUser = user;
        }

        public void CreateUser(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address, Role role, string username, string password)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario de RRHH válido");
            }

            var newUser = new User(fullname, dni, email, phonenumber, birthdate, address, role, username, password);
            CreateUser.Create(this.CurrentUser, newUser);
        }

        public void UpdateUser(User userToUpdate, string fullname, string email, string phonenumber, string address)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario de RRHH válido");
            }

            UpdateUser.Update(this.CurrentUser, userToUpdate, fullname, email, phonenumber, address);
        }

        public void DeleteUser(User userToDelete)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario de RRHH válido");
            }

            DeleteUser.Delete(this.CurrentUser, userToDelete);
        }
    }
}
