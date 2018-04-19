using System;
using System.Windows.Forms;
using DataLayer;
using System.Linq;

namespace ContratorBookingSystem
{
    public partial class BuildingForm : Form
    {
        DataAccess da = new DataAccess();
        public bool sortOrder = false;
        public BuildingForm()
        {
            InitializeComponent();
            SpaceUnitGridSettings();
        }

        private void BuildingForm_Load(object sender, EventArgs e)
        {
            var list = da.GetBuildings();

            // Initialize the DataGridView.
            BuildingGrid.AutoGenerateColumns = false;
            BuildingGrid.AutoSize = true;
            BuildingGrid.DataSource = list;


            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "";
            column.Width = 350;
            BuildingGrid.Columns.Add(column);
            column.Visible = false;


            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Building Name";
            column.Width = 350;
            BuildingGrid.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ArabicName";
            column.Name = "Arabic Name";
            column.Width = 350;
            BuildingGrid.Columns.Add(column);



        }

        private void NewBuilding_Click(object sender, EventArgs e)
        {
            var form = new AddBuildingFrom();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var list = da.GetBuildings();
                BuildingGrid.DataSource = list;

                //todo: noting
            }
        }

        private void BuildingGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (BuildingGrid.SelectedRows.Count > 0)
            {
                var row = BuildingGrid.SelectedRows[0];
                int buildingId = ((dynamic)row.DataBoundItem).Id;
                LoadSpaceUnitGrid(buildingId);
            }
        }

        private void LoadSpaceUnitGrid(int buildingId)
        {
            spaceUnitGrid.Tag = buildingId;

            var spaceUnits = da.GetSpaceUnitsByBuildingId(buildingId);
            spaceUnitGrid.DataSource = spaceUnits;
            spaceUnitGrid.Refresh();


        }

        private void SpaceUnitGridSettings()
        {
            // Initialize the DataGridView.
            spaceUnitGrid.AutoGenerateColumns = false;
            spaceUnitGrid.AutoSize = true;



            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Id";
            column.Name = "";
            column.Width = 350;
            spaceUnitGrid.Columns.Add(column);
            column.Visible = false;


            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Space";
            column.Width = 350;
            spaceUnitGrid.Columns.Add(column);
        }

        private void addSpaceUnit_Click(object sender, EventArgs e)
        {
            var form = new AddSpaceUnitForm(int.Parse(spaceUnitGrid.Tag.ToString()));
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSpaceUnitGrid(int.Parse(spaceUnitGrid.Tag.ToString()));
                //todo: noting
            }
        }

        private void BuildingGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (BuildingGrid.SelectedRows.Count > 0)
            {
                var row = BuildingGrid.SelectedRows[0];
                int buildingId = ((dynamic)row.DataBoundItem).Id;

                var form = new AddBuildingFrom();
                form.EditBuilding(buildingId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    da = new DataAccess();
                    var list = da.GetBuildings();
                    BuildingGrid.DataSource = list;

                    //todo: noting
                }
            }
        }

        private void spaceUnitGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (spaceUnitGrid.SelectedRows.Count > 0)
            {
                var row = spaceUnitGrid.SelectedRows[0];
                int spId = ((dynamic)row.DataBoundItem).Id;

                var form = new SpaceUnitContractForm(spId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private void btnDelSpaceUnit_Click(object sender, EventArgs e)
        {
            if (spaceUnitGrid.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete space unit?", "Delete Space Unit!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var row = spaceUnitGrid.SelectedRows[0];
                    int spId = ((dynamic)row.DataBoundItem).Id;

                    da.DeleteSpaceUnitById(spId);

                    row = BuildingGrid.SelectedRows[0];
                    int buildingId = ((dynamic)row.DataBoundItem).Id;

                    LoadSpaceUnitGrid(buildingId);

                }
            }
        }

        private void BuildingGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var param = BuildingGrid.Columns[e.ColumnIndex].DataPropertyName;
            var pi = typeof(Building).GetProperty(param);
           
            var newVal = da.GetBuildings();
            if(!sortOrder)
                newVal = newVal.OrderBy(x => pi.GetValue(x, null)).ToList();
            else
                newVal = newVal.OrderByDescending(x => pi.GetValue(x, null)).ToList();
            sortOrder = !sortOrder;
            BuildingGrid.DataSource = newVal;
        }
    }
}
