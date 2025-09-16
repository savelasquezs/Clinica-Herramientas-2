using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class Appointment
    {
        private int Id;
        private Patient Patient;
        private DateTime Date;

        public int Id1 { get => Id; set => Id = value; }
        public DateTime Date1 { get => Date; set => Date = value; }
        internal Patient Patient1 { get => Patient; set => Patient = value; }
    }
}
