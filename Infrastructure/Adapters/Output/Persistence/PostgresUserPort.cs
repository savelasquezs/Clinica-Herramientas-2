using Microsoft.EntityFrameworkCore;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PostgresUserPort : IUserPort
    {
        private readonly ClinicaDbContext context;
        
        public PostgresUserPort(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public User FindByDocument(string userDni)
        {
            return context.Users
                .Include(u => u.MedicalRecordsAsDoctor)
                .Include(u => u.NurseVisits)
                .Include(u => u.InvoicesAsDoctor)
                .FirstOrDefault(u => u.Dni == userDni);
        }
        
        public void Save(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        
        public void Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
        
        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
        
        public List<User> FindAll()
        {
            return context.Users.ToList();
        }
        
        public List<User> FindByRole(Role role)
        {
            return context.Users.Where(u => u.Role == role).ToList();
        }
        
        public User FindByUserName(User user)
        {
            return context.Users.FirstOrDefault(u => u.Username == user.Username);
        }
        
        public User FindByEmail(User user)
        {
            return context.Users.FirstOrDefault(u => u.Email == user.Email);
        }
    }
}
