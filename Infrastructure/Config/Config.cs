
using Clinica_Herramientas_2.Domain.Ports;


namespace Clinica_Herramientas_2.Infrastructure.Config
{
    internal class Config
    {
        // Configs por caso de uso
        public AdminConfig AdminConfig { get; private set; }
        public DoctorConfig DoctorConfig { get; private set; }
        public NurseConfig NurseConfig { get; private set; }
        public RRHHConfig RRHHConfig { get; private set; }
        public SupportConfig SupportConfig { get; private set; }
        
        public Config(
            IPatientPort patientPort,
            IUserPort userPort,
            IOrderPort orderPort,
            IAppointmentPort appointmentPort,
            IInvoicePort invoicePort,
            IMedicalRecordPort medicalRecordPort,
            INurseVisit nurseVisitPort,
            IMedicationPort medicationPort,
            IProcedurePort procedurePort,
            IDiagnosticAidPort diagnosticAidPort,
            IInventoryPort inventoryPort)
        {
            AdminConfig = new AdminConfig(patientPort, appointmentPort, invoicePort, userPort, orderPort);
            DoctorConfig = new DoctorConfig(orderPort, inventoryPort, medicalRecordPort, patientPort, userPort, appointmentPort);
            NurseConfig = new NurseConfig(nurseVisitPort, patientPort, userPort, appointmentPort, orderPort);
            RRHHConfig = new RRHHConfig(userPort);
            SupportConfig = new SupportConfig(medicationPort, procedurePort, diagnosticAidPort, inventoryPort);
        }
    }
}
