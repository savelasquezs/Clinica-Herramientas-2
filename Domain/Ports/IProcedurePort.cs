using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    public interface IProcedurePort
    {
        Procedure? FindById(int id);
        void Save(Procedure procedure);
        void Update(Procedure procedure);
        void Delete(int id);
        IEnumerable<Procedure> GetAll();
        List<Procedure> FindAll();
    }
}
