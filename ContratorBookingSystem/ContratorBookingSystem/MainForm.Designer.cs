namespace ContratorBookingSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnRentReport = new System.Windows.Forms.Button();
            this.btnRepoprts = new System.Windows.Forms.Button();
            this.NewPayment = new System.Windows.Forms.Button();
            this.NewContractor = new System.Windows.Forms.Button();
            this.BuildingMgmt = new System.Windows.Forms.Button();
            this.RentReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(691, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mirza Rashid Mehmood Property Management L.L.C";
            // 
            // btnRentReport
            // 
            this.btnRentReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRentReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRentReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentReport.Image = global::ContratorBookingSystem.Properties.Resources.Logistics;
            this.btnRentReport.Location = new System.Drawing.Point(579, 413);
            this.btnRentReport.Name = "btnRentReport";
            this.btnRentReport.Size = new System.Drawing.Size(327, 174);
            this.btnRentReport.TabIndex = 5;
            this.btnRentReport.Text = "Monthly Report";
            this.btnRentReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRentReport.UseVisualStyleBackColor = false;
            this.btnRentReport.Click += new System.EventHandler(this.btnRentReport_Click);
            // 
            // btnRepoprts
            // 
            this.btnRepoprts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRepoprts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRepoprts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepoprts.Image = global::ContratorBookingSystem.Properties.Resources.Logistics;
            this.btnRepoprts.Location = new System.Drawing.Point(217, 413);
            this.btnRepoprts.Name = "btnRepoprts";
            this.btnRepoprts.Size = new System.Drawing.Size(327, 174);
            this.btnRepoprts.TabIndex = 3;
            this.btnRepoprts.Text = "Cheque/Agrement Report";
            this.btnRepoprts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRepoprts.UseVisualStyleBackColor = false;
            this.btnRepoprts.Click += new System.EventHandler(this.btnRepoprts_Click);
            // 
            // NewPayment
            // 
            this.NewPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewPayment.BackColor = System.Drawing.Color.Plum;
            this.NewPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPayment.Image = global::ContratorBookingSystem.Properties.Resources.prices_edit_64;
            this.NewPayment.Location = new System.Drawing.Point(931, 171);
            this.NewPayment.Name = "NewPayment";
            this.NewPayment.Size = new System.Drawing.Size(327, 174);
            this.NewPayment.TabIndex = 2;
            this.NewPayment.Text = "New Payment";
            this.NewPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewPayment.UseVisualStyleBackColor = false;
            this.NewPayment.Click += new System.EventHandler(this.NewPayment_Click);
            // 
            // NewContractor
            // 
            this.NewContractor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewContractor.BackColor = System.Drawing.Color.OliveDrab;
            this.NewContractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewContractor.Image = global::ContratorBookingSystem.Properties.Resources.gangster;
            this.NewContractor.Location = new System.Drawing.Point(579, 171);
            this.NewContractor.Name = "NewContractor";
            this.NewContractor.Size = new System.Drawing.Size(327, 174);
            this.NewContractor.TabIndex = 1;
            this.NewContractor.Text = "New Contractor && Contract";
            this.NewContractor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewContractor.UseVisualStyleBackColor = false;
            this.NewContractor.Click += new System.EventHandler(this.NewContractor_Click);
            // 
            // BuildingMgmt
            // 
            this.BuildingMgmt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BuildingMgmt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BuildingMgmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildingMgmt.Image = global::ContratorBookingSystem.Properties.Resources.office_building_icon;
            this.BuildingMgmt.Location = new System.Drawing.Point(217, 171);
            this.BuildingMgmt.Name = "BuildingMgmt";
            this.BuildingMgmt.Size = new System.Drawing.Size(327, 174);
            this.BuildingMgmt.TabIndex = 0;
            this.BuildingMgmt.Text = "Building && Space Unit Management ";
            this.BuildingMgmt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BuildingMgmt.UseVisualStyleBackColor = false;
            this.BuildingMgmt.Click += new System.EventHandler(this.BuildingMgmt_Click);
            // 
            // RentReport
            // 
            this.RentReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RentReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RentReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RentReport.Image = global::ContratorBookingSystem.Properties.Resources.Logistics;
            this.RentReport.Location = new System.Drawing.Point(931, 413);
            this.RentReport.Name = "RentReport";
            this.RentReport.Size = new System.Drawing.Size(327, 174);
            this.RentReport.TabIndex = 6;
            this.RentReport.Text = "Rent Report";
            this.RentReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RentReport.UseVisualStyleBackColor = false;
            this.RentReport.Click += new System.EventHandler(this.RentReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1224, 646);
            this.Controls.Add(this.RentReport);
            this.Controls.Add(this.btnRentReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRepoprts);
            this.Controls.Add(this.NewPayment);
            this.Controls.Add(this.NewContractor);
            this.Controls.Add(this.BuildingMgmt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Mirza Rashid Mehmood Property Management L.L.C";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuildingMgmt;
        private System.Windows.Forms.Button NewContractor;
        private System.Windows.Forms.Button NewPayment;
        private System.Windows.Forms.Button btnRepoprts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRentReport;
        private System.Windows.Forms.Button RentReport;
    }
}

