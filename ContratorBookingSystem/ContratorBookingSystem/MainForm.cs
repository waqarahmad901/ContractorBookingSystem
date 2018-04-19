using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContratorBookingSystem
{
    public partial class MainForm : Form
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        Form loadingForm = new ExcelLoading();
        public MainForm()
        {
            LogWriter.Write("Open contractor booking system...");
            InitializeComponent();

            _worker.DoWork += new DoWorkEventHandler(_executeWorker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_executeWorker_RunWorkerCompleted);
            _worker.ProgressChanged += new ProgressChangedEventHandler(_executeWorker_ProgressChanged);
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
        }

        private void _executeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        private void _executeWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingForm.Hide();
        }

        private void _executeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            new Engine().StartEngine();
        }

        private void BuildingMgmt_Click(object sender, EventArgs e)
        {
            var form = new BuildingForm();
           
            if(form.ShowDialog() == DialogResult.OK)
            {
                // todo nothing
            }
        }



        private void NewContractor_Click(object sender, EventArgs e)
        {
            var form = new ContractorForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // todo nothing
            }
        }

        private void NewPayment_Click(object sender, EventArgs e)
        {
            var form = new AddContract(0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // todo nothing
            }
        }

        private void btnRepoprts_Click(object sender, EventArgs e)
        {
            var form = new Reports();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // todo nothing
            }
        }

        private void btnRentReport_Click(object sender, EventArgs e)
        {
            var form = new Reports(true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                // todo nothing
            }
        }

        private void RentReport_Click(object sender, EventArgs e)
        {
         
            loadingForm.Show();
            //new Engine().StartEngine();
            _worker.RunWorkerAsync();
        }
    }
}
