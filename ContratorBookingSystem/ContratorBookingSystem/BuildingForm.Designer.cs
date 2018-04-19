namespace ContratorBookingSystem
{
    partial class BuildingForm
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
            this.BuildingGrid = new System.Windows.Forms.DataGridView();
            this.NewBuilding = new System.Windows.Forms.Button();
            this.spaceUnitGrid = new System.Windows.Forms.DataGridView();
            this.addSpaceUnit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelSpaceUnit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceUnitGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildingGrid
            // 
            this.BuildingGrid.AllowUserToAddRows = false;
            this.BuildingGrid.BackgroundColor = System.Drawing.Color.Moccasin;
            this.BuildingGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BuildingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuildingGrid.Location = new System.Drawing.Point(0, 0);
            this.BuildingGrid.MultiSelect = false;
            this.BuildingGrid.Name = "BuildingGrid";
            this.BuildingGrid.ReadOnly = true;
            this.BuildingGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BuildingGrid.RowTemplate.Height = 28;
            this.BuildingGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BuildingGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BuildingGrid.Size = new System.Drawing.Size(1089, 305);
            this.BuildingGrid.TabIndex = 0;
            this.BuildingGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BuildingGrid_CellMouseDoubleClick);
            this.BuildingGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BuildingGrid_ColumnHeaderMouseClick);
            this.BuildingGrid.SelectionChanged += new System.EventHandler(this.BuildingGrid_SelectionChanged);
            // 
            // NewBuilding
            // 
            this.NewBuilding.Location = new System.Drawing.Point(16, 31);
            this.NewBuilding.Name = "NewBuilding";
            this.NewBuilding.Size = new System.Drawing.Size(179, 44);
            this.NewBuilding.TabIndex = 1;
            this.NewBuilding.Text = "New Building";
            this.NewBuilding.UseVisualStyleBackColor = true;
            this.NewBuilding.Click += new System.EventHandler(this.NewBuilding_Click);
            // 
            // spaceUnitGrid
            // 
            this.spaceUnitGrid.AllowUserToAddRows = false;
            this.spaceUnitGrid.BackgroundColor = System.Drawing.Color.Moccasin;
            this.spaceUnitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spaceUnitGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spaceUnitGrid.Location = new System.Drawing.Point(0, 0);
            this.spaceUnitGrid.MultiSelect = false;
            this.spaceUnitGrid.Name = "spaceUnitGrid";
            this.spaceUnitGrid.ReadOnly = true;
            this.spaceUnitGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spaceUnitGrid.RowTemplate.Height = 28;
            this.spaceUnitGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.spaceUnitGrid.Size = new System.Drawing.Size(1089, 305);
            this.spaceUnitGrid.TabIndex = 2;
            this.spaceUnitGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.spaceUnitGrid_CellMouseDoubleClick);
            // 
            // addSpaceUnit
            // 
            this.addSpaceUnit.Location = new System.Drawing.Point(16, 405);
            this.addSpaceUnit.Name = "addSpaceUnit";
            this.addSpaceUnit.Size = new System.Drawing.Size(179, 44);
            this.addSpaceUnit.TabIndex = 3;
            this.addSpaceUnit.Text = "New Space Unit";
            this.addSpaceUnit.UseVisualStyleBackColor = true;
            this.addSpaceUnit.Click += new System.EventHandler(this.addSpaceUnit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BuildingGrid);
            this.panel1.Location = new System.Drawing.Point(16, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 305);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.spaceUnitGrid);
            this.panel2.Location = new System.Drawing.Point(16, 458);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1089, 305);
            this.panel2.TabIndex = 5;
            // 
            // btnDelSpaceUnit
            // 
            this.btnDelSpaceUnit.Location = new System.Drawing.Point(224, 405);
            this.btnDelSpaceUnit.Name = "btnDelSpaceUnit";
            this.btnDelSpaceUnit.Size = new System.Drawing.Size(179, 44);
            this.btnDelSpaceUnit.TabIndex = 6;
            this.btnDelSpaceUnit.Text = "Delete Space Unit";
            this.btnDelSpaceUnit.UseVisualStyleBackColor = true;
            this.btnDelSpaceUnit.Click += new System.EventHandler(this.btnDelSpaceUnit_Click);
            // 
            // BuildingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1117, 775);
            this.Controls.Add(this.btnDelSpaceUnit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addSpaceUnit);
            this.Controls.Add(this.NewBuilding);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Building & Space Unit Management ";
            this.Load += new System.EventHandler(this.BuildingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BuildingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spaceUnitGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BuildingGrid;
        private System.Windows.Forms.Button NewBuilding;
        private System.Windows.Forms.DataGridView spaceUnitGrid;
        private System.Windows.Forms.Button addSpaceUnit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelSpaceUnit;
    }
}