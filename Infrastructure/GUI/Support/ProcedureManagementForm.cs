using Clinica_Herramientas_2.Application.Adapters.Input;
using Clinica_Herramientas_2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Support
{
    public partial class ProcedureManagementForm : Form
    {
        private readonly SupportInputs supportInputs;
        private readonly User currentUser;
        private List<Procedure> procedures = new List<Procedure>();

        public ProcedureManagementForm(SupportInputs supportInputs, User currentUser)
        {
            this.supportInputs = supportInputs;
            this.currentUser = currentUser;
            InitializeComponent();
            SetupDataGridView();
            LoadProcedures();
        }

        private void SetupDataGridView()
        {
            dgvProcedures.AutoGenerateColumns = false;
            dgvProcedures.Columns.Clear();
            var headerStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(234, 88, 12), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold) };
            dgvProcedures.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvProcedures.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(255, 247, 237) };
            dgvProcedures.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", HeaderText = "ID", DataPropertyName = "Id", Width = 80 });
            dgvProcedures.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "Nombre", DataPropertyName = "Name", Width = 300, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProcedures.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCost", HeaderText = "Costo", DataPropertyName = "Cost", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvProcedures.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFrequency", HeaderText = "Frecuencia", DataPropertyName = "Frequency", Width = 120 });
            dgvProcedures.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRequiresSpecialist", HeaderText = "Requiere Especialista", DataPropertyName = "RequiresSpecialist", Width = 150 });
        }

        private void LoadProcedures()
        {
            try
            {
                procedures = supportInputs.GetAllProcedures();
                dgvProcedures.DataSource = null;
                dgvProcedures.DataSource = procedures;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar procedimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var createForm = new ProcedureForm(supportInputs, null);
            if (createForm.ShowDialog() == DialogResult.OK) LoadProcedures();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProcedures.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un procedimiento para editar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selected = (Procedure)dgvProcedures.SelectedRows[0].DataBoundItem;
            var editForm = new ProcedureForm(supportInputs, selected);
            if (editForm.ShowDialog() == DialogResult.OK) LoadProcedures();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadProcedures();
    }
}

