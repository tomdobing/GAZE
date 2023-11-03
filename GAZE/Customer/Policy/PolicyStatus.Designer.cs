namespace GAZE.Customer.Policy
{
    partial class PolicyStatus
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
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.newPolStat_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.CurrPolStatus_txt = new Krypton.Toolkit.KryptonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonHeader1 = new Krypton.Toolkit.KryptonHeader();
            this.policyIDtxt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.newPolStat_cmb)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel1.Size = new System.Drawing.Size(97, 18);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Current Status :";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 64);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel2.Size = new System.Drawing.Size(109, 18);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Change Status to:";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(340, 219);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(84, 24);
            this.kryptonButton1.TabIndex = 2;
            this.kryptonButton1.Values.Text = "&Cancel";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // newPolStat_cmb
            // 
            this.newPolStat_cmb.CornerRoundingRadius = -1F;
            this.newPolStat_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newPolStat_cmb.DropDownWidth = 365;
            this.newPolStat_cmb.IntegralHeight = false;
            this.newPolStat_cmb.Location = new System.Drawing.Point(131, 64);
            this.newPolStat_cmb.Name = "newPolStat_cmb";
            this.newPolStat_cmb.Size = new System.Drawing.Size(272, 21);
            this.newPolStat_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.newPolStat_cmb.TabIndex = 4;
            this.newPolStat_cmb.SelectedIndexChanged += new System.EventHandler(this.newPolStat_cmb_SelectedIndexChanged);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(244, 219);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(84, 24);
            this.kryptonButton2.TabIndex = 5;
            this.kryptonButton2.Values.Text = "&Ok";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // CurrPolStatus_txt
            // 
            this.CurrPolStatus_txt.Location = new System.Drawing.Point(131, 19);
            this.CurrPolStatus_txt.Name = "CurrPolStatus_txt";
            this.CurrPolStatus_txt.ReadOnly = true;
            this.CurrPolStatus_txt.Size = new System.Drawing.Size(272, 23);
            this.CurrPolStatus_txt.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Controls.Add(this.policyIDtxt);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Policy Details";
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(436, 31);
            this.kryptonHeader1.TabIndex = 7;
            this.kryptonHeader1.Values.Description = "Set new Policy status";
            this.kryptonHeader1.Values.Heading = "Change Policy Status";
            // 
            // policyIDtxt
            // 
            this.policyIDtxt.Location = new System.Drawing.Point(131, 21);
            this.policyIDtxt.Name = "policyIDtxt";
            this.policyIDtxt.ReadOnly = true;
            this.policyIDtxt.Size = new System.Drawing.Size(272, 23);
            this.policyIDtxt.TabIndex = 0;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 24);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "Policy ID :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CurrPolStatus_txt);
            this.groupBox2.Controls.Add(this.kryptonLabel1);
            this.groupBox2.Controls.Add(this.kryptonLabel2);
            this.groupBox2.Controls.Add(this.newPolStat_cmb);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 108);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Status";
            // 
            // PolicyStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BlurValues.Opacity = ((byte)(100));
            this.ClientSize = new System.Drawing.Size(436, 252);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Name = "PolicyStatus";
            this.Text = "PolicyStatus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PolicyStatus_FormClosing);
            this.Load += new System.EventHandler(this.PolicyStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newPolStat_cmb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonComboBox newPolStat_cmb;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonTextBox CurrPolStatus_txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox policyIDtxt;
        private Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}