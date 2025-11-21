using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.UseCases
{
    public class AdminUseCase : BaseUseCase
    {
        private CreatePatient createPatient;
        private UpdatePatient updatePatient;
        private CreateAppointment createAppointment;
        private CreateInvoice createInvoice;

        internal CreatePatient CreatePatient { get => createPatient; set => createPatient = value; }
        internal UpdatePatient UpdatePatient { get => updatePatient; set => updatePatient = value; }
        internal CreateAppointment CreateAppointment { get => createAppointment; set => createAppointment = value; }
        internal CreateInvoice CreateInvoice { get => createInvoice; set => createInvoice = value; }
        internal User CurrentUser { get => currentUser; set => currentUser = value; }

        public AdminUseCase(CreatePatient createPatient, UpdatePatient updatePatient, CreateAppointment createAppointment, CreateInvoice createInvoice, ViewPatientInformation viewPatientInformation)
            : base(viewPatientInformation)
        {
            this.createPatient = createPatient;
            this.updatePatient = updatePatient;
            this.createAppointment = createAppointment;
            this.createInvoice = createInvoice;
        }

        public void SetCurrentUser(User user)
        {
            if (user.Role != Role.Admin)
            {
                throw new Exception("Solo usuarios administrativos pueden acceder a esta funcionalidad");
            }
            this.CurrentUser = user;
        }

        public void CreateNewPatient(string fullname, string dni, string email, string phonenumber, DateOnly birthdate, string address, Gender gender, string emergencyFirstName, string emergencyLastName, string emergencyRelationship, string emergencyPhone, string insuranceCompanyName, string insurancePolicyNumber, bool insuranceIsActive, DateTime insuranceExpirationDate)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            // Validar campos requeridos
            if (string.IsNullOrWhiteSpace(fullname))
                throw new Exception("El nombre completo es requerido");
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("El DNI es requerido");
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("El email es requerido");
            if (string.IsNullOrWhiteSpace(phonenumber))
                throw new Exception("El teléfono es requerido");
            if (string.IsNullOrWhiteSpace(address))
                throw new Exception("La dirección es requerida");
            if (string.IsNullOrWhiteSpace(emergencyFirstName))
                throw new Exception("El nombre del contacto de emergencia es requerido");
            if (string.IsNullOrWhiteSpace(emergencyLastName))
                throw new Exception("El apellido del contacto de emergencia es requerido");
            if (string.IsNullOrWhiteSpace(emergencyRelationship))
                throw new Exception("La relación del contacto de emergencia es requerida");
            if (string.IsNullOrWhiteSpace(emergencyPhone))
                throw new Exception("El teléfono de emergencia es requerido");
            if (string.IsNullOrWhiteSpace(insuranceCompanyName))
                throw new Exception("El nombre de la compañía de seguros es requerido");
            if (string.IsNullOrWhiteSpace(insurancePolicyNumber))
                throw new Exception("El número de póliza es requerido");

            // Crear las entidades relacionadas
            var emergencyContact = new EmergencyContact(emergencyFirstName, emergencyLastName, emergencyRelationship, emergencyPhone);
            
            // Convertir DateTime a UTC para PostgreSQL (requiere Kind=UTC)
            DateTime expirationDateUtc = insuranceExpirationDate.Kind == DateTimeKind.Utc 
                ? insuranceExpirationDate 
                : insuranceExpirationDate.ToUniversalTime();
            
            var healthInsurance = new HealthInsurance(insuranceCompanyName, insurancePolicyNumber, insuranceIsActive, expirationDateUtc);
            
            // Crear el paciente
            var patient = new Patient(fullname, dni, email, phonenumber, birthdate, address, gender, emergencyContact, healthInsurance);

            // Llamar al servicio para crear el paciente
            createPatient.Create(this.CurrentUser, patient);
        }

        public void UpdateExistingPatient(Patient patient, string email, string phone, string address)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            // Actualizar los campos del paciente
            patient.SetEmail(email);
            patient.SetPhone(phone);
            patient.SetAddress(address);

            updatePatient.Update(this.CurrentUser, patient);
        }

        public void CreateNewAppointment(int id, string patientDni, DateTime date)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            // Convertir DateTime a UTC para PostgreSQL (requiere Kind=UTC)
            DateTime dateUtc = date.Kind == DateTimeKind.Utc 
                ? date 
                : date.ToUniversalTime();

            var appointment = new Appointment(id, null!, dateUtc); // El paciente se valida en el servicio
            createAppointment.Create(appointment, patientDni);
        }

        public Invoice CreateNewInvoice(int invoiceNumber, string patientDni, string doctorDni, List<int> orderNumbers, DateTime invoiceDate)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un usuario administrativo válido");
            }

            // Convertir DateTime a UTC para PostgreSQL (requiere Kind=UTC)
            DateTime invoiceDateUtc = invoiceDate.Kind == DateTimeKind.Utc 
                ? invoiceDate 
                : invoiceDate.ToUniversalTime();

            return createInvoice.Create(invoiceNumber, patientDni, doctorDni, orderNumbers, invoiceDateUtc);
        }

    }
}
