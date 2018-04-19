using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Runtime.InteropServices;
using DataLayer;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace ContratorBookingSystem
{
    public class Engine
    {
        DataAccess da = new DataAccess();
        public void StartEngine()
        {

            //   CreateInvoice(agreemwnts, payments, dlg.TemplateFilePath);
            List<RentReportDto> rentReport = da.GetRentReportData();
            CreateInvoice(rentReport, ConfigurationManager.AppSettings["ExcelTemplateFile"]);
        }


        private void CreateInvoice(List<RentReportDto> rentList, string templateFilePath)
        {
            try
            { 
                string templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), templateFilePath);
                Excel.Application xlApp = null;
                xlApp = new Excel.Application();
                Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
                Excel.Workbook xlWorkbook = xlWorkbooks.Open(templatePath);
                Excel.Sheets xlSheets = xlWorkbook.Sheets;
                Excel.Worksheet xlWorksheet = xlSheets[1];

                //Make a copy
                xlWorksheet.Copy();
                int row = 4;

                foreach (RentReportDto rent in rentList)
                {
                    ++row;
                    int column = 0;

                    xlWorksheet.Cells[row, ++column] = rent.BuildingName + "    " + rent.ArabicName;
                    xlWorksheet.Range[xlWorksheet.Cells[row, column], xlWorksheet.Cells[row, column + 20]].Merge(Type.Missing);
                    xlWorksheet.Range[xlWorksheet.Cells[row, column], xlWorksheet.Cells[row, column + 20]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorksheet.Range[xlWorksheet.Cells[row, column], xlWorksheet.Cells[row, column + 20]].Font.Bold = true;
                    xlWorksheet.Range[xlWorksheet.Cells[row, column], xlWorksheet.Cells[row, column + 20]].Font.Size = 20;
                    row++;
                    foreach (ContractDto contract in rent.contractDto)
                    {
                        column = 0;
                        xlWorksheet.Cells[row, ++column] = row + 1;
                        xlWorksheet.Cells[row, ++column] = contract.SpaceunitCombinedName;
                        xlWorksheet.Cells[row, ++column] = contract.ContractorName;
                        xlWorksheet.Cells[row, ++column] = contract.ContractStartDate;
                        xlWorksheet.Cells[row, ++column] = contract.ContractEndDate;
                        xlWorksheet.Cells[row, ++column] = contract.ContractAmount;
                        xlWorksheet.Cells[row, ++column] = contract.NoOfInstallments;
                        foreach (ContractPayment payment in contract.Contractpayments)
                        {
                            xlWorksheet.Cells[row, ++column] = payment.Amount;
                            xlWorksheet.Cells[row, ++column] = payment.DueDate.Value.ToString("MM/dd/yyyy");
                            xlWorksheet.Cells[row, ++column] = payment.Status;

                        }
                        row++;

                    }

                }



                //var activeWorkbook = ((Excel.Workbook) Application.ActiveWorkbook);
                string invoicePath = System.IO.Path.GetDirectoryName(templatePath);
                string file = string.Format(@"{0}\Invoice_{1}.xlsx", "output", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" +
                                            DateTime.Now.Day);



                invoicePath = System.IO.Path.Combine(invoicePath, file);
                if (File.Exists(invoicePath))
                    File.Delete(invoicePath);
                if (!Directory.Exists(Path.GetDirectoryName(invoicePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(invoicePath));
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
               Process.Start(invoicePath);
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex);
            }
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
