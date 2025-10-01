using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
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

        public OrderItem(int orderNumber, int itemNumber, decimal cost)
        {
            if (orderNumber <= 0)
            {
                throw new ArgumentException("OrderNumber debe ser mayor que cero.");
            }
            if (itemNumber <= 0)
            {
                throw new ArgumentException("ItemNumber debe ser mayor que cero.");
            }
            if (cost < 0)
            {
                throw new ArgumentException("Cost no puede ser negativo.");
            }
            this.orderNumber = orderNumber;
            this.itemNumber = itemNumber;
            this.cost = cost;
        }

        public int OrderNumber { get => orderNumber; private set => orderNumber = value; }
        public int ItemNumber { get => itemNumber; private set => itemNumber = value; }
        public decimal Cost { get => cost; private set => cost = value; }
    }
    class MedicationOrderItem : OrderItem
    {
        private Medication medication;
        private string dose;
        private int treatmentDuration;

        public MedicationOrderItem(int orderNumber, int itemNumber, decimal cost, Medication medication, string dose, int treatmentDuration)
            : base(orderNumber, itemNumber, cost)
        {
            ArgumentNullException.ThrowIfNull(medication);
            MyStringValidator.ValidateStringLength(dose, nameof(Dose), max: 50, min: 1);
            if (treatmentDuration <= 0)
            {
                throw new ArgumentException("TreatmentDuration debe ser mayor que cero.");
            }
            this.medication = medication;
            this.dose = dose.Trim();
            this.treatmentDuration = treatmentDuration;
        }

        public Medication Medication { get => medication; private set => medication = value; }
        public string Dose { get => dose; private set => dose = value; }
        public int TreatmentDuration { get => treatmentDuration; private set => treatmentDuration = value; }
    }

    class ProcedureOrderItem : OrderItem
    {
        private Procedure procedure;
        private int frequency;
        private bool requiresSpecialist;
        private int? specialistTypeId;

        public ProcedureOrderItem(int orderNumber, int itemNumber, decimal cost, Procedure procedure, int frequency, bool requiresSpecialist, int? specialistTypeId)
            : base(orderNumber, itemNumber, cost)
        {
         ArgumentNullException.ThrowIfNull(procedure);
            if (frequency <= 0)
            {
                throw new ArgumentException("Frequency debe ser mayor que cero.");
            }
            if (!requiresSpecialist && specialistTypeId.HasValue)
            {
                throw new ArgumentException("SpecialistTypeId solo aplica cuando RequiresSpecialist es verdadero.");
            }
            this.procedure = procedure;
            this.frequency = frequency;
            this.requiresSpecialist = requiresSpecialist;
            this.specialistTypeId = specialistTypeId;
        }

        public Procedure Procedure { get => procedure; private set => procedure = value; }
        public int Frequency { get => frequency; private set => frequency = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; private set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; private set => specialistTypeId = value; }
    }

    class DiagnosticAidOrderItem : OrderItem
    {
        private DiagnosticAid diagnosticAid;
        private int quantity;
        private bool requiresSpecialist;
        private int? specialistTypeId;

        public DiagnosticAidOrderItem(int orderNumber, int itemNumber, decimal cost, DiagnosticAid diagnosticAid, int quantity, bool requiresSpecialist, int? specialistTypeId)
            : base(orderNumber, itemNumber, cost)
        {
         ArgumentNullException.ThrowIfNull(diagnosticAid);
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity debe ser mayor que cero.");
            }
            if (!requiresSpecialist && specialistTypeId.HasValue)
            {
                throw new ArgumentException("SpecialistTypeId solo aplica cuando RequiresSpecialist es verdadero.");
            }
            this.diagnosticAid = diagnosticAid;
            this.quantity = quantity;
            this.requiresSpecialist = requiresSpecialist;
            this.specialistTypeId = specialistTypeId;
        }

        public DiagnosticAid DiagnosticAid { get => diagnosticAid; private set => diagnosticAid = value; }
        public int Quantity { get => quantity; private set => quantity = value; }
        public bool RequiresSpecialist { get => requiresSpecialist; private set => requiresSpecialist = value; }
        public int? SpecialistTypeId { get => specialistTypeId; private set => specialistTypeId = value; }
    }
}
