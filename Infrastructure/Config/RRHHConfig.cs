using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Application.Adapters.Input.Builders;
using Clinica_Herramientas_2.Application.UseCases;
using Clinica_Herramientas_2.Domain.Ports;
using Clinica_Herramientas_2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Infrastructure.Config
{
    public class RRHHConfig
    {
        // Puertos
        public IUserPort UserPort { get; private set; }
        
        // Servicios
        public CreateUser CreateUserService { get; private set; }
        public UpdateUser UpdateUserService { get; private set; }
        public DeleteUser DeleteUserService { get; private set; }
        
        // Caso de uso
        public RRHHUseCase RRHHUseCase { get; private set; }
        
        // Builders
        public UserBuilder UserBuilder { get; private set; }
        
        // Input
        public RRHHInputs RRHHInputs { get; private set; }
        
        public RRHHConfig(IUserPort userPort)
        {
            // Puertos
            UserPort = userPort;
            
            // Servicios
            CreateUserService = new CreateUser(UserPort);
            UpdateUserService = new UpdateUser(UserPort);
            DeleteUserService = new DeleteUser(UserPort);
            
            // Caso de uso
            RRHHUseCase = new RRHHUseCase(
                CreateUserService,
                UpdateUserService,
                DeleteUserService
            );
            
            // Builders
            UserBuilder = new UserBuilder();
            
            // Input
            RRHHInputs = new RRHHInputs(
                UserBuilder,
                RRHHUseCase
            );
        }
    }
}
