using Clinica_Herramientas_2.Application.Adapters.Input.Validators;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.Adapters.Input.Builders
{
    public class MedicalRecordBuilder
    {
        private MedicalRecordValidator medicalRecordValidator;

        public MedicalRecordBuilder()
        {
            medicalRecordValidator = new MedicalRecordValidator();
        }

        internal MedicalRecordValidator MedicalRecordValidator { get => medicalRecordValidator; set => medicalRecordValidator = value; }

        public MedicalRecord Create(DateTime date, Patient patient, User doctor, string consultationReason, string symptoms, string diagnosis, Order order)
        {
            return new MedicalRecord(
                medicalRecordValidator.ValidateDate(date),
                patient,
                doctor,
                medicalRecordValidator.ValidateConsultationReason(consultationReason),
                medicalRecordValidator.ValidateSymptoms(symptoms),
                medicalRecordValidator.ValidateDiagnosis(diagnosis),
                order
            );
        }
    }
}
