namespace ContratorBookingSystem
{
    partial class SpaceUnitContractForm
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
            this.ContractGrid = new System.Windows.Forms.DataGridView();
            this.NewContract = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ContractGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContractGrid
            // 
            this.ContractGrid.BackgroundColor = System.Drawing.Color.OliveDrab;
            this.ContractGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContractGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContractGrid.Location = new System.Drawing.Point(0, 0);
            this.ContractGrid.MultiSelect = false;
            this.ContractGrid.Name = "ContractGrid";
            this.ContractGrid.ReadOnly = true;
            this.ContractGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractGrid.RowTemplate.Height = 28;
            this.ContractGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ContractGrid.Size = new System.Drawing.Size(1405, 359);
            this.ContractGrid.TabIndex = 2;
            this.ContractGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ContractGrid_CellMouseDoubleClick);
            // 
            // NewContract
            // 
            this.NewContract.Location = new System.Drawing.Point(16, 34);
            this.NewContract.Name = "NewContract";
            this.NewContract.Size = new System.Drawing.Size(179, 44);
            this.NewContract.TabIndex = 3;
            this.NewContract.Text = "New Contract";
            this.NewContract.UseVisualStyleBackColor = true;
            this.NewContract.Click += new System.EventHandler(this.NewContract_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ContractGrid);
            this.panel2.Location = new System.Drawing.Point(16, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1405, 359);
            this.panel2.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(225, 34);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(179, 44);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete Contract";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // SpaceUnitContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1433, 495);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.NewContract);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpaceUnitContractForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contractor & Contract Management ";
            ((System.ComponentModel.ISupportInitialize)(this.ContractGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ContractGrid;
        private System.Windows.Forms.Button NewContract;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
    }
}