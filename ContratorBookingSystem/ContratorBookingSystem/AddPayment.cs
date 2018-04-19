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
    public partial class AddPayment : Form
    {
        DataAccess da = null;
        ContractPayment cp = null;
        public bool isNew = false;
        public int _contractId = 0;
        public AddPayment()
        {
            InitializeComponent();
        }

        internal void EditPayment(int payemtId)
        {
            da = new DataAccess();
            cp = da.GetPaymentById(payemtId);
            txtAmount.Text = cp.Amount.Value.ToString();
            ddPaymentMethod.Text = cp.PaymentMethod;
            txtPaymentNo.Text = cp.PaymentNo.ToString();
            ddStatus.Text = cp.Status;
            txtNote.Text = cp.Note;
            ddDueDate.Text = cp.DueDate.Value.ToString();
          

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                cp = new ContractPayment();
               
            }
            cp.Amount = decimal.Parse(txtAmount.Text);
            cp.PaymentMethod = ddPaymentMethod.Text;
            cp.PaymentNo = int.Parse(txtPaymentNo.Text);
            cp.Status = ddStatus.Text;
            cp.DueDate = DateTime.Parse( ddDueDate.Text);
            cp.Note = txtNote.Text;
            if (isNew)
            {
                da.AddPaymentByContractId(_contractId, cp);
            }
            else
            da.Update();

            AddContract parent = (AddContract)this.Owner;
            parent.updatePaymentInfo();

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text != "")
                txtAmount.Text = string.Format("{0:c}", Convert.ToDecimal(txtAmount.Text)).Replace("$", "");
        }

        internal void AddNewPayment(int contractId)
        {
            da = new DataAccess();
            cp = new ContractPayment();
            int paymentNo = 0;
            _contractId = contractId;
            isNew = true;
            var payments = da.GetPaymentByContractId(_contractId);
            if (payments.Count > 0)
            {
               var payment = payments.OrderBy(x => x.PaymentNo).Last();
                paymentNo = payment.PaymentNo;
            }
            txtPaymentNo.Text = (paymentNo + 1).ToString();
            ddStatus.Text = "Due";
            ddPaymentMethod.Text = "Cheque";
        }
    }
}
