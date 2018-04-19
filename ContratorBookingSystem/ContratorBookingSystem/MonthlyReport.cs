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
    public partial class MonthlyReport : Form
    {
        DataAccess da = new DataAccess();
    
        public MonthlyReport(bool monthlyReport = false)
        {
            InitializeComponent();
          
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            DateTime firstDayOfTheMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ddFromDate.Text = firstDayOfTheMonth.ToString();
            ddToDate.Text = firstDayOfTheMonth.AddMonths(1).AddDays(-1).ToString();

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

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "BuildingName";
            column.Name = "Building Name";
            column.Width = 250;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Typeno";
            column.Name = "Space Unit";
            column.Width = 200;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Date";
            column.Name = "Date";
            column.Width = 150;
            RentIncomGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Contractor Name";
            column.Width = 200;

            RentIncomGrid.Columns.Add(column);
            

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
            var report = da.GetMonthlyReport(DateTime.Parse(ddFromDate.Text),DateTime.Parse( ddToDate.Text),PaymentStatus.COMPLETE);
          
            RentIncomGrid.DataSource = report;

            lblAgrementAmountValue.Text =  lblAgrementAmount.Text = report.Sum(x =>  x.Agreement).ToString();
            lblInstallmentAmountValue.Text = lblInstallmentAmount.Text = report.Sum(x => x.InstallmentAmount).ToString();
        }

        private DataGridPrinter dataGridPrinter1 = null;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lblDateRange.Text = string.Format(lblDateRange.Text, ddFromDate.Text, ddToDate.Text);

            SetupGridPrinter();
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        void SetupGridPrinter()
        {
            DataTable sampleDataTable = new DataTable("ATABLE");
            sampleDataTable.Columns.Add("Building Name", typeof(string));
            sampleDataTable.Columns.Add("Space unit", typeof(string));
            sampleDataTable.Columns.Add("Date", typeof(string));
            sampleDataTable.Columns.Add("Contractor Name", typeof(string));
            
            sampleDataTable.Columns.Add("Installment Due", typeof(string));
            sampleDataTable.Columns.Add("Contact No", typeof(string));
            // sampleDataTable.Columns.Add("Type", typeof(string));
            sampleDataTable.Columns.Add("Status", typeof(string));
            var report = da.GetMonthlyReport(DateTime.Parse(ddFromDate.Text), DateTime.Parse(ddToDate.Text), PaymentStatus.COMPLETE);

            DataRow sampleDataRow;
            foreach (var c in report)
            {
                sampleDataRow = sampleDataTable.NewRow();
                sampleDataRow["Building Name"] = c.BuildingName.ToString(CultureInfo.CurrentCulture);
                sampleDataRow["Space unit"] = c.Typeno.ToString(CultureInfo.CurrentCulture);
                sampleDataRow["Date"] = c.Date.ToShortDateString();
                sampleDataRow["Contractor Name"] = c.Name;
                
                sampleDataRow["Installment Due"] = c.InstallmentAmount.ToString( );
                sampleDataRow["Contact No"] = c.ContactNo.ToString(CultureInfo.CurrentCulture);
                // sampleDataRow["Type"] = c.Type;
                sampleDataRow["Status"] = c.Status;
            }

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
            int TopMargin = printDocument1.DefaultPageSettings.Margins.Top;


            // g.FillRectangle(new SolidBrush(label1.BackColor), label1.Location.X, label1.Location.Y + TopMargin, label1.Size.Width, label1.Size.Height);
            g.DrawString(lblReportHeader.Text, lblReportHeader.Font, new SolidBrush(lblReportHeader.ForeColor), lblReportHeader.Location.X  , lblReportHeader.Location.Y + TopMargin, new StringFormat());
            g.DrawString(lblDateRange.Text, lblDateRange.Font, new SolidBrush(lblDateRange.ForeColor), lblDateRange.Location.X  , lblDateRange.Location.Y + TopMargin, new StringFormat());

            g.DrawString(lblAgreementAmountForPrint.Text, lblAgreementAmountForPrint.Font, new SolidBrush(lblAgreementAmountForPrint.ForeColor), lblAgreementAmountForPrint.Location.X + 70, lblAgreementAmountForPrint.Location.Y + TopMargin, new StringFormat());
            g.DrawString(lblAgrementAmountValue.Text, lblAgrementAmountValue.Font, new SolidBrush(lblAgrementAmountValue.ForeColor), lblAgrementAmountValue.Location.X + 70, lblAgrementAmountValue.Location.Y + TopMargin, new StringFormat());


            g.DrawString(lblIntallmentAmountForPrint.Text, lblIntallmentAmountForPrint.Font, new SolidBrush(lblIntallmentAmountForPrint.ForeColor), lblIntallmentAmountForPrint.Location.X + 70, lblIntallmentAmountForPrint.Location.Y + TopMargin, new StringFormat());
            g.DrawString(lblInstallmentAmountValue.Text, lblInstallmentAmountValue.Font, new SolidBrush(lblInstallmentAmountValue.ForeColor), lblInstallmentAmountValue.Location.X + 70, lblInstallmentAmountValue.Location.Y + TopMargin, new StringFormat());

        }

        private void RentIncomGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            var param = RentIncomGrid.Columns[e.ColumnIndex].DataPropertyName;
            var pi = typeof(MonthlyReportDto).GetProperty(param);

            var report = da.GetMonthlyReport(DateTime.Parse(ddFromDate.Text), DateTime.Parse(ddToDate.Text), PaymentStatus.COMPLETE).OrderBy(x => pi.GetValue(x, null)).ToList();

            RentIncomGrid.DataSource = report;
        }
    }
}
