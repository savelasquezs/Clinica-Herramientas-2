using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Admin.Invoices
{
    public partial class InvoiceManagementForm : Form
    {
        private readonly AdminConfig adminConfig;
        private readonly User currentUser;
        private List<Invoice> invoices = new List<Invoice>();
        private List<Patient> patients = new List<Patient>();
        private List<User> doctors = new List<User>();

        public InvoiceManagementForm(AdminConfig adminConfig, User currentUser)
        {
            this.adminConfig = adminConfig;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
            LoadInvoices();
            LoadPatients();
            LoadDoctors();
        }

        private void SetupDataGridView()
        {
            dgvInvoices.AutoGenerateColumns = false;
            dgvInvoices.Columns.Clear();

            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(37, 99, 235),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold)
            };
            dgvInvoices.ColumnHeadersDefaultCellStyle = headerStyle;

            var alternatingRowStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
            };
            dgvInvoices.AlternatingRowsDefaultCellStyle = alternatingRowStyle;

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colInvoiceNumber",
                HeaderText = "Número",
                DataPropertyName = "InvoiceNumber",
                Width = 100
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPatientName",
                HeaderText = "Paciente",
                DataPropertyName = "PatientName",
                Width = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDoctorName",
                HeaderText = "Médico",
                DataPropertyName = "DoctorName",
                Width = 200
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotalAmount",
                HeaderText = "Total",
                DataPropertyName = "TotalAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCopayment",
                HeaderText = "Copago",
                DataPropertyName = "CopaymentAmount",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Fecha",
                DataPropertyName = "InvoiceDate",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void LoadInvoices()
        {
            try
            {
                invoices = adminConfig.InvoicePort.FindAll();
                var invoiceData = invoices.Select(i => new
                {
                    i.InvoiceNumber,
                    PatientName = i.Patient.Fullname,
                    DoctorName = i.Doctor.Fullname,
                    i.TotalAmount,
                    i.CopaymentAmount,
                    i.InvoiceDate
                }).ToList();

                dgvInvoices.DataSource = null;
                dgvInvoices.DataSource = invoiceData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatients()
        {
            try
            {
                patients = adminConfig.ViewPatientInformationService.GetAllPatients();
                cmbPatient.Items.Clear();
                foreach (var patient in patients)
                {
                    cmbPatient.Items.Add($"{patient.Dni} - {patient.Fullname}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDoctors()
        {
            // Los doctores se ingresan por DNI en el campo txtDoctorDni
            // No hay acceso directo a UserPort desde AdminConfig
            cmbDoctor.Items.Clear();
            cmbDoctor.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadInvoices();
                return;
            }

            var filtered = invoices.Where(i =>
                i.Patient.Dni.ToLower().Contains(searchTerm) ||
                i.Patient.Fullname.ToLower().Contains(searchTerm) ||
                i.InvoiceNumber.ToString().Contains(searchTerm)
            ).Select(i => new
            {
                i.InvoiceNumber,
                PatientName = i.Patient.Fullname,
                DoctorName = i.Doctor.Fullname,
                i.TotalAmount,
                i.CopaymentAmount,
                i.InvoiceDate
            }).ToList();

            dgvInvoices.DataSource = null;
            dgvInvoices.DataSource = filtered;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInvoiceNumber.Text))
                {
                    MessageBox.Show("Por favor ingrese un número de factura", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtInvoiceNumber.Text, out int invoiceNumber))
                {
                    MessageBox.Show("El número de factura debe ser un número válido", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbPatient.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor seleccione un paciente", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDoctorDni.Text))
                {
                    MessageBox.Show("Por favor ingrese el DNI del médico", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtOrderNumbers.Text))
                {
                    MessageBox.Show("Por favor ingrese los números de orden separados por comas", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedPatientText = cmbPatient.SelectedItem?.ToString() ?? string.Empty;
                if (string.IsNullOrEmpty(selectedPatientText))
                {
                    MessageBox.Show("Por favor seleccione un paciente válido", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var patientDni = selectedPatientText.Split('-')[0].Trim();
                var doctorDni = txtDoctorDni.Text.Trim();
                
                var orderNumbersText = txtOrderNumbers.Text.Split(',');
                var orderNumbers = new List<int>();
                foreach (var orderNumText in orderNumbersText)
                {
                    if (int.TryParse(orderNumText.Trim(), out int orderNum))
                    {
                        orderNumbers.Add(orderNum);
                    }
                }

                if (orderNumbers.Count == 0)
                {
                    MessageBox.Show("Por favor ingrese al menos un número de orden válido", "Error de validación", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var invoiceDate = dtpInvoiceDate.Value;

                // Establecer el usuario actual antes de crear
                adminConfig.AdminUseCase.SetCurrentUser(currentUser);

                var invoice = adminConfig.AdminInputs.CreateInvoice(invoiceNumber, patientDni, doctorDni, orderNumbers, invoiceDate);

                MessageBox.Show($"Factura creada exitosamente\nTotal: ${invoice.TotalAmount:N2}\nCopago: ${invoice.CopaymentAmount:N2}\nAseguradora: ${invoice.InsuranceAmount:N2}", 
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LoadInvoices();
                ClearNewInvoiceForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear factura: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearNewInvoiceForm()
        {
            txtInvoiceNumber.Clear();
            cmbPatient.SelectedIndex = -1;
            txtDoctorDni.Clear();
            txtOrderNumbers.Clear();
            dtpInvoiceDate.Value = DateTime.Now;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una factura para ver detalles", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var selectedRow = dgvInvoices.SelectedRows[0];
                var invoiceNumber = (int)selectedRow.Cells["colInvoiceNumber"].Value;
                var invoice = invoices.FirstOrDefault(i => i.InvoiceNumber == invoiceNumber);

                if (invoice == null)
                {
                    invoice = adminConfig.InvoicePort.FindByNumber(invoiceNumber);
                }

                if (invoice != null)
                {
                    ShowInvoiceDetails(invoice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInvoiceDetails(Invoice invoice)
        {
            var details = new StringBuilder();
            details.AppendLine("=== FACTURA ===");
            details.AppendLine($"Número: {invoice.InvoiceNumber}");
            details.AppendLine($"Fecha: {invoice.InvoiceDate:dd/MM/yyyy}");
            details.AppendLine();
            details.AppendLine("=== PACIENTE ===");
            details.AppendLine($"Nombre: {invoice.Patient.Fullname}");
            details.AppendLine($"DNI: {invoice.Patient.Dni}");
            var age = DateTime.Now.Year - invoice.Patient.Birthdate.Year;
            if (DateTime.Now.DayOfYear < invoice.Patient.Birthdate.DayOfYear) age--;
            details.AppendLine($"Edad: {age} años");
            details.AppendLine();
            details.AppendLine("=== MÉDICO TRATANTE ===");
            details.AppendLine($"Nombre: {invoice.Doctor.Fullname}");
            details.AppendLine();
            details.AppendLine("=== SEGURO MÉDICO ===");
            if (invoice.Patient.Insurance != null)
            {
                details.AppendLine($"Compañía: {invoice.Patient.Insurance.CompanyName}");
                details.AppendLine($"Número de Póliza: {invoice.Patient.Insurance.PolicyNumber}");
                details.AppendLine($"Estado: {(invoice.Patient.Insurance.IsActive ? "Activa" : "Inactiva")}");
                details.AppendLine($"Vigencia: {invoice.Patient.Insurance.ExpirationDate:dd/MM/yyyy}");
            }
            else
            {
                details.AppendLine("Sin seguro médico");
            }
            details.AppendLine();
            details.AppendLine("=== DETALLE DE ÓRDENES ===");
            foreach (var order in invoice.Orders)
            {
                details.AppendLine($"Orden #{order.OrderNumber} - Fecha: {order.CreationDate:dd/MM/yyyy}");
                foreach (var item in order.Items)
                {
                    if (item is MedicationOrderItem medItem)
                    {
                        details.AppendLine($"  - Medicamento: {medItem.Medication.Name}, Dosis: {medItem.Dose}, Costo: ${medItem.Cost:N2}");
                    }
                    else if (item is ProcedureOrderItem procItem)
                    {
                        details.AppendLine($"  - Procedimiento: {procItem.Procedure.Name}, Frecuencia: {procItem.Frequency}, Costo: ${procItem.Cost:N2}");
                    }
                    else if (item is DiagnosticAidOrderItem diagItem)
                    {
                        details.AppendLine($"  - Ayuda Diagnóstica: {diagItem.DiagnosticAid.Name}, Cantidad: {diagItem.Quantity}, Costo: ${diagItem.Cost:N2}");
                    }
                }
            }
            details.AppendLine();
            details.AppendLine("=== RESUMEN FINANCIERO ===");
            details.AppendLine($"Total: ${invoice.TotalAmount:N2}");
            details.AppendLine($"Copago: ${invoice.CopaymentAmount:N2}");
            details.AppendLine($"Aseguradora: ${invoice.InsuranceAmount:N2}");
            details.AppendLine($"Acumulado Anual: ${invoice.AnnualCopaymentAccumulated:N2}");

            MessageBox.Show(details.ToString(), "Detalles de Factura", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInvoices();
            txtSearch.Clear();
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }
    }
}

