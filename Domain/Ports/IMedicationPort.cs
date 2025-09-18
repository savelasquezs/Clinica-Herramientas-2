using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    internal interface IMedicationPort
    {
        Medication FindById(int id);
        void Save(Medication medication);
        void Update(Medication medication);
        void Delete(int id);
        IEnumerable<Medication> GetAll();
    }
}
