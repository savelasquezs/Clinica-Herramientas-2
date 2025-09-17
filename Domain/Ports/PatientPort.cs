using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    interface IPatientPort
    {
        public Patient FindByDocument(Patient patient);
        public void Save(Patient patient);
        public void Update(Patient patient);
    }
}
