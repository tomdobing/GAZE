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
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.SearchPolID_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.kryptonDataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonButton1);
            this.groupBox1.Controls.Add(this.SearchPolID_txt);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(588, 63);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365BlackDarkMode;
            this.kryptonButton1.Size = new System.Drawing.Size(130, 25);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButton1.TabIndex = 4;
            this.kryptonButton1.Values.Text = "Search";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // SearchPolID_txt
            // 
            // 
            // 
            // 
            this.SearchPolID_txt.CustomButton.Image = null;
            this.SearchPolID_txt.CustomButton.Location = new System.Drawing.Point(482, 1);
            this.SearchPolID_txt.CustomButton.Name = "";
            this.SearchPolID_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SearchPolID_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SearchPolID_txt.CustomButton.TabIndex = 1;
            this.SearchPolID_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SearchPolID_txt.CustomButton.UseSelectable = true;
            this.SearchPolID_txt.CustomButton.Visible = false;
            this.SearchPolID_txt.Lines = new string[0];
            this.SearchPolID_txt.Location = new System.Drawing.Point(64, 20);
            this.SearchPolID_txt.MaxLength = 32767;
            this.SearchPolID_txt.Name = "SearchPolID_txt";
            this.SearchPolID_txt.PasswordChar = '\0';
            this.SearchPolID_txt.PromptText = "Search By PolicyID";
            this.SearchPolID_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SearchPolID_txt.SelectedText = "";
            this.SearchPolID_txt.SelectionLength = 0;
            this.SearchPolID_txt.SelectionStart = 0;
            this.SearchPolID_txt.ShortcutsEnabled = true;
            this.SearchPolID_txt.Size = new System.Drawing.Size(504, 23);
            this.SearchPolID_txt.TabIndex = 3;
            this.SearchPolID_txt.UseSelectable = true;
            this.SearchPolID_txt.WaterMark = "Search By PolicyID";
            this.SearchPolID_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SearchPolID_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(7, 20);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(51, 19);
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
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 170);
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365DarkGray;
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
            this.ClientSize = new System.Drawing.Size(748, 401);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerSearch";
            this.Text = "CustomerSearch";
            this.Load += new System.EventHandler(this.CustomerSearch_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomerSearch_KeyDown);
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
        private MetroFramework.Controls.MetroTextBox SearchPolID_txt;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
    }
}