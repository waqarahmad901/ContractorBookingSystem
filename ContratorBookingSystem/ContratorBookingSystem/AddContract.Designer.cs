namespace ContratorBookingSystem
{
    partial class AddContract
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lstSUInput = new System.Windows.Forms.ListBox();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.ddBuilding = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInstallments = new System.Windows.Forms.MaskedTextBox();
            this.ddStatus = new System.Windows.Forms.ComboBox();
            this.pnlPaymnet = new System.Windows.Forms.Panel();
            this.paymentGrid = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtContracotName = new System.Windows.Forms.Label();
            this.btnNewContrator = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblRemainigAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblOutstandingAmount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnCloseAgreement = new System.Windows.Forms.Button();
            this.btnDeletePayment = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlPaymnet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date: ";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(160, 624);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(106, 49);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.CausesValidation = false;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cancel.Location = new System.Drawing.Point(321, 624);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(106, 49);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "End Date: ";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(139, 117);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(309, 22);
            this.txtAmount.TabIndex = 9;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Installments: ";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtStartDate.Location = new System.Drawing.Point(139, 31);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(309, 22);
            this.txtStartDate.TabIndex = 14;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtEndDate.Location = new System.Drawing.Point(139, 78);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(309, 22);
            this.txtEndDate.TabIndex = 15;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(275, 453);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 31);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(275, 490);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(39, 31);
            this.btnPrevious.TabIndex = 19;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lstSUInput
            // 
            this.lstSUInput.FormattingEnabled = true;
            this.lstSUInput.ItemHeight = 16;
            this.lstSUInput.Location = new System.Drawing.Point(100, 333);
            this.lstSUInput.Name = "lstSUInput";
            this.lstSUInput.Size = new System.Drawing.Size(166, 276);
            this.lstSUInput.TabIndex = 20;
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 16;
            this.lstOutput.Location = new System.Drawing.Point(321, 333);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(127, 276);
            this.lstOutput.TabIndex = 21;
            // 
            // ddBuilding
            // 
            this.ddBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddBuilding.FormattingEnabled = true;
            this.ddBuilding.Location = new System.Drawing.Point(139, 263);
            this.ddBuilding.Name = "ddBuilding";
            this.ddBuilding.Size = new System.Drawing.Size(309, 24);
            this.ddBuilding.TabIndex = 22;
            this.ddBuilding.SelectedIndexChanged += new System.EventHandler(this.ddBuilding_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Select Building: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(20, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 3);
            this.panel1.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtInstallments);
            this.groupBox1.Controls.Add(this.ddStatus);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.ddBuilding);
            this.groupBox1.Controls.Add(this.cancel);
            this.groupBox1.Controls.Add(this.lstOutput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstSUInput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 698);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contract Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Assign Space unit or Flats that might ";
            // 
            // txtInstallments
            // 
            this.txtInstallments.Location = new System.Drawing.Point(139, 195);
            this.txtInstallments.Name = "txtInstallments";
            this.txtInstallments.Size = new System.Drawing.Size(309, 22);
            this.txtInstallments.TabIndex = 26;
            this.txtInstallments.Leave += new System.EventHandler(this.txtInstallments_Leave);
            // 
            // ddStatus
            // 
            this.ddStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddStatus.Enabled = false;
            this.ddStatus.FormattingEnabled = true;
            this.ddStatus.Items.AddRange(new object[] {
            "Due",
            "Complete"});
            this.ddStatus.Location = new System.Drawing.Point(139, 156);
            this.ddStatus.Name = "ddStatus";
            this.ddStatus.Size = new System.Drawing.Size(309, 24);
            this.ddStatus.TabIndex = 25;
            // 
            // pnlPaymnet
            // 
            this.pnlPaymnet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaymnet.Controls.Add(this.paymentGrid);
            this.pnlPaymnet.Location = new System.Drawing.Point(488, 105);
            this.pnlPaymnet.Name = "pnlPaymnet";
            this.pnlPaymnet.Size = new System.Drawing.Size(890, 521);
            this.pnlPaymnet.TabIndex = 26;
            // 
            // paymentGrid
            // 
            this.paymentGrid.BackgroundColor = System.Drawing.Color.Moccasin;
            this.paymentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentGrid.Location = new System.Drawing.Point(0, 0);
            this.paymentGrid.MultiSelect = false;
            this.paymentGrid.Name = "paymentGrid";
            this.paymentGrid.ReadOnly = true;
            this.paymentGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentGrid.RowTemplate.Height = 28;
            this.paymentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.paymentGrid.Size = new System.Drawing.Size(890, 521);
            this.paymentGrid.TabIndex = 2;
            this.paymentGrid.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.paymentGrid_RowPrePaint);
            this.paymentGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.paymentGrid_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(485, 663);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Total Amount: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(485, 725);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Remiaing Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtContracotName);
            this.groupBox2.Controls.Add(this.btnNewContrator);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 72);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contractor Information";
            // 
            // txtContracotName
            // 
            this.txtContracotName.AutoSize = true;
            this.txtContracotName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContracotName.Location = new System.Drawing.Point(95, 31);
            this.txtContracotName.Name = "txtContracotName";
            this.txtContracotName.Size = new System.Drawing.Size(57, 20);
            this.txtContracotName.TabIndex = 2;
            this.txtContracotName.Text = "Name";
            // 
            // btnNewContrator
            // 
            this.btnNewContrator.Image = global::ContratorBookingSystem.Properties.Resources.add;
            this.btnNewContrator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewContrator.Location = new System.Drawing.Point(656, 13);
            this.btnNewContrator.Name = "btnNewContrator";
            this.btnNewContrator.Size = new System.Drawing.Size(115, 52);
            this.btnNewContrator.TabIndex = 1;
            this.btnNewContrator.Text = "New";
            this.btnNewContrator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewContrator.UseVisualStyleBackColor = true;
            this.btnNewContrator.Click += new System.EventHandler(this.btnNewContrator_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Contractor :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(485, 692);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Amount Paid:";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPaid.Location = new System.Drawing.Point(666, 692);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(120, 18);
            this.lblAmountPaid.TabIndex = 35;
            this.lblAmountPaid.Text = "lblAmountPaid:";
            // 
            // lblRemainigAmount
            // 
            this.lblRemainigAmount.AutoSize = true;
            this.lblRemainigAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainigAmount.Location = new System.Drawing.Point(666, 725);
            this.lblRemainigAmount.Name = "lblRemainigAmount";
            this.lblRemainigAmount.Size = new System.Drawing.Size(157, 18);
            this.lblRemainigAmount.TabIndex = 34;
            this.lblRemainigAmount.Text = "lblRemainigAmount:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(666, 663);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(120, 18);
            this.lblTotalAmount.TabIndex = 33;
            this.lblTotalAmount.Text = "lblTotalAmount";
            // 
            // lblOutstandingAmount
            // 
            this.lblOutstandingAmount.AutoSize = true;
            this.lblOutstandingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutstandingAmount.ForeColor = System.Drawing.Color.Red;
            this.lblOutstandingAmount.Location = new System.Drawing.Point(666, 764);
            this.lblOutstandingAmount.Name = "lblOutstandingAmount";
            this.lblOutstandingAmount.Size = new System.Drawing.Size(177, 18);
            this.lblOutstandingAmount.TabIndex = 37;
            this.lblOutstandingAmount.Text = "lblOutstandingAmount:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(485, 764);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 17);
            this.label13.TabIndex = 36;
            this.label13.Text = "Outstanding Amount:";
            // 
            // btnRenew
            // 
            this.btnRenew.Enabled = false;
            this.btnRenew.Image = global::ContratorBookingSystem.Properties.Resources._32_32_bced598237615236c013fc6cfe14f6b7_refresh;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.Location = new System.Drawing.Point(1156, 29);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(212, 52);
            this.btnRenew.TabIndex = 39;
            this.btnRenew.Text = "Renew Contract";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Enabled = false;
            this.btnAddPayment.Image = global::ContratorBookingSystem.Properties.Resources.add;
            this.btnAddPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPayment.Location = new System.Drawing.Point(812, 26);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(150, 52);
            this.btnAddPayment.TabIndex = 38;
            this.btnAddPayment.Text = "Add Payment";
            this.btnAddPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnCloseAgreement
            // 
            this.btnCloseAgreement.Enabled = false;
            this.btnCloseAgreement.Image = global::ContratorBookingSystem.Properties.Resources.Close__Black;
            this.btnCloseAgreement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseAgreement.Location = new System.Drawing.Point(1131, 738);
            this.btnCloseAgreement.Name = "btnCloseAgreement";
            this.btnCloseAgreement.Size = new System.Drawing.Size(237, 69);
            this.btnCloseAgreement.TabIndex = 30;
            this.btnCloseAgreement.Text = "Close Agreemnet";
            this.btnCloseAgreement.UseVisualStyleBackColor = true;
            this.btnCloseAgreement.Click += new System.EventHandler(this.btnCloseAgreement_Click);
            // 
            // btnDeletePayment
            // 
            this.btnDeletePayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletePayment.Location = new System.Drawing.Point(986, 29);
            this.btnDeletePayment.Name = "btnDeletePayment";
            this.btnDeletePayment.Size = new System.Drawing.Size(150, 52);
            this.btnDeletePayment.TabIndex = 40;
            this.btnDeletePayment.Text = "Delete Payment";
            this.btnDeletePayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletePayment.UseVisualStyleBackColor = true;
            this.btnDeletePayment.Click += new System.EventHandler(this.btnDeletePayment_Click);
            // 
            // AddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 835);
            this.Controls.Add(this.btnDeletePayment);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnAddPayment);
            this.Controls.Add(this.lblOutstandingAmount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblAmountPaid);
            this.Controls.Add(this.lblRemainigAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCloseAgreement);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnlPaymnet);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddContract";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contract Management";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlPaymnet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paymentGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtStartDate;
        private System.Windows.Forms.DateTimePicker txtEndDate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ListBox lstSUInput;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.ComboBox ddBuilding;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlPaymnet;
        private System.Windows.Forms.DataGridView paymentGrid;
        private System.Windows.Forms.ComboBox ddStatus;
        private System.Windows.Forms.MaskedTextBox txtInstallments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCloseAgreement;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNewContrator;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtContracotName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblRemainigAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblOutstandingAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnDeletePayment;
    }
}