using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class MedicalRecord
    {
        private DateTime date;
        private Patient patient;
        private User doctor;
        private string consultationReason;
        private string symptoms;
        private string diagnosis;
        private Order order;

        public DateTime Date { get => date; set => date = value; }
        public string ConsultationReason { get => consultationReason; set => consultationReason = value; }
        public string Symptoms { get => symptoms; set => symptoms = value; }
        public string Diagnosis { get => diagnosis; set => diagnosis = value; }
        internal Patient Patient { get => patient; set => patient = value; }
        internal User Doctor { get => doctor; set => doctor = value; }
        internal Order Order { get => order; set => order = value; }
    }
}
