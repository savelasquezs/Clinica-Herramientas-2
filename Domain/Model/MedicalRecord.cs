using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Clinica_Herramientas_2.Domain.Model
{
    public class MedicalRecord(DateTime date, Patient patient, User doctor, string consultationReason, string symptoms, string diagnosis, Order order)
    {
        private int id;
        private DateTime date = date;
        private Patient patient = patient;
        private User doctor = doctor;
        private string consultationReason = consultationReason;
        private string symptoms = symptoms;
        private string diagnosis = diagnosis;
        private Order order = order;

        // Constructor protegido para EF Core
        protected MedicalRecord() : this(DateTime.MinValue, null!, null!, "", "", "", null!) { }

        public int Id { get => id; private set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string ConsultationReason { get => consultationReason; set => consultationReason = value; }
        public string Symptoms { get => symptoms; set => symptoms = value; }
        public string Diagnosis { get => diagnosis; set => diagnosis = value; }
        internal Patient Patient { get => patient; set => patient = value; }
        internal User Doctor { get => doctor; set => doctor = value; }
        internal Order Order { get => order; set => order = value; }
    }
}
