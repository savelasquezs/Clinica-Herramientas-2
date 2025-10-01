using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class PerformedProcedureValidator : SimpleValidator
    {
        public PerformedProcedureValidator() { }

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
