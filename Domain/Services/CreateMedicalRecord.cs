using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Services
{
    internal class CreateMedicalRecord
    {
        private readonly IPatientPort patientPort;
        private readonly IUserPort userPort;
        private readonly IOrderPort orderPort;
        private readonly IMedicalRecordPort medicalRecordPort;

        public CreateMedicalRecord(IPatientPort patientPort, IUserPort userPort, IOrderPort orderPort, IMedicalRecordPort medicalRecordPort)
        {
            this.patientPort = patientPort;
            this.userPort = userPort;
            this.orderPort = orderPort;
            this.medicalRecordPort = medicalRecordPort;
        }

        public void Create(MedicalRecord medicalRecord)
        {
            // Validar que el paciente existe
            _ = patientPort.FindByDocument(medicalRecord.Patient.Dni) ?? throw new Exception("El paciente no existe");

            // Validar que el doctor existe y tiene rol correcto
            var doctor = userPort.FindByDocument(medicalRecord.Doctor.Dni) ?? throw new Exception("El médico no existe");
            if (doctor.Role != Role.Doctor)
            {
                throw new Exception("El usuario no tiene rol de médico");
            }

            // Validar que la orden existe (si se proporciona)
            if (medicalRecord.Order != null)
            {
                _ = orderPort.FindByNumber(medicalRecord.Order.OrderNumber) ?? throw new Exception("La orden no existe");
            }

            // Guardar en la base de datos relacional
            medicalRecordPort.Save(medicalRecord);
        }
    }
}
