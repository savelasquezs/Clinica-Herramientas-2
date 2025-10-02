using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    internal class NurseVisitBuilder
    {
        private NurseVisitValidator nurseVisitValidator;
        private VitalDataValidator vitalDataValidator;
        private AdministeredMedicationValidator administeredMedicationValidator;

        public NurseVisitBuilder()
        {
            nurseVisitValidator = new NurseVisitValidator();
            vitalDataValidator = new VitalDataValidator();
            administeredMedicationValidator = new AdministeredMedicationValidator();
        }

        internal NurseVisitValidator NurseVisitValidator { get => nurseVisitValidator; set => nurseVisitValidator = value; }
        internal VitalDataValidator VitalDataValidator { get => vitalDataValidator; set => vitalDataValidator = value; }
        internal AdministeredMedicationValidator AdministeredMedicationValidator { get => administeredMedicationValidator; set => administeredMedicationValidator = value; }

        public NurseVisit Create(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt,
            User nurse, string bloodPressure, double temperature, int pulse, int oxygenLevel, 
            List<AdministeredMedication> administeredMedications, DateTime visitTime, Patient patient)
        {
            nurseVisitValidator.ValidateNurseRole(nurse);

            var vitalData = new VitalData(
                vitalDataValidator.ValidateBloodPressure(bloodPressure),
                vitalDataValidator.ValidateTemperature(temperature),
                vitalDataValidator.ValidatePulse(pulse),
                vitalDataValidator.ValidateOxygenLevel(oxygenLevel)
            );

            return new NurseVisit(
                orderItem,
                nurseVisitValidator.ValidateTestsPerformed(testsPerformed),
                nurseVisitValidator.ValidateNotes(notes),
                nurseVisitValidator.ValidatePerformedAt(performedAt),
                nurse,
                vitalData,
                administeredMedications,
                nurseVisitValidator.ValidateVisitTime(visitTime),
                patient
            );
        }

        public VitalData CreateVitalData(string bloodPressure, double temperature, int pulse, int oxygenLevel)
        {
            return new VitalData(
                vitalDataValidator.ValidateBloodPressure(bloodPressure),
                vitalDataValidator.ValidateTemperature(temperature),
                vitalDataValidator.ValidatePulse(pulse),
                vitalDataValidator.ValidateOxygenLevel(oxygenLevel)
            );
        }

        public AdministeredMedication CreateAdministeredMedication(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt,
            Medication medication, string dose, string administrationRoute)
        {
            return new AdministeredMedication(
                orderItem,
                administeredMedicationValidator.ValidateTestsPerformed(testsPerformed),
                administeredMedicationValidator.ValidateNotes(notes),
                administeredMedicationValidator.ValidatePerformedAt(performedAt),
                medication,
                administeredMedicationValidator.ValidateDose(dose),
                administeredMedicationValidator.ValidateAdministrationRoute(administrationRoute)
            );
        }
    }
}
