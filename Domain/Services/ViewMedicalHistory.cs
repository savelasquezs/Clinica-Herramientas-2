using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class ViewMedicalHistory
    {
        private readonly IPatientPort patientPort;
        private readonly IUserPort userPort;
        private readonly IMedicalRecordPort medicalRecordPort;

        public ViewMedicalHistory(IPatientPort patientPort, IUserPort userPort, IMedicalRecordPort medicalRecordPort)
        {
            this.patientPort = patientPort;
            this.userPort = userPort;
            this.medicalRecordPort = medicalRecordPort;
        }

        public List<MedicalRecord> GetMedicalHistory(string patientDni, User requestingUser)
        {
            // Validar que el paciente existe
            _ = patientPort.FindByDocument(patientDni) ?? throw new Exception("El paciente no existe");

            // Validar que el usuario tiene permisos para ver la historia clínica
            if (requestingUser.Role != Role.Doctor && requestingUser.Role != Role.Nurse)
            {
                throw new Exception("Solo médicos y enfermeras pueden ver la historia clínica");
            }

            // Obtener la historia clínica desde la base de datos relacional
            return medicalRecordPort.FindByPatientDni(patientDni);
        }

        public void AddMedicalRecord(string patientDni, DateTime date, string doctorDni, string consultationReason, string symptoms, string diagnosis, User performingUser)
        {
            // Validar que el usuario tiene permisos para agregar registros
            if (performingUser.Role != Role.Doctor)
            {
                throw new Exception("Solo los médicos pueden agregar registros a la historia clínica");
            }

            // Validar que el paciente existe
            var patient = patientPort.FindByDocument(patientDni) ?? throw new Exception("El paciente no existe");

            // Validar que el doctor existe
            var doctor = userPort.FindByDocument(doctorDni) ?? throw new Exception("El médico no existe");

            // Crear el registro de historia clínica
            var medicalRecord = new MedicalRecord(date, patient, doctor, consultationReason, symptoms, diagnosis, null);

            // Guardar en la base de datos relacional
            medicalRecordPort.Save(medicalRecord);
        }
    }
}
