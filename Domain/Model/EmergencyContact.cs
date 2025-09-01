using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    class EmergencyContact : Person
    {
        private string relationship;

        public string Relationship { get => relationship; set => relationship = value; }
    }
}
