using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class DiagnosticAidManagementForm : Form
    {
        private readonly SupportInputs supportInputs;
        private readonly User currentUser;
        private List<DiagnosticAid> diagnosticAids = new List<DiagnosticAid>();

        public DiagnosticAidManagementForm(SupportInputs supportInputs, User currentUser)
        {
            this.supportInputs = supportInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
            LoadDiagnosticAids();
        }

        private void SetupDataGridView()
        {
            dgvDiagnosticAids.AutoGenerateColumns = false;
            dgvDiagnosticAids.Columns.Clear();
            var headerStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(234, 88, 12), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold) };
            dgvDiagnosticAids.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvDiagnosticAids.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(255, 247, 237) };
            dgvDiagnosticAids.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", DataPropertyName = "Id", Width = 80 });
            dgvDiagnosticAids.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Nombre", DataPropertyName = "Name", Width = 300, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDiagnosticAids.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCost", HeaderText = "Costo", DataPropertyName = "Cost", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvDiagnosticAids.Columns.Add(new DataGridViewTextBoxColumn { Name = "colQuantity", HeaderText = "Cantidad", DataPropertyName = "Quantity", Width = 120 });
            dgvDiagnosticAids.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRequiresSpecialist", HeaderText = "Requiere Especialista", DataPropertyName = "RequiresSpecialist", Width = 150 });
        }

        private void LoadDiagnosticAids()
        {
            try
            {
                diagnosticAids = supportInputs.GetAllDiagnosticAids();
                dgvDiagnosticAids.DataSource = null;
                dgvDiagnosticAids.DataSource = diagnosticAids;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ayudas diagnósticas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var createForm = new DiagnosticAidForm(supportInputs, null);
            if (createForm.ShowDialog() == DialogResult.OK) LoadDiagnosticAids();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiagnosticAids.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione una ayuda diagnóstica para editar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selected = (DiagnosticAid)dgvDiagnosticAids.SelectedRows[0].DataBoundItem;
            var editForm = new DiagnosticAidForm(supportInputs, selected);
            if (editForm.ShowDialog() == DialogResult.OK) LoadDiagnosticAids();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadDiagnosticAids();
    }
}

