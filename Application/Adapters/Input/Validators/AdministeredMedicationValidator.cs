using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class AdministeredMedicationValidator : SimpleValidator
    {
        public AdministeredMedicationValidator() { }

        public string ValidateDose(string dose)
        {
            ValidateStringLength(dose, "Dose", max: 50, min: 1);
            return dose.Trim();
        }

        public string ValidateAdministrationRoute(string administrationRoute)
        {
            ValidateStringLength(administrationRoute, "AdministrationRoute", max: 50, min: 1);
            return administrationRoute.Trim();
        }

        public string ValidateTestsPerformed(string testsPerformed)
        {
            if (!string.IsNullOrWhiteSpace(testsPerformed))
            {
                ValidateStringLength(testsPerformed, "TestsPerformed", max: 2000, min: 1);
            }
            return testsPerformed;
        }

        public string ValidateNotes(string notes)
        {
            if (!string.IsNullOrWhiteSpace(notes))
            {
                ValidateStringLength(notes, "Notes", max: 2000, min: 1);
            }
            return notes;
        }

        public DateTime ValidatePerformedAt(DateTime performedAt)
        {
            ValidateDateNotInFuture(performedAt, "PerformedAt");
            return performedAt;
        }
    }
}
