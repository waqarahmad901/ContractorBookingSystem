namespace ContratorBookingSystem
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.label1 = new System.Windows.Forms.Label();
            this.ddFromDate = new System.Windows.Forms.DateTimePicker();
            this.ddToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.RentIncomGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGrid();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAgreementText = new System.Windows.Forms.Label();
            this.lblInstallmentAmount = new System.Windows.Forms.Label();
            this.lblAgrementAmount = new System.Windows.Forms.Label();
            this.lblInstallmentText = new System.Windows.Forms.Label();
            this.lblReportHeader = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.lblAgreementAmountForPrint = new System.Windows.Forms.Label();
            this.lblInstallmentAmountValue = new System.Windows.Forms.Label();
            this.lblAgrementAmountValue = new System.Windows.Forms.Label();
            this.lblIntallmentAmountForPrint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RentIncomGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date: ";
            // 
            // ddFromDate
            // 
            this.ddFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ddFromDate.Location = new System.Drawing.Point(104, 30);
            this.ddFromDate.Name = "ddFromDate";
            this.ddFromDate.Size = new System.Drawing.Size(260, 22);
            this.ddFromDate.TabIndex = 3;
            // 
            // ddToDate
            // 
            this.ddToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ddToDate.Location = new System.Drawing.Point(482, 30);
            this.ddToDate.Name = "ddToDate";
            this.ddToDate.Size = new System.Drawing.Size(260, 22);
            this.ddToDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date: ";
            // 
            // RentIncomGrid
            // 
            this.RentIncomGrid.BackgroundColor = System.Drawing.Color.Moccasin;
            this.RentIncomGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RentIncomGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RentIncomGrid.Location = new System.Drawing.Point(0, 0);
            this.RentIncomGrid.MultiSelect = false;
            this.RentIncomGrid.Name = "RentIncomGrid";
            this.RentIncomGrid.ReadOnly = true;
            this.RentIncomGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RentIncomGrid.RowTemplate.Height = 28;
            this.RentIncomGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RentIncomGrid.Size = new System.Drawing.Size(1164, 482);
            this.RentIncomGrid.TabIndex = 6;
            this.RentIncomGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RentIncomGrid_ColumnHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.RentIncomGrid);
            this.panel1.Location = new System.Drawing.Point(19, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 482);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.DataMember = "";
            this.dataGridView1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(14, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1152, 150);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.Visible = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(779, 23);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(176, 41);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1007, 23);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(176, 41);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAgreementText);
            this.groupBox1.Controls.Add(this.lblInstallmentAmount);
            this.groupBox1.Controls.Add(this.lblAgrementAmount);
            this.groupBox1.Controls.Add(this.lblInstallmentText);
            this.groupBox1.Location = new System.Drawing.Point(19, 622);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summery";
            // 
            // lblAgreementText
            // 
            this.lblAgreementText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAgreementText.AutoSize = true;
            this.lblAgreementText.Location = new System.Drawing.Point(6, 35);
            this.lblAgreementText.Name = "lblAgreementText";
            this.lblAgreementText.Size = new System.Drawing.Size(161, 17);
            this.lblAgreementText.TabIndex = 10;
            this.lblAgreementText.Text = "Total Agrement Amount:";
            // 
            // lblInstallmentAmount
            // 
            this.lblInstallmentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstallmentAmount.AutoSize = true;
            this.lblInstallmentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallmentAmount.Location = new System.Drawing.Point(223, 65);
            this.lblInstallmentAmount.Name = "lblInstallmentAmount";
            this.lblInstallmentAmount.Size = new System.Drawing.Size(44, 20);
            this.lblInstallmentAmount.TabIndex = 13;
            this.lblInstallmentAmount.Text = "0.00";
            // 
            // lblAgrementAmount
            // 
            this.lblAgrementAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAgrementAmount.AutoSize = true;
            this.lblAgrementAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgrementAmount.Location = new System.Drawing.Point(223, 32);
            this.lblAgrementAmount.Name = "lblAgrementAmount";
            this.lblAgrementAmount.Size = new System.Drawing.Size(44, 20);
            this.lblAgrementAmount.TabIndex = 11;
            this.lblAgrementAmount.Text = "0.00";
            // 
            // lblInstallmentText
            // 
            this.lblInstallmentText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstallmentText.AutoSize = true;
            this.lblInstallmentText.Location = new System.Drawing.Point(6, 68);
            this.lblInstallmentText.Name = "lblInstallmentText";
            this.lblInstallmentText.Size = new System.Drawing.Size(167, 17);
            this.lblInstallmentText.TabIndex = 12;
            this.lblInstallmentText.Text = "Total Installment Amount:";
            // 
            // lblReportHeader
            // 
            this.lblReportHeader.AutoSize = true;
            this.lblReportHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportHeader.Location = new System.Drawing.Point(15, 47);
            this.lblReportHeader.Name = "lblReportHeader";
            this.lblReportHeader.Size = new System.Drawing.Size(231, 20);
            this.lblReportHeader.TabIndex = 16;
            this.lblReportHeader.Text = "Check / Agreement Report";
            this.lblReportHeader.Visible = false;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(16, 81);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(100, 17);
            this.lblDateRange.TabIndex = 17;
            this.lblDateRange.Text = "From {0} to {1}";
            this.lblDateRange.Visible = false;
            // 
            // lblAgreementAmountForPrint
            // 
            this.lblAgreementAmountForPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAgreementAmountForPrint.AutoSize = true;
            this.lblAgreementAmountForPrint.Location = new System.Drawing.Point(529, 55);
            this.lblAgreementAmountForPrint.Name = "lblAgreementAmountForPrint";
            this.lblAgreementAmountForPrint.Size = new System.Drawing.Size(161, 17);
            this.lblAgreementAmountForPrint.TabIndex = 14;
            this.lblAgreementAmountForPrint.Text = "Total Agrement Amount:";
            this.lblAgreementAmountForPrint.Visible = false;
            // 
            // lblInstallmentAmountValue
            // 
            this.lblInstallmentAmountValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstallmentAmountValue.AutoSize = true;
            this.lblInstallmentAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallmentAmountValue.Location = new System.Drawing.Point(746, 85);
            this.lblInstallmentAmountValue.Name = "lblInstallmentAmountValue";
            this.lblInstallmentAmountValue.Size = new System.Drawing.Size(44, 20);
            this.lblInstallmentAmountValue.TabIndex = 17;
            this.lblInstallmentAmountValue.Text = "0.00";
            this.lblInstallmentAmountValue.Visible = false;
            // 
            // lblAgrementAmountValue
            // 
            this.lblAgrementAmountValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAgrementAmountValue.AutoSize = true;
            this.lblAgrementAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgrementAmountValue.Location = new System.Drawing.Point(746, 52);
            this.lblAgrementAmountValue.Name = "lblAgrementAmountValue";
            this.lblAgrementAmountValue.Size = new System.Drawing.Size(44, 20);
            this.lblAgrementAmountValue.TabIndex = 15;
            this.lblAgrementAmountValue.Text = "0.00";
            this.lblAgrementAmountValue.Visible = false;
            // 
            // lblIntallmentAmountForPrint
            // 
            this.lblIntallmentAmountForPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIntallmentAmountForPrint.AutoSize = true;
            this.lblIntallmentAmountForPrint.Location = new System.Drawing.Point(529, 88);
            this.lblIntallmentAmountForPrint.Name = "lblIntallmentAmountForPrint";
            this.lblIntallmentAmountForPrint.Size = new System.Drawing.Size(167, 17);
            this.lblIntallmentAmountForPrint.TabIndex = 16;
            this.lblIntallmentAmountForPrint.Text = "Total Installment Amount:";
            this.lblIntallmentAmountForPrint.Visible = false;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 734);
            this.Controls.Add(this.lblAgreementAmountForPrint);
            this.Controls.Add(this.lblInstallmentAmountValue);
            this.Controls.Add(this.lblDateRange);
            this.Controls.Add(this.lblAgrementAmountValue);
            this.Controls.Add(this.lblReportHeader);
            this.Controls.Add(this.lblIntallmentAmountForPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ddToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddFromDate);
            this.Controls.Add(this.label1);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check / Agreement Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RentIncomGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ddFromDate;
        private System.Windows.Forms.DateTimePicker ddToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView RentIncomGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGrid dataGridView1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAgreementText;
        private System.Windows.Forms.Label lblInstallmentAmount;
        private System.Windows.Forms.Label lblAgrementAmount;
        private System.Windows.Forms.Label lblInstallmentText;
        private System.Windows.Forms.Label lblReportHeader;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblAgreementAmountForPrint;
        private System.Windows.Forms.Label lblInstallmentAmountValue;
        private System.Windows.Forms.Label lblAgrementAmountValue;
        private System.Windows.Forms.Label lblIntallmentAmountForPrint;
    }
}