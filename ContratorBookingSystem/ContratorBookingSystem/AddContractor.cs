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
    public partial class AddContractor : Form
    {
        DataAccess da = new DataAccess();
        Customer customer = null;
        bool isNew = false;
        public AddContractor(int customerId)
        {
            InitializeComponent();
            if (customerId != 0)
                customer = da.GetCustomers().Where(x => x.Id == customerId).FirstOrDefault();


         }

 

        private void save_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                isNew = true;
                customer = new Customer();
            }
            customer.Name = txtName.Text;
            customer.ContactNumber = txtContractNumber.Text;
            customer.ContactPerson = txtContractPerson.Text;
            customer.AnyDescription = txtDescription.Text;
            if (isNew)
                da.AddCustomer(customer);
            else
                da.Update();
            AddContract parent = (AddContract)this.Owner;
            if(parent != null)
            parent.updateCustomerName(customer.Name,customer.Id);
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void EditContractor()
        {
            txtName.Text = customer.Name;
            txtContractNumber.Text = customer.ContactNumber;
            txtContractPerson.Text = customer.ContactPerson;
            txtDescription.Text = customer.AnyDescription;
        }
    }
}
