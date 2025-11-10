using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.Nurse
{
    public partial class PatientViewForm : Form
    {
        private readonly BindingSource bindingSource = new BindingSource();

        public PatientViewForm()
        {
            InitializeComponent();
            dgvPatientVitals.AutoGenerateColumns = false;
            dgvPatientVitals.DataSource = bindingSource;
            btnRefresh.Click += btnRefresh_Click;
            LoadRecords();
            NurseDataStore.RecordsChanged += NurseDataStore_RecordsChanged;
        }

        private void LoadRecords()
        {
            var list = NurseDataStore.GetAll().ToList();
            bindingSource.DataSource = new BindingList<PatientVitalRecord>(list);
        }

        private void NurseDataStore_RecordsChanged()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(LoadRecords));
            }
            else
            {
                LoadRecords();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            NurseDataStore.RecordsChanged -= NurseDataStore_RecordsChanged;
        }

        private void dgvPatientVitals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
