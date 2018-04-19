using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InvoiceEngine
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        public string TemplateFilePath { get { return tbxTemplateFile.Text; } }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }
        
        private void btnTempalteFile_Click(object sender, EventArgs e)
        {
             tbxTemplateFile.Text = BrowseExcelFile();
        }

        private string BrowseExcelFile()
        {
            var fdlg = new OpenFileDialog();
            fdlg.Title = "Choose an Excel file ...";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
               return fdlg.FileName;
            }
            return null;
        }
    }
}
