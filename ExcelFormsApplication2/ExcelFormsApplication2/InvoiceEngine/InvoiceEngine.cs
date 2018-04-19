using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Runtime.InteropServices;


namespace InvoiceEngine
{
    public class Engine
    {
        public void StartEngine()
        {

            // var result = MessageBox.Show(@"Are you sure to generate Invoices?", @"Confirmation Required", MessageBoxButtons.YesNo);
            var dlg = new InputForm();
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                var popup = new TopMostStatusForm();
                popup.Show();
                popup.DisplayText = "Intializing ...";

                var agreemwnts = FillUp.FillAgreements().ToList();
                var payments = FillUp.FillPayments().ToList();
              
                popup.DisplayText = string.Format("Processing Rent Repot Generation ...");
                CreateInvoice(agreemwnts, payments, dlg.TemplateFilePath);
                //Task.Factory.StartNew(() => CreateInvoice(data, i));

                //System.Threading.Thread.Sleep(1500);
               
                popup.Close();
                // MessageBox.Show(@"Operation completed successfully");

            }
        }


        private void CreateInvoice(List<Agreement> agreements, List<Payment> payments, string templateFilePath)
        {
            Excel.Application xlApp = null;
            string myPath = templateFilePath;// @"D:\GD_Drive\Projects\1022. Amir Stuff\03. Excel Report Prepration\src\Assignment_1\b_Template01.xlsx";
            xlApp = new Excel.Application();
            Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkbook = xlWorkbooks.Open(myPath);
            Excel.Sheets xlSheets = xlWorkbook.Sheets;
            Excel.Worksheet xlWorksheet = xlSheets[1];

            //Make a copy
            xlWorksheet.Copy();
            int row = 4;
            for (int i = 0; i < agreements.Count; i++)
            {
                ++row;
                int column = 0;
                xlWorksheet.Cells[row, ++column] = row + 1;
                xlWorksheet.Cells[row, ++column] = agreements[i].Name;
                xlWorksheet.Cells[row, ++column] = agreements[i].Name;
                xlWorksheet.Cells[row, ++column] = agreements[i].StartDate;
                xlWorksheet.Cells[row, ++column] = agreements[i].EndDate;
                xlWorksheet.Cells[row, ++column] = agreements[i].Amount;
                ++column;
                xlWorksheet.Cells[row, ++column] = agreements[i].NoofInstallments;

                var installments = payments.Where(x => x.AgreementId == agreements[i].Id).ToList();


                for (int j = 0; j < installments.Count(); j++)
                {

                    xlWorksheet.Cells[row, ++column] = installments[j].Amount;
                    xlWorksheet.Cells[row, ++column] = installments[j].PaymentDate;
                    xlWorksheet.Cells[row, ++column] = installments[j].PaymentMethod;
                }
            }

            //var activeWorkbook = ((Excel.Workbook) Application.ActiveWorkbook);
            string invoicePath = System.IO.Path.GetDirectoryName(myPath);
            string file = string.Format(@"{0}\Invoice_{1}.xlsx", "output", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" +
                                        DateTime.Now.Day);
            invoicePath = System.IO.Path.Combine(invoicePath, file);
            xlWorksheet.SaveAs(invoicePath);

            xlWorkbook.Close();

            //  ...clean up...  
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlSheets);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlWorkbooks);

            //Kill the provesds as Excel process is stubbon
            if (xlApp != null)
            {
                xlApp.Quit();
                int xIProcessId = 0;
                GetWindowThreadProcessId(new IntPtr(xlApp.Hwnd), ref xIProcessId);

                Process xlProc = Process.GetProcessById(xIProcessId);
                if (xlProc != null)
                {
                    xlProc.Kill();
                }

            }
        }

        //private IList<SourceDataDto> ReadDataExcelFile(string dataFilePath)
        //{
        //    var list = new List<SourceDataDto>();

        //    var xlApp = new Excel.Application();
        //    string myPath = dataFilePath;// @"D:\GD_Drive\Projects\1022. Amir Stuff\03. Excel Report Prepration\src\Assignment_1\a_Data fields.xlsx";
        //    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(myPath);
        //    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        //    Excel.Range xlRange = xlWorksheet.UsedRange;

        //    int rowCount = xlRange.Rows.Count;
        //    int colCount = xlRange.Columns.Count;

        //    int colIndex = 1;
        //    for (int rowIndex = 2; rowIndex <= rowCount; rowIndex++)
        //    {
        //        //for (int j = 0; j <= colCount-1; j++)
        //        //{
        //        //    MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
        //        //}

        //        var firstValue = xlApp.Cells[rowIndex, colIndex];

        //        if (firstValue != null && firstValue.Value2 != null && !string.IsNullOrEmpty(firstValue.Value2.ToString()))
        //        {
        //            list.Add(new SourceDataDto
        //            {
        //                Company = firstValue.Value2.ToString(),
        //                StreetNumber = xlApp.Cells[rowIndex, colIndex + 1].Value2.ToString(),
        //                PostalCodeCity = xlApp.Cells[rowIndex, colIndex + 2].Value2.ToString(),
        //                Country = xlApp.Cells[rowIndex, colIndex + 3].Value2.ToString(),
        //                Description = xlApp.Cells[rowIndex, colIndex + 4].Value2.ToString(),
        //                InternationalAppNo = xlApp.Cells[rowIndex, colIndex + 5].Value2.ToString(),
        //                IpcText = xlApp.Cells[rowIndex, colIndex + 6].Value2.ToString(),
        //                PubNo = xlApp.Cells[rowIndex, colIndex + 7].Value2.ToString(),
        //                PublicationDate = xlApp.Cells[rowIndex, colIndex + 8].Value2==null? DateTime.MinValue : (Convert.ToDateTime(Convert.ToString((xlApp.Cells[rowIndex, colIndex + 8] as Excel.Range).Text))),
        //                InventorName = xlApp.Cells[rowIndex, colIndex + 9].Value2 == null ? "" : xlApp.Cells[rowIndex, colIndex + 9].Value2.ToString(),
        //                InternationalFilingDate = xlApp.Cells[rowIndex, colIndex + 10].Value2 == null ? DateTime.MinValue : (Convert.ToDateTime(Convert.ToString((xlApp.Cells[rowIndex, colIndex + 10] as Excel.Range).Text))),
        //                InvoiceNo = xlApp.Cells[rowIndex, colIndex + 11].Value2.ToString(),
        //            });
        //        }

        //    }
        //    //Close the excel file after reading it.
        //    xlWorkbook.Close(false);
        //    xlApp.Quit();


        //    return list;
        //}

        public void GenerateExcelInvoice()
        {

        }

        //Used in Method: CreateInvoice
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessId);


        private void SetCellFirstWordBold(Excel.Range rng, char wordsSeparator)
        {
            string cellString = rng.Text;

            int firstWordEndIdx = cellString.IndexOf(wordsSeparator);
            this.SetCellBoldPartial(rng, 0, firstWordEndIdx);
        }

        private void SetCellBoldPartial(Excel.Range rng, int boldStartIndex, int boldEndIndex)
        {
            rng.Characters[boldStartIndex, boldEndIndex].Font.Bold = 1;
        }


    }


}
