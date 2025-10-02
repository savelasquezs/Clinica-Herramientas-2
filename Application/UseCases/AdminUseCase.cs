using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.UseCases
{
    internal class AdminUseCase
    {
        private CreatePatient createPatient;
        private UpdatePatient updatePatient;
        private CreateAppointment createAppointment;
        private CreateInvoice createInvoice;
        private ViewPatientInformation viewPatientInformation;
        private User currentUser;

        internal CreatePatient CreatePatient { get => createPatient; set => createPatient = value; }
        internal UpdatePatient UpdatePatient { get => updatePatient; set => updatePatient = value; }
        internal CreateAppointment CreateAppointment { get => createAppointment; set => createAppointment = value; }
        internal CreateInvoice CreateInvoice { get => createInvoice; set => createInvoice = value; }
        internal ViewPatientInformation ViewPatientInformation { get => viewPatientInformation; set => viewPatientInformation = value; }
        internal User CurrentUser { get => currentUser; set => currentUser = value; }

        public AdminUseCase(CreatePatient createPatient, UpdatePatient updatePatient, CreateAppointment createAppointment, CreateInvoice createInvoice, ViewPatientInformation viewPatientInformation)
        {
            this.CreatePatient = createPatient;
            this.UpdatePatient = updatePatient;
            this.CreateAppointment = createAppointment;
            this.CreateInvoice = createInvoice;
            this.ViewPatientInformation = viewPatientInformation;
        }

        public void SetCurrentUser(User user)
        {
            if (user.Role != Role.Admin)
            {
                throw new Exception("Solo usuarios administrativos pueden acceder a esta funcionalidad");
            }
            this.CurrentUser = user;
        }

        public void CreatePatient(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address, Gender gender, string emergencyFirstName, string emergencyLastName, string emergencyRelationship, string emergencyPhone, string insuranceCompanyName, string insurancePolicyNumber, bool insuranceIsActive, DateTime insuranceExpirationDate)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            var emergencyContact = new EmergencyContact(emergencyFirstName, emergencyLastName, emergencyRelationship, emergencyPhone);
            var healthInsurance = new HealthInsurance(insuranceCompanyName, insurancePolicyNumber, insuranceIsActive, insuranceExpirationDate);
            var patient = new Patient(fullname, dni, email, phonenumber, birthdate, address, gender, emergencyContact, healthInsurance);

            CreatePatient.Create(this.CurrentUser, patient);
        }

        public void UpdatePatient(Patient patient, string email, string phone, string address)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            UpdatePatient.Update(this.CurrentUser, patient, email, phone, address);
        }

        public void CreateAppointment(int id, string patientDni, DateTime date)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            var appointment = new Appointment(id, null, date); // El paciente se valida en el servicio
            CreateAppointment.Create(appointment, patientDni);
        }

        public Invoice CreateInvoice(int invoiceNumber, string patientDni, string doctorDni, List<int> orderNumbers, DateTime invoiceDate)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            return CreateInvoice.Create(invoiceNumber, patientDni, doctorDni, orderNumbers, invoiceDate);
        }

        public Patient GetPatientByDni(string dni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            return ViewPatientInformation.GetPatientByDni(dni);
        }

        public List<Appointment> GetPatientAppointments(string patientDni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            return ViewPatientInformation.GetPatientAppointments(patientDni);
        }

        public List<Order> GetPatientOrders(string patientDni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            return ViewPatientInformation.GetPatientOrders(patientDni);
        }

        public List<Patient> GetAllPatients()
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            return ViewPatientInformation.GetAllPatients();
        }
    }
}
