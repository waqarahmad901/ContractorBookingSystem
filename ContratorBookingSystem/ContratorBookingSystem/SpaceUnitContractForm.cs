using System;
using System.Windows.Forms;
using DataLayer;
using System.Linq;

namespace ContratorBookingSystem
{
    public partial class SpaceUnitContractForm : Form
    {
        DataAccess da = new DataAccess();
        public int _spaceUnitId { get; set; }
        public int _customerId { get; set; }
        public SpaceUnitContractForm(int spaceUnitId)
        {
            InitializeComponent();
            _spaceUnitId = spaceUnitId;
            var sp = da.GetSpaceUnitsById(_spaceUnitId);
            var csu = sp.CustomerSpaceUnits.FirstOrDefault();
            if(csu != null)
                 _customerId = csu.CustomerId;
           ContractSetting();
            LoadContractGrid();
        }
         
        private void LoadContractGrid()
        { 
            ContractGrid.DataSource = da.GetContractBySpaceUnitId(_spaceUnitId); 
        }
         
        private void ContractSetting()
        {
            // Initialize the DataGridView.
            ContractGrid.AutoGenerateColumns = false;
            ContractGrid.AutoSize = true;
            
            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "CustomerId";
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
            
            var form = new AddContract(customerId,_spaceUnitId);
            form.SelectBuildingAndSpaceUnit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                da = new DataAccess();
                LoadContractGrid();
            }
        }
        private void ContractGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string contractId = "0";
            if (ContractGrid.SelectedRows.Count > 0)
            {
                var row = ContractGrid.SelectedRows[0];
                contractId = ((dynamic)row.DataBoundItem).CustomerId;
            }
            var form = new AddContract(int.Parse(contractId.Split('-')[0]));
            form.EditContract(int.Parse(contractId.Split('-')[1]));
            if (form.ShowDialog() == DialogResult.OK)
            {
                da = new DataAccess();
                LoadContractGrid();

                //todo: noting
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ContractGrid.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete contract?", "Delete Contract!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var row = ContractGrid.SelectedRows[0];
                    string contractId = ((dynamic)row.DataBoundItem).CustomerId;

                    da.DeleteContractById(int.Parse(contractId.Split('-')[1]));

                    da = new DataAccess();
                    LoadContractGrid();

                }
            }
        }
    }
}
