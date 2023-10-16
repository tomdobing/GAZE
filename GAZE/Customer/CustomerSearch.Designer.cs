namespace GAZE.Customer
{
    partial class CustomerSearch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.custID_chk = new Krypton.Toolkit.KryptonCheckBox();
            this.polID_chkbx = new Krypton.Toolkit.KryptonCheckBox();
            this.custIDSrch_txt = new Krypton.Toolkit.KryptonTextBox();
            this.searchPolID_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.kryptonDataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.custID_chk);
            this.groupBox1.Controls.Add(this.polID_chkbx);
            this.groupBox1.Controls.Add(this.custIDSrch_txt);
            this.groupBox1.Controls.Add(this.searchPolID_txt);
            this.groupBox1.Controls.Add(this.kryptonButton1);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // custID_chk
            // 
            this.custID_chk.Location = new System.Drawing.Point(7, 95);
            this.custID_chk.Name = "custID_chk";
            this.custID_chk.Size = new System.Drawing.Size(133, 16);
            this.custID_chk.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custID_chk.TabIndex = 8;
            this.custID_chk.Values.Text = "Customer ID Search:";
            this.custID_chk.CheckedChanged += new System.EventHandler(this.custID_chk_CheckedChanged);
            this.custID_chk.CheckStateChanged += new System.EventHandler(this.custID_chk_CheckStateChanged);
            // 
            // polID_chkbx
            // 
            this.polID_chkbx.Location = new System.Drawing.Point(7, 55);
            this.polID_chkbx.Name = "polID_chkbx";
            this.polID_chkbx.Size = new System.Drawing.Size(110, 16);
            this.polID_chkbx.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.polID_chkbx.TabIndex = 7;
            this.polID_chkbx.Values.Text = "PolicyID Search:";
            this.polID_chkbx.CheckedChanged += new System.EventHandler(this.polID_chkbx_CheckedChanged);
            this.polID_chkbx.CheckStateChanged += new System.EventHandler(this.polID_chkbx_CheckStateChanged);
            // 
            // custIDSrch_txt
            // 
            this.custIDSrch_txt.CueHint.Color1 = System.Drawing.Color.Black;
            this.custIDSrch_txt.CueHint.CueHintText = "Search By CustomerID";
            this.custIDSrch_txt.CueHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custIDSrch_txt.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.custIDSrch_txt.Location = new System.Drawing.Point(165, 91);
            this.custIDSrch_txt.Name = "custIDSrch_txt";
            this.custIDSrch_txt.Size = new System.Drawing.Size(504, 20);
            this.custIDSrch_txt.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custIDSrch_txt.TabIndex = 6;
            this.custIDSrch_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.custIDSrch_txt_KeyPress);
            // 
            // searchPolID_txt
            // 
            this.searchPolID_txt.CueHint.Color1 = System.Drawing.Color.Black;
            this.searchPolID_txt.CueHint.CueHintText = "Search By PolicyID";
            this.searchPolID_txt.CueHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPolID_txt.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.searchPolID_txt.Location = new System.Drawing.Point(165, 51);
            this.searchPolID_txt.Name = "searchPolID_txt";
            this.searchPolID_txt.Size = new System.Drawing.Size(504, 20);
            this.searchPolID_txt.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPolID_txt.TabIndex = 5;
            this.searchPolID_txt.TextChanged += new System.EventHandler(this.searchPolID_txt_TextChanged);
            this.searchPolID_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchPolID_txt_KeyPress);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(588, 117);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(130, 25);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButton1.TabIndex = 4;
            this.kryptonButton1.Values.Text = "Search";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(7, 20);
          //this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(58, 19);
            this.metroLabel3.TabIndex = 1;
            this.metroLabel3.Text = "Search:";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(12, 5);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(81, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "CustomerID:";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 190);
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(748, 231);
            this.kryptonDataGridView1.TabIndex = 3;
            this.kryptonDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellDoubleClick);
            // 
            // CustomerSearch
            // 
            this.AcceptButton = this.kryptonButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(748, 421);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerSearch";
            this.Text = "CustomerSearch";
            this.Load += new System.EventHandler(this.CustomerSearch_Load_1);
          //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerSearch_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private Krypton.Toolkit.KryptonTextBox searchPolID_txt;
        private Krypton.Toolkit.KryptonCheckBox polID_chkbx;
        private Krypton.Toolkit.KryptonTextBox custIDSrch_txt;
        private Krypton.Toolkit.KryptonCheckBox custID_chk;
    }
}