using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace ContratorBookingSystem
{
    public partial class Reports : Form
    {
        DataAccess da = new DataAccess();
        public bool isMonthlyReport = false;
        public Reports(bool monthlyReport = false)
        {
            InitializeComponent();
            isMonthlyReport = monthlyReport;
            if (isMonthlyReport)
            { this.Text = "Monthly Report"; }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            ddFromDate.Text = DateTime.Now.AddMonths(-1).ToShortDateString();
            ddToDate.Text = DateTime.Now.AddMonths(1).ToShortDateString();

            RenIncomGridSettings();
        }

        private void RenIncomGridSettings()
        {
            RentIncomGrid.AutoGenerateColumns = false;
            RentIncomGrid.AutoSize = true;

            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "";
            column.Width = 100;
            RentIncomGrid.Columns.Add(column);
            column.Visible = false;


            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "BuildingName";
            column.Name = "Building Name";
            column.Width = 250;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Typeno";
            column.Name = "Space Unit";
            column.Width = 100;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Date";
            column.Name = "Date";
            column.Width = 100;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Contractor Name";
            column.Width = 200;

            RentIncomGrid.Columns.Add(column);

            if (!isMonthlyReport)
            {
                // Initialize and add a text box column.
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Agreement";
                column.Name = "Agreement Amount";
                column.Width = 120;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                RentIncomGrid.Columns.Add(column);
            }
            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "InstallmentAmount";
            column.Name = "Installment Due";
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column.Width = 120;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ContactNo";
            column.Name = "Contact No";
            column.Width = 150;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Type";
            column.Name = "Type";
            column.Width = 100;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Status";
            column.Name = "Status";
            column.Width = 100;
            RentIncomGrid.Columns.Add(column);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var report = da.GetMonthlyReport(DateTime.Parse(ddFromDate.Text), DateTime.Parse(ddToDate.Text), isMonthlyReport ? PaymentStatus.COMPLETE : PaymentStatus.DUE);

                RentIncomGrid.DataSource = report;
                lblAgrementAmountValue.Text = lblAgrementAmount.Text = report.Sum(x => x.Agreement ).ToString( );
                lblInstallmentAmountValue.Text = lblInstallmentAmount.Text = report.Sum(x =>  x.InstallmentAmount ).ToString( );

                        }

            catch (Exception ex)
            {
                LogWriter.Write("Exception ---" + ex.Message + ex.StackTrace + "----" + ex.Source + "---" + ex.InnerException);
            }
        }


        private DataGridPrinter dataGridPrinter1 = null;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string dateStringFormate = "From {0} to {1}";
            lblDateRange.Text = string.Format(dateStringFormate, ddFromDate.Text, ddToDate.Text);

            SetupGridPrinter();
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        int totalPages = 0;
        void SetupGridPrinter()
        {
            DataTable sampleDataTable = new DataTable("ATABLE");
            sampleDataTable.Columns.Add("Building Name", typeof(string));
            sampleDataTable.Columns.Add("Space unit", typeof(string));
            sampleDataTable.Columns.Add("Date", typeof(string));
            sampleDataTable.Columns.Add("Contractor Name", typeof(string));
            if(!isMonthlyReport)
                 sampleDataTable.Columns.Add("Agreement", typeof(string));
            sampleDataTable.Columns.Add("Installment Due", typeof(string));
            if (!isMonthlyReport)
            {
                sampleDataTable.Columns.Add("Contact No 1", typeof(string));
                sampleDataTable.Columns.Add("Contact No 2", typeof(string));
            }
            else
                 sampleDataTable.Columns.Add("Type", typeof(string));
            sampleDataTable.Columns.Add("Status", typeof(string));

            var report = da.GetMonthlyReport(DateTime.Parse(ddFromDate.Text), DateTime.Parse(ddToDate.Text), isMonthlyReport ? PaymentStatus.COMPLETE : PaymentStatus.DUE);

            DataRow sampleDataRow;
            foreach (var c in report)
            {
                string[] contacts = c.ContactNo.Split('/');
                sampleDataRow = sampleDataTable.NewRow();
                sampleDataRow["Building Name"] = c.BuildingName.ToString(CultureInfo.CurrentCulture);
                sampleDataRow["Space unit"] = c.Typeno.ToString(CultureInfo.CurrentCulture);
                sampleDataRow["Date"] = c.Date.ToShortDateString();
                sampleDataRow["Contractor Name"] = c.Name;
                if (!isMonthlyReport)
                    sampleDataRow["Agreement"] = c.Agreement.ToString( );
                sampleDataRow["Installment Due"] = c.InstallmentAmount.ToString( );
                if (!isMonthlyReport)
                {
                    sampleDataRow["Contact No 1"] = contacts[0].ToString(CultureInfo.CurrentCulture);
                    sampleDataRow["Contact No 2"] = contacts.Length > 1 ? contacts[1].ToString(CultureInfo.CurrentCulture) : "";
                }
                else
                    sampleDataRow["Type"] = c.Type;
                sampleDataRow["Status"] = c.Status;

                sampleDataTable.Rows.Add(sampleDataRow);
            }

            totalPages = (sampleDataTable.Rows.Count + 14) / 25;
            dataGridPrinter1 = new DataGridPrinter(dataGridView1, printDocument1, sampleDataTable);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
         
            Graphics g = e.Graphics;
            if(dataGridPrinter1.PageNumber == 1)
                DrawTopLabel(g);
           
            bool more = dataGridPrinter1.DrawDataGrid(g);
            if (more == true)
            {
                e.HasMorePages = true;
                dataGridPrinter1.PageNumber++;
            }
        }
        void DrawTopLabel(Graphics g)
        {
            int TopMargin = 0;
            if (isMonthlyReport)
                lblReportHeader.Text = "Monthly Report";

            // g.FillRectangle(new SolidBrush(label1.BackColor), label1.Location.X, label1.Location.Y + TopMargin, label1.Size.Width, label1.Size.Height);
            g.DrawString(lblReportHeader.Text, lblReportHeader.Font, new SolidBrush(lblReportHeader.ForeColor), lblReportHeader.Location.X + 10, lblReportHeader.Location.Y + TopMargin, new StringFormat());
            g.DrawString(lblDateRange.Text, lblDateRange.Font, new SolidBrush(lblDateRange.ForeColor), lblDateRange.Location.X  + 10, lblDateRange.Location.Y + TopMargin, new StringFormat());

            g.DrawString(lblAgreementAmountForPrint.Text, lblAgreementAmountForPrint.Font, new SolidBrush(lblAgreementAmountForPrint.ForeColor), lblAgreementAmountForPrint.Location.X + 70, lblAgreementAmountForPrint.Location.Y + TopMargin, new StringFormat());
            g.DrawString(lblAgrementAmountValue.Text, lblAgrementAmountValue.Font, new SolidBrush(lblAgrementAmountValue.ForeColor), lblAgrementAmountValue.Location.X + 70, lblAgrementAmountValue.Location.Y + TopMargin, new StringFormat());


            g.DrawString(lblIntallmentAmountForPrint.Text, lblIntallmentAmountForPrint.Font, new SolidBrush(lblIntallmentAmountForPrint.ForeColor), lblIntallmentAmountForPrint.Location.X + 70, lblIntallmentAmountForPrint.Location.Y + TopMargin, new StringFormat());
            g.DrawString(lblInstallmentAmountValue.Text, lblInstallmentAmountValue.Font, new SolidBrush(lblInstallmentAmountValue.ForeColor), lblInstallmentAmountValue.Location.X + 70, lblInstallmentAmountValue.Location.Y + TopMargin, new StringFormat());



        }

        void DrawPageNumber(Graphics g)
        {
            int TopMargin = 0;
            // g.DrawString(pageLabel.Text, pageLabel.Font, new SolidBrush(pageLabel.ForeColor), pageLabel.Location.X + 70, pageLabel.Location.Y + TopMargin, new StringFormat());
           
       
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {

        }

        private void RentIncomGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            var param = RentIncomGrid.Columns[e.ColumnIndex].DataPropertyName;
            var pi = typeof(MonthlyReportDto).GetProperty(param);

            var newVal = da.GetMonthlyReport(DateTime.Parse(ddFromDate.Text), DateTime.Parse(ddToDate.Text), isMonthlyReport ? PaymentStatus.COMPLETE : PaymentStatus.DUE);
            var report = newVal.OrderBy(x => pi.GetValue(x, null)).ToList();
            RentIncomGrid.DataSource = report;
            


        }
    }
}
