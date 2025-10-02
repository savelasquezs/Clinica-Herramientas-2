using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Herramientas_2.Application.UseCases
{
    internal class DoctorUseCase
    {
        private CreateOrder createOrder;
        private CreateOrderItem createOrderItem;
        private AddOrderItem addOrderItem;
        private CreateMedicalRecord createMedicalRecord;
        private ViewMedicalHistory viewMedicalHistory;
        private ViewPatientInformation viewPatientInformation;
        private User currentUser;

        internal CreateOrder CreateOrder { get => createOrder; set => createOrder = value; }
        internal CreateOrderItem CreateOrderItem { get => createOrderItem; set => createOrderItem = value; }
        internal AddOrderItem AddOrderItem { get => addOrderItem; set => addOrderItem = value; }
        internal CreateMedicalRecord CreateMedicalRecord { get => createMedicalRecord; set => createMedicalRecord = value; }
        internal ViewMedicalHistory ViewMedicalHistory { get => viewMedicalHistory; set => viewMedicalHistory = value; }
        internal ViewPatientInformation ViewPatientInformation { get => viewPatientInformation; set => viewPatientInformation = value; }
        internal User CurrentUser { get => currentUser; set => currentUser = value; }

        public DoctorUseCase(CreateOrder createOrder, CreateOrderItem createOrderItem, AddOrderItem addOrderItem, CreateMedicalRecord createMedicalRecord, ViewMedicalHistory viewMedicalHistory, ViewPatientInformation viewPatientInformation)
        {
            this.CreateOrder = createOrder;
            this.CreateOrderItem = createOrderItem;
            this.AddOrderItem = addOrderItem;
            this.CreateMedicalRecord = createMedicalRecord;
            this.ViewMedicalHistory = viewMedicalHistory;
            this.ViewPatientInformation = viewPatientInformation;
        }

        public void SetCurrentUser(User user)
        {
            if (user.Role != Role.Doctor)
            {
                throw new Exception("Solo médicos pueden acceder a esta funcionalidad");
            }
            this.CurrentUser = user;
        }

        public Order CreateOrder(int orderNumber, DateTime creationDate)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            return CreateOrder.Create(orderNumber, creationDate);
        }

        public void AddMedicationToOrder(Order order, int itemNumber, decimal cost, Medication medication, string dose, int treatmentDuration)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            var medicationOrderItem = new MedicationOrderItem(order.OrderNumber, itemNumber, cost, medication, dose, treatmentDuration);
            AddOrderItem.Add(order, medicationOrderItem);
        }

        public void AddProcedureToOrder(Order order, int itemNumber, decimal cost, Procedure procedure, int frequency, bool requiresSpecialist, int? specialistTypeId)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            var procedureOrderItem = new ProcedureOrderItem(order.OrderNumber, itemNumber, cost, procedure, frequency, requiresSpecialist, specialistTypeId);
            AddOrderItem.Add(order, procedureOrderItem);
        }

        public void AddDiagnosticAidToOrder(Order order, int itemNumber, decimal cost, DiagnosticAid diagnosticAid, int quantity, bool requiresSpecialist, int? specialistTypeId)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            var diagnosticAidOrderItem = new DiagnosticAidOrderItem(order.OrderNumber, itemNumber, cost, diagnosticAid, quantity, requiresSpecialist, specialistTypeId);
            AddOrderItem.Add(order, diagnosticAidOrderItem);
        }

        public void CreateMedicalRecord(DateTime date, Patient patient, string consultationReason, string symptoms, string diagnosis, Order order)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            var medicalRecord = new MedicalRecord(date, patient, this.CurrentUser, consultationReason, symptoms, diagnosis, order);
            CreateMedicalRecord.Create(medicalRecord);
        }

        public void AddMedicalRecordToHistory(string patientDni, DateTime date, string consultationReason, string symptoms, string diagnosis)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            ViewMedicalHistory.AddMedicalRecord(patientDni, date, this.CurrentUser.Dni, consultationReason, symptoms, diagnosis, this.CurrentUser);
        }

        public List<MedicalRecord> GetMedicalHistory(string patientDni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            return ViewMedicalHistory.GetMedicalHistory(patientDni, this.CurrentUser);
        }

        public Patient GetPatientByDni(string dni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            return ViewPatientInformation.GetPatientByDni(dni);
        }

        public List<Appointment> GetPatientAppointments(string patientDni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            return ViewPatientInformation.GetPatientAppointments(patientDni);
        }

        public List<Order> GetPatientOrders(string patientDni)
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            return ViewPatientInformation.GetPatientOrders(patientDni);
        }

        public List<Patient> GetAllPatients()
        {
            if (this.CurrentUser == null)
            {
                throw new Exception("Debe establecer un médico válido");
            }

            return ViewPatientInformation.GetAllPatients();
        }
    }
}
