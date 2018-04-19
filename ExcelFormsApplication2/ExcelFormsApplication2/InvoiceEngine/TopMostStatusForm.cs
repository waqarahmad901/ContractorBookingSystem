using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InvoiceEngine
{
    [Flags]
    enum WS_EX
    {
        TOPMOST = 0x00000008,
    }

    class TopMostStatusForm : Form
    {
        private Label lblBody;
    
        protected override CreateParams CreateParams
        {
            get
            {
                var baseParams = base.CreateParams;
                baseParams.ExStyle |= (int)WS_EX.TOPMOST;
                return baseParams;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public TopMostStatusForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.lblBody = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBody
            // 
            this.lblBody.Location = new System.Drawing.Point(2, 17);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(284, 36);
            this.lblBody.TabIndex = 0;
            this.lblBody.Text = "label1";
            // 
            // TopMostStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(288, 62);
            this.Controls.Add(this.lblBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopMostStatusForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress Status ...";
            this.ResumeLayout(false);

        }

        public string DisplayText
        {
            get { return lblBody.Text; }
            set { lblBody.Text = value; }
        }
    }
}
