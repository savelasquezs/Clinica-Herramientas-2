using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Infrastructure.Adapters.Output.Persistence
{
    internal class PortsFactory
    {
        private readonly ClinicaDbContext context;
        
        private IUserPort? userPort;
        private IPatientPort? patientPort;
        private IOrderPort? orderPort;
        private IAppointmentPort? appointmentPort;
        private IInvoicePort? invoicePort;
        private IMedicalRecordPort? medicalRecordPort;
        private INurseVisit? nurseVisitPort;
        private IMedicationPort? medicationPort;
        private IProcedurePort? procedurePort;
        private IDiagnosticAidPort? diagnosticAidPort;
        private IInventoryPort? inventoryPort;
        
        public PortsFactory(ClinicaDbContext context)
        {
            this.context = context;
        }
        
        public IUserPort UserPort => userPort ??= new PostgresUserPort(context);
        public IPatientPort PatientPort => patientPort ??= new PostgresPatientPort(context);
        public IOrderPort OrderPort => orderPort ??= new PostgresOrderPort(context);
        public IAppointmentPort AppointmentPort => appointmentPort ??= new PostgresAppointmentPort(context);
        public IInvoicePort InvoicePort => invoicePort ??= new PostgresInvoicePort(context);
        public IMedicalRecordPort MedicalRecordPort => medicalRecordPort ??= new PostgresMedicalRecordPort(context);
        public INurseVisit NurseVisitPort => nurseVisitPort ??= new PostgresNurseVisitPort(context);
        public IMedicationPort MedicationPort => medicationPort ??= new PostgresMedicationPort(context);
        public IProcedurePort ProcedurePort => procedurePort ??= new PostgresProcedurePort(context);
        public IDiagnosticAidPort DiagnosticAidPort => diagnosticAidPort ??= new PostgresDiagnosticAidPort(context);
        public IInventoryPort InventoryPort => inventoryPort ??= new PostgresInventoryPort(context);
    }
}
