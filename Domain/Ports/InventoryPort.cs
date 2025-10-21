using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    public interface IInventoryPort
    {
        public Medication FindMedicationById(int id);
        public Procedure FindProcedureById(int id);
        public DiagnosticAid FindDiagnosticAidById(int id);
    }
}

