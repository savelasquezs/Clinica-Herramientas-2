using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    internal class ClinicalResourceBuilder
    {
        private ClinicalResourceValidator clinicalResourceValidator;

        public ClinicalResourceBuilder()
        {
            clinicalResourceValidator = new ClinicalResourceValidator();
        }

        internal ClinicalResourceValidator ClinicalResourceValidator { get => clinicalResourceValidator; set => clinicalResourceValidator = value; }

        public ClinicalResource Create(int id, string name, decimal cost)
        {
            return new ClinicalResource(
                clinicalResourceValidator.ValidateId(id),
                clinicalResourceValidator.ValidateName(name),
                clinicalResourceValidator.ValidateCost(cost)
            );
        }

        public Medication CreateMedication(int id, string name, decimal cost, string defaultDose, int treatmentDurationDays)
        {
            return new Medication(
                clinicalResourceValidator.ValidateId(id),
                clinicalResourceValidator.ValidateName(name),
                clinicalResourceValidator.ValidateCost(cost),
                clinicalResourceValidator.ValidateDose(defaultDose),
                clinicalResourceValidator.ValidateTreatmentDuration(treatmentDurationDays)
            );
        }

        public Procedure CreateProcedure(int id, string name, decimal cost, int frequency, bool requiresSpecialist, int? specialistTypeId)
        {
            clinicalResourceValidator.ValidateSpecialistRequirement(requiresSpecialist, specialistTypeId);
            
            return new Procedure(
                clinicalResourceValidator.ValidateId(id),
                clinicalResourceValidator.ValidateName(name),
                clinicalResourceValidator.ValidateCost(cost),
                clinicalResourceValidator.ValidateFrequency(frequency),
                requiresSpecialist,
                specialistTypeId
            );
        }

        public DiagnosticAid CreateDiagnosticAid(int id, string name, decimal cost, int quantity, bool requiresSpecialist, int? specialistTypeId)
        {
            clinicalResourceValidator.ValidateSpecialistRequirement(requiresSpecialist, specialistTypeId);
            
            return new DiagnosticAid(
                clinicalResourceValidator.ValidateId(id),
                clinicalResourceValidator.ValidateName(name),
                clinicalResourceValidator.ValidateCost(cost),
                clinicalResourceValidator.ValidateQuantity(quantity),
                requiresSpecialist,
                specialistTypeId
            );
        }
    }
}
