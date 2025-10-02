using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Domain.Ports
{
    internal interface IMedicalRecordPort
    {
        void Save(MedicalRecord medicalRecord);
        MedicalRecord FindById(int id);
        List<MedicalRecord> FindByPatientDni(string patientDni);
        List<MedicalRecord> FindByDoctorDni(string doctorDni);
        List<MedicalRecord> FindByDateRange(DateTime startDate, DateTime endDate);
        List<MedicalRecord> FindAll();
        void Update(MedicalRecord medicalRecord);
        void Delete(int id);
    }
}
