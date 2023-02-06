namespace GAZE.Admin
{
    partial class AdminConfig
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ConfigID_txt = new MetroFramework.Controls.MetroTextBox();
            this.ConfigName_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ConfigValue_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ChangeBit_cmb = new MetroFramework.Controls.MetroCheckBox();
            this.AddedBy_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 264);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(148, 23);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "ConfigID";
            // 
            // ConfigID_txt
            // 
            // 
            // 
            // 
            this.ConfigID_txt.CustomButton.Image = null;
            this.ConfigID_txt.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.ConfigID_txt.CustomButton.Name = "";
            this.ConfigID_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ConfigID_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ConfigID_txt.CustomButton.TabIndex = 1;
            this.ConfigID_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ConfigID_txt.CustomButton.UseSelectable = true;
            this.ConfigID_txt.CustomButton.Visible = false;
            this.ConfigID_txt.Lines = new string[0];
            this.ConfigID_txt.Location = new System.Drawing.Point(215, 23);
            this.ConfigID_txt.MaxLength = 32767;
            this.ConfigID_txt.Name = "ConfigID_txt";
            this.ConfigID_txt.PasswordChar = '\0';
            this.ConfigID_txt.PromptText = "Config ID";
            this.ConfigID_txt.ReadOnly = true;
            this.ConfigID_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConfigID_txt.SelectedText = "";
            this.ConfigID_txt.SelectionLength = 0;
            this.ConfigID_txt.SelectionStart = 0;
            this.ConfigID_txt.ShortcutsEnabled = true;
            this.ConfigID_txt.Size = new System.Drawing.Size(139, 23);
            this.ConfigID_txt.TabIndex = 2;
            this.ConfigID_txt.UseSelectable = true;
            this.ConfigID_txt.WaterMark = "Config ID";
            this.ConfigID_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ConfigID_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ConfigName_txt
            // 
            // 
            // 
            // 
            this.ConfigName_txt.CustomButton.Image = null;
            this.ConfigName_txt.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.ConfigName_txt.CustomButton.Name = "";
            this.ConfigName_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ConfigName_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ConfigName_txt.CustomButton.TabIndex = 1;
            this.ConfigName_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ConfigName_txt.CustomButton.UseSelectable = true;
            this.ConfigName_txt.CustomButton.Visible = false;
            this.ConfigName_txt.Lines = new string[0];
            this.ConfigName_txt.Location = new System.Drawing.Point(215, 64);
            this.ConfigName_txt.MaxLength = 32767;
            this.ConfigName_txt.Name = "ConfigName_txt";
            this.ConfigName_txt.PasswordChar = '\0';
            this.ConfigName_txt.PromptText = "Config Name";
            this.ConfigName_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConfigName_txt.SelectedText = "";
            this.ConfigName_txt.SelectionLength = 0;
            this.ConfigName_txt.SelectionStart = 0;
            this.ConfigName_txt.ShortcutsEnabled = true;
            this.ConfigName_txt.Size = new System.Drawing.Size(139, 23);
            this.ConfigName_txt.TabIndex = 4;
            this.ConfigName_txt.UseSelectable = true;
            this.ConfigName_txt.WaterMark = "Config Name";
            this.ConfigName_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ConfigName_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(148, 64);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Name";
            // 
            // ConfigValue_txt
            // 
            // 
            // 
            // 
            this.ConfigValue_txt.CustomButton.Image = null;
            this.ConfigValue_txt.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.ConfigValue_txt.CustomButton.Name = "";
            this.ConfigValue_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ConfigValue_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ConfigValue_txt.CustomButton.TabIndex = 1;
            this.ConfigValue_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ConfigValue_txt.CustomButton.UseSelectable = true;
            this.ConfigValue_txt.CustomButton.Visible = false;
            this.ConfigValue_txt.Lines = new string[0];
            this.ConfigValue_txt.Location = new System.Drawing.Point(215, 109);
            this.ConfigValue_txt.MaxLength = 32767;
            this.ConfigValue_txt.Name = "ConfigValue_txt";
            this.ConfigValue_txt.PasswordChar = '\0';
            this.ConfigValue_txt.PromptText = "Config Value";
            this.ConfigValue_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConfigValue_txt.SelectedText = "";
            this.ConfigValue_txt.SelectionLength = 0;
            this.ConfigValue_txt.SelectionStart = 0;
            this.ConfigValue_txt.ShortcutsEnabled = true;
            this.ConfigValue_txt.Size = new System.Drawing.Size(139, 23);
            this.ConfigValue_txt.TabIndex = 6;
            this.ConfigValue_txt.UseSelectable = true;
            this.ConfigValue_txt.WaterMark = "Config Value";
            this.ConfigValue_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ConfigValue_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(148, 109);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(39, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Value";
            // 
            // ChangeBit_cmb
            // 
            this.ChangeBit_cmb.AutoSize = true;
            this.ChangeBit_cmb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChangeBit_cmb.Location = new System.Drawing.Point(148, 154);
            this.ChangeBit_cmb.Name = "ChangeBit_cmb";
            this.ChangeBit_cmb.Size = new System.Drawing.Size(86, 15);
            this.ChangeBit_cmb.TabIndex = 7;
            this.ChangeBit_cmb.Text = "Changeable";
            this.ChangeBit_cmb.UseSelectable = true;
            // 
            // AddedBy_txt
            // 
            // 
            // 
            // 
            this.AddedBy_txt.CustomButton.Image = null;
            this.AddedBy_txt.CustomButton.Location = new System.Drawing.Point(117, 1);
            this.AddedBy_txt.CustomButton.Name = "";
            this.AddedBy_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.AddedBy_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AddedBy_txt.CustomButton.TabIndex = 1;
            this.AddedBy_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AddedBy_txt.CustomButton.UseSelectable = true;
            this.AddedBy_txt.CustomButton.Visible = false;
            this.AddedBy_txt.Lines = new string[0];
            this.AddedBy_txt.Location = new System.Drawing.Point(215, 188);
            this.AddedBy_txt.MaxLength = 32767;
            this.AddedBy_txt.Name = "AddedBy_txt";
            this.AddedBy_txt.PasswordChar = '\0';
            this.AddedBy_txt.PromptText = "Added By";
            this.AddedBy_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AddedBy_txt.SelectedText = "";
            this.AddedBy_txt.SelectionLength = 0;
            this.AddedBy_txt.SelectionStart = 0;
            this.AddedBy_txt.ShortcutsEnabled = true;
            this.AddedBy_txt.Size = new System.Drawing.Size(139, 23);
            this.AddedBy_txt.TabIndex = 9;
            this.AddedBy_txt.UseSelectable = true;
            this.AddedBy_txt.WaterMark = "Added By";
            this.AddedBy_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AddedBy_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(148, 188);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(67, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Added By";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 296);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddedBy_txt);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.ChangeBit_cmb);
            this.Controls.Add(this.ConfigValue_txt);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.ConfigName_txt);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.ConfigID_txt);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.listBox1);
            this.Name = "AdminConfig";
            this.Text = "AdminConfig";
            this.Load += new System.EventHandler(this.AdminConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox ConfigID_txt;
        private MetroFramework.Controls.MetroTextBox ConfigName_txt;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox ConfigValue_txt;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox ChangeBit_cmb;
        private MetroFramework.Controls.MetroTextBox AddedBy_txt;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}