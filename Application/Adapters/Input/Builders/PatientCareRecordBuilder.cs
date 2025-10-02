using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    internal class PatientCareRecordBuilder
    {
        private PerformedProcedureValidator performedProcedureValidator;

        public PatientCareRecordBuilder()
        {
            performedProcedureValidator = new PerformedProcedureValidator();
        }

        internal PerformedProcedureValidator PerformedProcedureValidator { get => performedProcedureValidator; set => performedProcedureValidator = value; }

        public PatientCareRecord Create(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt)
        {
            return new PatientCareRecord(
                orderItem,
                performedProcedureValidator.ValidateTestsPerformed(testsPerformed),
                performedProcedureValidator.ValidateNotes(notes),
                performedProcedureValidator.ValidatePerformedAt(performedAt)
            );
        }

        public PerformedProcedure CreatePerformedProcedure(OrderItem orderItem, string testsPerformed, string notes, DateTime performedAt)
        {
            return new PerformedProcedure(
                orderItem,
                performedProcedureValidator.ValidateTestsPerformed(testsPerformed),
                performedProcedureValidator.ValidateNotes(notes),
                performedProcedureValidator.ValidatePerformedAt(performedAt)
            );
        }
    }
}
