using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Validators
{
    internal class MedicalRecordValidator : SimpleValidator
    {
        public MedicalRecordValidator() { }

        public DateTime ValidateDate(DateTime date)
        {
            ValidateDateNotInFuture(date, "Date");
            return date;
        }

        public string ValidateConsultationReason(string consultationReason)
        {
            ValidateStringLength(consultationReason, "ConsultationReason", max: 500, min: 1);
            return consultationReason.Trim();
        }

        public string ValidateSymptoms(string symptoms)
        {
            ValidateStringLength(symptoms, "Symptoms", max: 1000, min: 1);
            return symptoms.Trim();
        }

        public string ValidateDiagnosis(string diagnosis)
        {
            ValidateStringLength(diagnosis, "Diagnosis", max: 1000, min: 1);
            return diagnosis.Trim();
        }
    }
}
