using Clinica_Herramientas_2.Application.Adapters.Input.Builders;
using Clinica_Herramientas_2.Application.UseCases;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input
{
    public class RRHHInputs
    {
        private UserBuilder userBuilder;
        private RRHHUseCase rrhhUseCase;
        
        public RRHHInputs(
            UserBuilder userBuilder,
            RRHHUseCase rrhhUseCase)
        {
            this.userBuilder = userBuilder;
            this.rrhhUseCase = rrhhUseCase;
        }
        
        public void CreateUser(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address, Role role, string username, string password)
        {
            // Usar builder para crear usuario
            var user = userBuilder.Create(fullname, dni, email, phonenumber, birthdate, address, role, username, password);
            
            // Llamar a rrhhUseCase.CreateNewUser()
            rrhhUseCase.CreateNewUser(fullname, dni, email, phonenumber, birthdate, address, role, username, password);
        }
        
        public void UpdateUser(User userToUpdate, string fullname, string email, string phonenumber, string address)
        {
            rrhhUseCase.UpdateExistingUser(userToUpdate, fullname, email, phonenumber, address);
        }
        
        public void DeleteUser(User userToDelete)
        {
            rrhhUseCase.DeleteExistingUser(userToDelete);
        }
    }
}
