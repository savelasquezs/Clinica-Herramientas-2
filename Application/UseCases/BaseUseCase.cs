using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.UseCases
{
    internal abstract class BaseUseCase
    {
        protected ViewPatientInformation viewPatientInformation;
        protected User currentUser;

        protected BaseUseCase(ViewPatientInformation viewPatientInformation)
        {
            this.viewPatientInformation = viewPatientInformation;
        }

        protected void ValidateCurrentUser()
        {
            if (this.currentUser == null)
            {
                throw new Exception("Debe establecer un usuario válido");
            }
        }

        public Patient GetPatientByDni(string dni)
        {
            ValidateCurrentUser();
            return viewPatientInformation.GetPatientByDni(dni);
        }

        public List<Appointment> GetPatientAppointments(string patientDni)
        {
            ValidateCurrentUser();
            return viewPatientInformation.GetPatientAppointments(patientDni);
        }

        public List<Order> GetPatientOrders(string patientDni)
        {
            ValidateCurrentUser();
            return viewPatientInformation.GetPatientOrders(patientDni);
        }

        public List<Patient> GetAllPatients()
        {
            ValidateCurrentUser();
            return viewPatientInformation.GetAllPatients();
        }
    }
}
