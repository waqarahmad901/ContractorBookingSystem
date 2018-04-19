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
    public partial class AddBuildingFrom : Form
    {
        DataAccess da = new DataAccess();
        Building building =null;
        bool isNew = false;
        public AddBuildingFrom()
        {
            InitializeComponent();

            foreach (TextBox tb in this.Controls.OfType<TextBox>().Where(x => x.CausesValidation == true))
            {
                tb.Validating += textBox_Validating;
            }

        }

        public void EditBuilding(int buildingId)
        {
            building = da.GetBuildingById(buildingId);
            txtArabicName.Text = building.ArabicName;
            txtName.Text = building.Name;
        }



        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox currenttb = (TextBox)sender;
            if (currenttb.Text == "")
            {
                MessageBox.Show(string.Format("Please fill {0 } field", currenttb.Name.Substring(3)));
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }


        private void save_Click(object sender, EventArgs e)
        {
          
            if (building == null)
            {
                isNew = true;
                building = new Building();
            }
            building.Name = txtName.Text;
            building.ArabicName = txtArabicName.Text;
            if (isNew)
                da.AddBuilding(building);
            else
                da.Update();
           
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
