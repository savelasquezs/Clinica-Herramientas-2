using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class OrderItem
    {
        private int orderNumber;
        private int itemNumber;
        private decimal cost;

        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public int ItemNumber { get => itemNumber; set => itemNumber = value; }
        public decimal Cost { get => cost; set => cost = value; }
    }
    class MedicationOrderItem : OrderItem
    {
        private Medication medication;
        private string dose;
        private int treatmentDuration;

        public Medication Medication { get => medication; set => medication = value; }
        public string Dose { get => dose; set => dose = value; }
        public int TreatmentDuration { get => treatmentDuration; set => treatmentDuration = value; }
    }

    class ProcedureOrderItem : OrderItem
    {
        private Procedure procedure;
        private int frequency;
        private bool requiresSpecialist;
        private int? specialistTypeId;

        public Procedure Procedure { get => procedure; set => procedure = value; }
        public int Frequency { get => frequency; set => frequency = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; set => specialistTypeId = value; }
    }

    class DiagnosticAidOrderItem : OrderItem
    {
        private DiagnosticAid diagnosticAid;
        private int quantity;
        private bool requiresSpecialist;
        private int? specialistTypeId;

        public DiagnosticAid DiagnosticAid { get => diagnosticAid; set => diagnosticAid = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; set => specialistTypeId = value; }
    }
}
