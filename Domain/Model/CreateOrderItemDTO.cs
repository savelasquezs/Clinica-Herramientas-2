using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    public enum OrderItemType
    {
        Medication,
        Procedure,
        DiagnosticAid
    }

    public class CreateOrderItemDTO
    {
        public int OrderNumber { get; set; }
        public decimal Cost { get; set; }
        public OrderItemType ItemType { get; set; } // "Medication", "Procedure", "DiagnosticAid"
        
        // Medication specific
        public int? MedicationId { get; set; }
        public string? Dose { get; set; }
        public int? TreatmentDuration { get; set; }
        
        // Procedure specific
        public int? ProcedureId { get; set; }
        public int? Frequency { get; set; }
        public bool? RequiresSpecialist { get; set; }
        public int? SpecialistTypeId { get; set; }
        
        // DiagnosticAid specific
        public int? DiagnosticAidId { get; set; }
        public int? Quantity { get; set; }
    }
}
