using System;
using System.Windows.Forms;
using DataLayer;

namespace ContratorBookingSystem
{
    public partial class ContractorForm : Form
    {
        DataAccess da = new DataAccess(); 
        public ContractorForm()
        {
            InitializeComponent();
            ContractorSetting();
            LoadContractorGrid();
            ContractSetting();
          
            

           
        }

        private void LoadContractorGrid(string name = "")
        {
            CustomerGrid.DataSource = da.GetCustomers(name);
            
        }

        private void LoadContractGrid()
        {
            int customerId = 0;
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                var row = CustomerGrid.SelectedRows[0];
                customerId = ((dynamic)row.DataBoundItem).Id;

            }
            ContractGrid.DataSource = da.GetContractByCustomerId(customerId);

        }

        private void NewContractor_Click(object sender, EventArgs e)
        {
            var form = new AddContractor(0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                da = new DataAccess();
                LoadContractorGrid();

                //todo: noting
            }
        }

        

        private void ContractorSetting()
        {
            // Initialize the DataGridView.
            CustomerGrid.AutoGenerateColumns = false;
            CustomerGrid.AutoSize = true;

          

            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "";
            column.Width = 300;
            CustomerGrid.Columns.Add(column);
            column.Visible = false;


            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Name";
            column.Width = 300;
            CustomerGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ContactNumber";
            column.Name = "Contact Number";
            column.Width = 300;
            CustomerGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ContactPerson";
            column.Name = "Contact Person";
            column.Width = 300;
            CustomerGrid.Columns.Add(column);
        }



        private void ContractSetting()
        {
            // Initialize the DataGridView.
            ContractGrid.AutoGenerateColumns = false;
            ContractGrid.AutoSize = true;
            
            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "";
            column.Width = 200;
            ContractGrid.Columns.Add(column);
            column.Visible = false;


            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "SpaceUnitCombinedName";
            column.Name = "Space Units";
            column.Width = 250;
            ContractGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "StartDate";
            column.Name = "From Date";
            column.Width = 150;
            column.DefaultCellStyle.Format = "dd-MM-yyyy";
            ContractGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "EndDate";
            column.Name = "To Date";
            column.Width = 150;
            column.DefaultCellStyle.Format = "dd-MM-yyyy";
            ContractGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Amount";
            column.Name = "Amount";
            column.Width = 100;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ContractGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "NoOfInstallments";
            column.Name = "Installments";
            column.Width = 100;
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ContractGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Status";
            column.Name = "Status";
            column.Width = 150; 
            ContractGrid.Columns.Add(column);
        }

        private void NewContract_Click(object sender, EventArgs e)
        {
            int customerId = 0;
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                var row = CustomerGrid.SelectedRows[0];
                customerId = ((dynamic)row.DataBoundItem).Id;
               
            }
            var form = new AddContract(customerId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                da = new DataAccess();
                LoadContractGrid();
            }
        }

        private void CustomerGrid_SelectionChanged(object sender, EventArgs e)
        {
            LoadContractGrid();
        }

        private void ContractGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int contractId = 0;
            if (ContractGrid.SelectedRows.Count > 0)
            {
                var row = ContractGrid.SelectedRows[0];
                contractId = ((dynamic)row.DataBoundItem).Id;
            }
            int customerId = 0;
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                var row = CustomerGrid.SelectedRows[0];
                customerId = ((dynamic)row.DataBoundItem).Id;

            }
            var form = new AddContract(customerId);
            form.EditContract(contractId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                da = new DataAccess();
                LoadContractorGrid();

                //todo: noting
            }

        }

        private void CustomerGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int customerId = 0;
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                var row = CustomerGrid.SelectedRows[0];
                customerId = ((dynamic)row.DataBoundItem).Id;
            }

            var form = new AddContractor(customerId);
            form.EditContractor();
            if (form.ShowDialog() == DialogResult.OK)
            {
                da = new DataAccess();
                LoadContractorGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = textBox1.Text;
            LoadContractorGrid(searchString);
        }
    }
}
