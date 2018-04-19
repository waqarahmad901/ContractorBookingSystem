namespace ContratorBookingSystem
{
    partial class ContractorForm
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
            this.CustomerGrid = new System.Windows.Forms.DataGridView();
            this.NewContractor = new System.Windows.Forms.Button();
            this.ContractGrid = new System.Windows.Forms.DataGridView();
            this.NewContract = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomerGrid
            // 
            this.CustomerGrid.BackgroundColor = System.Drawing.Color.OliveDrab;
            this.CustomerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerGrid.Location = new System.Drawing.Point(0, 0);
            this.CustomerGrid.MultiSelect = false;
            this.CustomerGrid.Name = "CustomerGrid";
            this.CustomerGrid.ReadOnly = true;
            this.CustomerGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerGrid.RowTemplate.Height = 28;
            this.CustomerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomerGrid.Size = new System.Drawing.Size(1405, 226);
            this.CustomerGrid.TabIndex = 0;
            this.CustomerGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CustomerGrid_CellMouseDoubleClick);
            this.CustomerGrid.SelectionChanged += new System.EventHandler(this.CustomerGrid_SelectionChanged);
            // 
            // NewContractor
            // 
            this.NewContractor.Location = new System.Drawing.Point(16, 12);
            this.NewContractor.Name = "NewContractor";
            this.NewContractor.Size = new System.Drawing.Size(179, 44);
            this.NewContractor.TabIndex = 1;
            this.NewContractor.Text = "New Contractor";
            this.NewContractor.UseVisualStyleBackColor = true;
            this.NewContractor.Click += new System.EventHandler(this.NewContractor_Click);
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
            this.ContractGrid.Size = new System.Drawing.Size(1405, 226);
            this.ContractGrid.TabIndex = 2;
            this.ContractGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ContractGrid_CellMouseDoubleClick);
            // 
            // NewContract
            // 
            this.NewContract.Location = new System.Drawing.Point(16, 312);
            this.NewContract.Name = "NewContract";
            this.NewContract.Size = new System.Drawing.Size(179, 44);
            this.NewContract.TabIndex = 3;
            this.NewContract.Text = "New Contract";
            this.NewContract.UseVisualStyleBackColor = true;
            this.NewContract.Click += new System.EventHandler(this.NewContract_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CustomerGrid);
            this.panel1.Location = new System.Drawing.Point(16, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1405, 226);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ContractGrid);
            this.panel2.Location = new System.Drawing.Point(16, 362);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1405, 226);
            this.panel2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(295, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 26);
            this.textBox1.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(645, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 35);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ContractorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1433, 633);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NewContract);
            this.Controls.Add(this.NewContractor);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContractorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contractor & Contract Management ";
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CustomerGrid;
        private System.Windows.Forms.Button NewContractor;
        private System.Windows.Forms.DataGridView ContractGrid;
        private System.Windows.Forms.Button NewContract;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSearch;
    }
}