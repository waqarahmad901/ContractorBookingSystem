namespace InvoiceEngine
{
    partial class InputForm
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
            this.btnTempalteFile = new System.Windows.Forms.Button();
            this.tbxTemplateFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTempalteFile
            // 
            this.btnTempalteFile.Location = new System.Drawing.Point(394, 37);
            this.btnTempalteFile.Name = "btnTempalteFile";
            this.btnTempalteFile.Size = new System.Drawing.Size(29, 23);
            this.btnTempalteFile.TabIndex = 5;
            this.btnTempalteFile.Text = "...";
            this.btnTempalteFile.UseVisualStyleBackColor = true;
            this.btnTempalteFile.Click += new System.EventHandler(this.btnTempalteFile_Click);
            // 
            // tbxTemplateFile
            // 
            this.tbxTemplateFile.Location = new System.Drawing.Point(129, 39);
            this.tbxTemplateFile.Name = "tbxTemplateFile";
            this.tbxTemplateFile.ReadOnly = true;
            this.tbxTemplateFile.Size = new System.Drawing.Size(259, 20);
            this.tbxTemplateFile.TabIndex = 4;
            this.tbxTemplateFile.Text = "C:\\Users\\basharat.hussain\\Documents\\visual studio 2015\\Projects\\ExcelFormsApplica" +
    "tion2\\ExcelFormsApplication2\\Reports\\Rent_Detail_Template.xlsx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Template File:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGenerate.Location = new System.Drawing.Point(267, 97);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 22);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(348, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 142);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnTempalteFile);
            this.Controls.Add(this.tbxTemplateFile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Input Parameters";
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTempalteFile;
        private System.Windows.Forms.TextBox tbxTemplateFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCancel;
    }
}