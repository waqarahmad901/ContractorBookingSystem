using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataLayer;
using System.Linq;
using System.Globalization;
using System.Drawing;
using System.ComponentModel;

namespace ContratorBookingSystem
{
    public partial class AddContract : Form
    {
        DataAccess da = new DataAccess();
        Contract contract = null;
        public int _customerId = 0;
        IList<CustomSpaceUnit> cuList = null;
        private bool _isNew = false;
        public int _contractId = 0;
        public int _spaceUnitId = 0;
        public AddContract(int customerId,int spaceUnitId = 0)
        {
            _spaceUnitId = spaceUnitId;
            InitializeComponent();
            InitializeControl(customerId);
           

        }

        private void InitializeControl(int customerId)
        {
            try
            {
                ddBuilding.DataSource = da.GetBuildings();
                ddBuilding.DisplayMember = "Name";
                ddBuilding.ValueMember = "Id";
                int buildingId = ((Building)ddBuilding.SelectedItem).Id;
                if (_spaceUnitId != 0)
                {
                    buildingId = da.GetSpaceUnitsById(_spaceUnitId).BuildingId;
                }
                cuList = da.GetSpaceUnitWithBuildingsByBuildingId(buildingId);
                BindSpaceUintListBox();
                _customerId = customerId;
                PaymentSetting();

                paymentGrid.DataSource = new List<ContractPayment>();
                txtEndDate.Text = DateTime.Now.AddYears(1).AddDays(-1).ToShortDateString();
                ddStatus.Text = ContractStatus.DUE;
                var contractor = da.GetCustomerById(_customerId);
                txtContracotName.Text = contractor.Name + " ---- " + contractor.ContactNumber;


                lblRemainigAmount.Text = "";
                lblAmountPaid.Text = "";
                lblOutstandingAmount.Text = "";
                lblTotalAmount.Text = "";

            }
            catch (Exception ex)
            {
                LogWriter.Write(ex);
            }
        }

        private void PaymentSetting()
        {
            try
            {
                paymentGrid.AutoGenerateColumns = false;
                paymentGrid.AutoSize = true;

                // Initialize and add a text box column.
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Id";
                column.Name = "";
                column.Width = 100;
                paymentGrid.Columns.Add(column);
                column.Visible = false;



                // Initialize and add a text box column.
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "PaymentNo";
                column.Name = "PaymentNo";
                column.Width = 100;
                paymentGrid.Columns.Add(column);

                // Initialize and add a text box column.
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "PaymentMethod";
                column.Name = "PaymentMethod";
                column.Width = 100;
                paymentGrid.Columns.Add(column);

                // Initialize and add a text box column.
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Amount";
                column.Name = "Amount";
                column.Width = 100;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                paymentGrid.Columns.Add(column);

                // Initialize and add a text box column.
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "DueDate";
                column.Name = "DueDate";
                column.Width = 150;
                paymentGrid.Columns.Add(column);

                // Initialize and add a text box column.
                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Status";
                column.Name = "Status";
                column.Width = 100;
                paymentGrid.Columns.Add(column);
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex);
            }
        }

        public void SelectBuildingAndSpaceUnit()
        {
            var sp = da.GetSpaceUnitsById(_spaceUnitId);
            ddBuilding.SelectedIndex = ddBuilding.FindStringExact(sp.Building.Name);
           
            CustomSpaceUnit cps = new CustomSpaceUnit { Id = sp.Id ,Name = sp.Name};
            for (int i = lstSUInput.Items.Count - 1; i > -1; i--)
            {
                {
                    if (((CustomSpaceUnit)lstSUInput.Items[i]).Id == cps.Id)
                    {
                        lstSUInput.Items.RemoveAt(i);
                    }
                }
            }
                lstOutput.Items.Add(cps);
            


        }

        public void updatePaymentInfo(bool fromEdit = false)
        {
            try
            {
                var paymentda = new DataAccess();
                var tempContract = paymentda.GetContractById(_contractId);
                lblTotalAmount.Text = getFormattedPayment(tempContract.Amount.Value);
                decimal ammountPaid = tempContract.ContractPayments.Where(x => x.Status == PaymentStatus.COMPLETE).Sum(x => x.Amount).Value;
                decimal remaingAmount = tempContract.Amount.Value - ammountPaid;
                lblRemainigAmount.Text = getFormattedPayment(remaingAmount);
                lblAmountPaid.Text = getFormattedPayment(ammountPaid);
                decimal totalAmountPayment = tempContract.ContractPayments.Sum(x => x.Amount).Value;
                lblOutstandingAmount.Text = getFormattedPayment(tempContract.Amount.Value - totalAmountPayment).Replace("(", "- ").Replace(")", "");

                if (ammountPaid >= tempContract.Amount && !fromEdit)
                {
                    var confirmResult = MessageBox.Show("Are you sure to close this contract??", "Close Contract!", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        ddStatus.Text = tempContract.Status = ContractStatus.COMPLETE;
                        var duePayment = tempContract.ContractPayments.Where(x => x.Status == PaymentStatus.DUE).ToList();
                        duePayment.ForEach(x => x.Amount = 0);
                        save.Enabled = btnAddPayment.Enabled = btnCloseAgreement.Enabled = false;
                        btnRenew.Enabled = true;
                        paymentda.Update();
                    }


                }


                var payments = da.GetPaymentByContractId(contract.Id);
                paymentGrid.DataSource = payments;
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex);
            }

        }

        private void BindSpaceUintListBox()
        {
            lstSUInput.Items.Clear();
            foreach (var item in cuList)
            {
                item.GroupId = Guid.Empty;
                lstSUInput.Items.Add(item);
            }
            lstSUInput.DisplayMember = "Name";
            lstSUInput.ValueMember = "Id";

            lstOutput.DisplayMember = "Name";
            lstOutput.ValueMember = "Id";

            lstSUInput.SelectedIndex = 0;
        }

        public string getFormattedPayment(decimal payment)
        {
            return string.Format("{0:c}", payment).Replace("$", "");
        }
        public void EditContract(int contractId)
        {
            try
            {
                contract = da.GetContractById(contractId);
                Building building = da.GetBuildingByGroupId((Guid)contract.GroupId);
                cuList = da.GetSpaceUnitWithBuildingsByBuildingId(building.Id);
                ddBuilding.SelectedIndex = ddBuilding.FindStringExact(building.Name);

                txtStartDate.Text = contract.StartDate.ToString();
                txtEndDate.Text = contract.EndDate.ToString();
                txtAmount.Text = txtAmount.Text = string.Format("{0:c}", contract.Amount).Replace("$", "");
                ddStatus.Text = contract.Status;
                txtInstallments.Text = contract.NoOfInstallments.ToString();

                IList<CustomSpaceUnit> outputList = da.GetSpaceUnitWithBuildingsByGroupId((Guid)contract.GroupId);
              
                List<int> ids = outputList.Select(x => x.Id).ToList();
                var inputList = cuList.Where(x => !ids.Contains(x.Id)).ToList();
                lstSUInput.Items.Clear();
                lstOutput.Items.Clear();

                foreach (var item in outputList)
                {
                    lstOutput.Items.Add(item);
                }

                foreach (var item in inputList)
                {
                    lstSUInput.Items.Add(item);
                }
                var payments = da.GetPaymentByContractId(contract.Id);
                paymentGrid.DataSource = payments;
                btnNewContrator.Enabled = false;
                btnAddPayment.Enabled = btnCloseAgreement.Enabled = true;

                if (contract.Status == ContractStatus.COMPLETE)
                {
                    btnAddPayment.Enabled = save.Enabled = btnCloseAgreement.Enabled = false;
                    btnRenew.Enabled = true;

                }

                _contractId = contractId;

                updatePaymentInfo(true);
            }
            catch (Exception ex)
            {
                LogWriter.Write(ex);
            }

        }
        private void save_Click(object sender, EventArgs e)
        {
            if (_customerId == 0)
            {
                MessageBox.Show("Please create new contrator");
                return;
            }
            if (lstOutput.Items.Count == 0)
            {
                MessageBox.Show("Please select atleast one space unit. ");
                return;
            }

            



            CreateNewContract();

            SaveContract();
        }

        private void SaveContract()
        {
            try
            {
                var items = lstOutput.Items;
                if (_isNew)
                    da.AddContract(contract);
                else {
                    da.DeleteCustomerSpaceUnitByGroupId((Guid)contract.GroupId);

                }
                foreach (var item in items)
                {
                    CustomerSpaceUnit spu = new CustomerSpaceUnit();
                    spu.CustomerId = _customerId;
                    spu.SpaceUnitId = ((CustomSpaceUnit)item).Id;
                    spu.GroupId = contract.GroupId;
                    da.AddCustomerSpaceUnit(spu);
                }
                int installments = (int)contract.NoOfInstallments;
                decimal amount = (decimal)contract.Amount;
                int totlaDays = (contract.EndDate - contract.StartDate).Value.Days;

                decimal amountPerInstallment = Math.Round(amount / installments,2);
                int daysPerInstallments = totlaDays / installments;
                int monthPerInstallment = daysPerInstallments / 30;
                DateTime contStartDate = contract.StartDate.Value;
                decimal tempAmount = 0;
                if (_isNew)
                {
                    for (int i = 0; i < installments; i++)
                    {
                        ContractPayment cp = new ContractPayment();
                        cp.PaymentMethod = "Cheque";
                        cp.PaymentNo = i + 1;

                        cp.DueDate = contStartDate;
                        contStartDate = contStartDate.AddMonths(monthPerInstallment);

                        cp.Amount = amountPerInstallment;
                        tempAmount += amountPerInstallment;

                        cp.Status = PaymentStatus.DUE;
                        contract.ContractPayments.Add(cp);
                    }
                }
                da.Update();

                var payments = da.GetPaymentByContractId(contract.Id);
                paymentGrid.DataSource = payments;
                _contractId = contract.Id;

                updatePaymentInfo();
                btnNewContrator.Enabled = false;
                btnAddPayment.Enabled = btnCloseAgreement.Enabled = true;
                _isNew = false;
            }
            catch (Exception ex)
            {
                LogWriter.Write("Exception ---" + ex.Message + ex.StackTrace + "----" + ex.Source + "---" + ex.InnerException);
            }
        }

        private void CreateNewContract(bool fromRenew = false)
        {
            if (contract == null)
            {
                contract = new Contract();
                contract.GroupId = Guid.NewGuid();
                _isNew = true;

            }

            contract.StartDate = DateTime.Parse(txtStartDate.Text);
            contract.EndDate = DateTime.Parse(txtEndDate.Text);
            contract.Amount = decimal.Parse(txtAmount.Text);
            contract.Status = ContractStatus.DUE;
            contract.NoOfInstallments = decimal.Parse(txtInstallments.Text);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lstSUInput.SelectedItems.Count > 0)
            {

                var item = lstSUInput.SelectedItem;


                lstSUInput.Items.Remove(item);
                lstOutput.Items.Add(item);

            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (lstOutput.SelectedItems.Count > 0)
            {
                var item = lstOutput.SelectedItem;

                lstOutput.Items.Remove(item);
                lstSUInput.Items.Add(item);

            }
        }

        private void ddBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            int buildingId = ((Building)ddBuilding.SelectedItem).Id;
            cuList = da.GetSpaceUnitWithBuildingsByBuildingId(buildingId);
            lstOutput.Items.Clear();
            lstSUInput.Items.Clear();
            if(cuList.Count > 0)
              BindSpaceUintListBox();

        }

        private void paymentGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int payemtId = 0;
            if (paymentGrid.SelectedRows.Count > 0)
            {
                var row = paymentGrid.SelectedRows[0];
                payemtId = ((dynamic)row.DataBoundItem).Id;

            }
            var form = new AddPayment();
            form.EditPayment(payemtId);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                DataAccess pa = new DataAccess();
                paymentGrid.DataSource = pa.GetPaymentByContractId(contract.Id);

                //todo: noting
            }
        }



        private void txtAmount_Leave(object sender, EventArgs e)
        {

            if (txtAmount.Text != "")
            {
                float num;
                bool isValid = float.TryParse(txtAmount.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), // cached
                out num);
                if (!isValid)
                {
                    MessageBox.Show("Please enter valid amount. ");
                    txtAmount.Text = "";
                    return;
                }
                txtAmount.Text = string.Format("{0:c}", Convert.ToDecimal(txtAmount.Text)).Replace("$", "");
            }
        }

        private void paymentGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow dgvr in paymentGrid.Rows)
            {
                if (dgvr.Cells[5].Value.ToString() == PaymentStatus.DUE)
                {
                    dgvr.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                    dgvr.DefaultCellStyle.ForeColor = Color.Green;
            }
        }

        private void btnNewContrator_Click(object sender, EventArgs e)
        {
            var form = new AddContractor(0);

            if (form.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        public void updateCustomerName(string customerName, int customerId)
        {
            txtContracotName.Text = customerName;
            _customerId = customerId;
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            var form = new AddPayment();
            form.AddNewPayment(_contractId);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                DataAccess pa = new DataAccess();
                var tempContr = pa.GetContractById(_contractId);
                tempContr.NoOfInstallments = tempContr.NoOfInstallments + 1;
                txtInstallments.Text = tempContr.NoOfInstallments.ToString();
                pa.Update();

            }
        }

        private void btnCloseAgreement_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Are you sure to close this contract?", "Close Contract!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var contract = da.GetContractById(_contractId);
                    ddStatus.Text = contract.Status = ContractStatus.COMPLETE;
                    var duePayment = contract.ContractPayments.Where(x => x.Status == PaymentStatus.DUE).ToList();
                    duePayment.ForEach(x => x.Amount = 0);
                    da.Update();
                    save.Enabled = btnAddPayment.Enabled = btnCloseAgreement.Enabled = false;
                    btnRenew.Enabled = true;

                }

                paymentGrid.DataSource = da.GetPaymentByContractId(contract.Id);

            }
            catch (Exception ex)
            {
                LogWriter.Write("Exception ---" + ex.Message + ex.StackTrace + "----" + ex.Source + "---" + ex.InnerException);
            }


        }

        private void btnRenew_Click(object sender, EventArgs e)
        {

            try
            {

                //  CreateNewContract(true);


                EditContract(_contractId);
                paymentGrid.DataSource = new List<ContractPayment>();
                txtStartDate.Text = DateTime.Parse(txtEndDate.Text).AddDays(1).ToShortDateString();
                txtEndDate.Text = DateTime.Parse(txtEndDate.Text).AddYears(1).ToShortDateString();

                btnRenew.Enabled = false;
                save.Enabled = true;
                contract = null;

            }
            catch (Exception ex)
            {
                LogWriter.Write(ex);
            }
        }

        private void txtInstallments_Leave(object sender, EventArgs e)
        {
            if (txtInstallments.Text != "")
            {
                int num;
                bool isValid = int.TryParse(txtInstallments.Text, out num);
                if (!isValid)
                {
                    MessageBox.Show("Please enter valid number of installments. ");
                    txtInstallments.Text = "";
                    return;
                }
            }
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (paymentGrid.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete payemnt?", "Delete Payment!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var row = paymentGrid.SelectedRows[0];
                    int paymentId = ((dynamic)row.DataBoundItem).Id;
                    da.DeletePaymentById(paymentId);
                 
                    da = new DataAccess();
                    updatePaymentInfo();

                }
            }
        }
    }
}
