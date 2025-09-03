using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Model
{
    internal class PatientCareRecord
    {
        private OrderItem orderItem;
        private string testsPerformed;
        private string notes;
        private DateTime performedAt;

    }
    class AdministeredMedication : PatientCareRecord
    {
        private Medication medication;
        private string dose;
        private string administrationRoute;

        public string Dose { get => dose; set => dose = value; }
        public string AdministrationRoute { get => administrationRoute; set => administrationRoute = value; }
    }
    class PerformedProcedure : PatientCareRecord
    {
        
    }

}
