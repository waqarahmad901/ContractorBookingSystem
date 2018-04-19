using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace ContratorBookingSystem
{
    public partial class AddSpaceUnitForm : Form
    {
        private int _buildingId { get; set; }
        DataAccess da = new DataAccess();
        public AddSpaceUnitForm(int buildingId)
        {
            InitializeComponent();
            this._buildingId = buildingId;
        }

        private void save_Click(object sender, EventArgs e)
        {
            SpaceUnit sp = new SpaceUnit();
            sp.Name = txtName.Text;
            sp.BuildingId = _buildingId;
            da.AddSpaceUnit(sp);
           
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
