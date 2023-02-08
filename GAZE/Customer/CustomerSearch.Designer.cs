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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SearchNum_txt = new MetroFramework.Controls.MetroTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroButton1);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.SearchNum_txt);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(661, 120);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(108, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Search";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(7, 22);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(150, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Search Contact Number";
            // 
            // SearchNum_txt
            // 
            // 
            // 
            // 
            this.SearchNum_txt.CustomButton.Image = null;
            this.SearchNum_txt.CustomButton.Location = new System.Drawing.Point(140, 1);
            this.SearchNum_txt.CustomButton.Name = "";
            this.SearchNum_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SearchNum_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SearchNum_txt.CustomButton.TabIndex = 1;
            this.SearchNum_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SearchNum_txt.CustomButton.UseSelectable = true;
            this.SearchNum_txt.CustomButton.Visible = false;
            this.SearchNum_txt.Lines = new string[0];
            this.SearchNum_txt.Location = new System.Drawing.Point(177, 19);
            this.SearchNum_txt.MaxLength = 32767;
            this.SearchNum_txt.Name = "SearchNum_txt";
            this.SearchNum_txt.PasswordChar = '\0';
            this.SearchNum_txt.PromptText = "Search for Contact Number";
            this.SearchNum_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SearchNum_txt.SelectedText = "";
            this.SearchNum_txt.SelectionLength = 0;
            this.SearchNum_txt.SelectionStart = 0;
            this.SearchNum_txt.ShortcutsEnabled = true;
            this.SearchNum_txt.Size = new System.Drawing.Size(162, 23);
            this.SearchNum_txt.TabIndex = 0;
            this.SearchNum_txt.UseSelectable = true;
            this.SearchNum_txt.WaterMark = "Search for Contact Number";
            this.SearchNum_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SearchNum_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 197);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomerSearch";
            this.Text = "CustomerSearch";
            this.Load += new System.EventHandler(this.CustomerSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox SearchNum_txt;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}