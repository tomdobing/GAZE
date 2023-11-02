namespace GAZE.Customer.Policy
{
    partial class PolicyRedirect
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
            this.kryptonHeader1 = new Krypton.Toolkit.KryptonHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.message_txt = new Krypton.Toolkit.KryptonTextBox();
            this.no_chk = new Krypton.Toolkit.KryptonCheckBox();
            this.yes_chk = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.department_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.polID_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.department_cmb)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(435, 31);
            this.kryptonHeader1.TabIndex = 0;
            this.kryptonHeader1.Values.Description = "Policy ReDirection Updates";
            this.kryptonHeader1.Values.Heading = "Policy ReDirect";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.message_txt);
            this.groupBox1.Controls.Add(this.no_chk);
            this.groupBox1.Controls.Add(this.yes_chk);
            this.groupBox1.Controls.Add(this.kryptonLabel4);
            this.groupBox1.Controls.Add(this.kryptonLabel3);
            this.groupBox1.Controls.Add(this.department_cmb);
            this.groupBox1.Controls.Add(this.kryptonLabel2);
            this.groupBox1.Controls.Add(this.kryptonLabel1);
            this.groupBox1.Controls.Add(this.polID_txt);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // message_txt
            // 
            this.message_txt.Location = new System.Drawing.Point(140, 83);
            this.message_txt.MaxLength = 255;
            this.message_txt.Multiline = true;
            this.message_txt.Name = "message_txt";
            this.message_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.message_txt.Size = new System.Drawing.Size(252, 55);
            this.message_txt.TabIndex = 8;
            // 
            // no_chk
            // 
            this.no_chk.Location = new System.Drawing.Point(215, 144);
            this.no_chk.Name = "no_chk";
            this.no_chk.Size = new System.Drawing.Size(40, 20);
            this.no_chk.TabIndex = 7;
            this.no_chk.Values.Text = "No";
            // 
            // yes_chk
            // 
            this.yes_chk.Location = new System.Drawing.Point(140, 144);
            this.yes_chk.Name = "yes_chk";
            this.yes_chk.Size = new System.Drawing.Size(42, 20);
            this.yes_chk.TabIndex = 6;
            this.yes_chk.Values.Text = "Yes";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 144);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "ReDirect:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 95);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Message:";
            // 
            // department_cmb
            // 
            this.department_cmb.CornerRoundingRadius = -1F;
            this.department_cmb.DropDownWidth = 252;
            this.department_cmb.IntegralHeight = false;
            this.department_cmb.Location = new System.Drawing.Point(140, 59);
            this.department_cmb.Name = "department_cmb";
            this.department_cmb.Size = new System.Drawing.Size(252, 18);
            this.department_cmb.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.department_cmb.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 59);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(79, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Department:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 22);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Policy ID:";
            // 
            // polID_txt
            // 
            this.polID_txt.Location = new System.Drawing.Point(140, 22);
            this.polID_txt.Name = "polID_txt";
            this.polID_txt.ReadOnly = true;
            this.polID_txt.Size = new System.Drawing.Size(252, 20);
            this.polID_txt.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.polID_txt.TabIndex = 0;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(242, 228);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(84, 24);
            this.kryptonButton1.TabIndex = 2;
            this.kryptonButton1.Values.Text = "&Ok";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(333, 228);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(84, 24);
            this.kryptonButton2.TabIndex = 3;
            this.kryptonButton2.Values.Text = "&Cancel";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // PolicyRedirect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 256);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kryptonHeader1);
            this.Name = "PolicyRedirect";
            this.Text = "PolicyRedirect";
            this.Load += new System.EventHandler(this.PolicyRedirect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.department_cmb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Krypton.Toolkit.KryptonComboBox department_cmb;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox polID_txt;
        private Krypton.Toolkit.KryptonTextBox message_txt;
        private Krypton.Toolkit.KryptonCheckBox no_chk;
        private Krypton.Toolkit.KryptonCheckBox yes_chk;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}