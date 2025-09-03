using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class ClinicalResource
    {
        private int id;
        private string name;
        private decimal cost;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Cost { get => cost; set => cost = value; }
    }

    internal class Medication : ClinicalResource
    {
    }
    internal class Procedure : ClinicalResource
    {
    }
    internal class DiagnosticAid : ClinicalResource
    {
    }
}
