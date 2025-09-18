using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    internal interface IDiagnosticAidPort
    {
        DiagnosticAid FindById(int id);
        void Save(DiagnosticAid aid);
        void Update(DiagnosticAid aid);
        void Delete(int id);
        IEnumerable<DiagnosticAid> GetAll();
    }
}
