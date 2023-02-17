namespace GAZE.Customer
{
    partial class CustomerUpdateStatus
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.newStatus_cmb = new MetroFramework.Controls.MetroComboBox();
            this.status_lbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.CurrStatus_txt = new MetroFramework.Controls.MetroTextBox();
            this.note_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(12, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(95, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Customer ID:";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // newStatus_cmb
            // 
            this.newStatus_cmb.FormattingEnabled = true;
            this.newStatus_cmb.ItemHeight = 23;
            this.newStatus_cmb.Location = new System.Drawing.Point(144, 110);
            this.newStatus_cmb.Name = "newStatus_cmb";
            this.newStatus_cmb.Size = new System.Drawing.Size(375, 29);
            this.newStatus_cmb.TabIndex = 1;
            this.newStatus_cmb.UseSelectable = true;
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.status_lbl.Location = new System.Drawing.Point(36, 110);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(53, 19);
            this.status_lbl.TabIndex = 2;
            this.status_lbl.Text = "Status:";
            this.status_lbl.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(4, 57);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(103, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Current Status";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(247, 300);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(134, 38);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Update Status";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // CurrStatus_txt
            // 
            // 
            // 
            // 
            this.CurrStatus_txt.CustomButton.Image = null;
            this.CurrStatus_txt.CustomButton.Location = new System.Drawing.Point(353, 1);
            this.CurrStatus_txt.CustomButton.Name = "";
            this.CurrStatus_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CurrStatus_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CurrStatus_txt.CustomButton.TabIndex = 1;
            this.CurrStatus_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CurrStatus_txt.CustomButton.UseSelectable = true;
            this.CurrStatus_txt.CustomButton.Visible = false;
            this.CurrStatus_txt.Lines = new string[0];
            this.CurrStatus_txt.Location = new System.Drawing.Point(144, 53);
            this.CurrStatus_txt.MaxLength = 32767;
            this.CurrStatus_txt.Name = "CurrStatus_txt";
            this.CurrStatus_txt.PasswordChar = '\0';
            this.CurrStatus_txt.PromptText = "Current Status";
            this.CurrStatus_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CurrStatus_txt.SelectedText = "";
            this.CurrStatus_txt.SelectionLength = 0;
            this.CurrStatus_txt.SelectionStart = 0;
            this.CurrStatus_txt.ShortcutsEnabled = true;
            this.CurrStatus_txt.Size = new System.Drawing.Size(375, 23);
            this.CurrStatus_txt.TabIndex = 6;
            this.CurrStatus_txt.UseSelectable = true;
            this.CurrStatus_txt.WaterMark = "Current Status";
            this.CurrStatus_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CurrStatus_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // note_txt
            // 
            // 
            // 
            // 
            this.note_txt.CustomButton.Image = null;
            this.note_txt.CustomButton.Location = new System.Drawing.Point(243, 2);
            this.note_txt.CustomButton.Name = "";
            this.note_txt.CustomButton.Size = new System.Drawing.Size(129, 129);
            this.note_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.note_txt.CustomButton.TabIndex = 1;
            this.note_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.note_txt.CustomButton.UseSelectable = true;
            this.note_txt.CustomButton.Visible = false;
            this.note_txt.Lines = new string[0];
            this.note_txt.Location = new System.Drawing.Point(144, 160);
            this.note_txt.MaxLength = 32767;
            this.note_txt.Multiline = true;
            this.note_txt.Name = "note_txt";
            this.note_txt.PasswordChar = '\0';
            this.note_txt.PromptText = "Please enter a note";
            this.note_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.note_txt.SelectedText = "";
            this.note_txt.SelectionLength = 0;
            this.note_txt.SelectionStart = 0;
            this.note_txt.ShortcutsEnabled = true;
            this.note_txt.Size = new System.Drawing.Size(375, 134);
            this.note_txt.TabIndex = 7;
            this.note_txt.UseSelectable = true;
            this.note_txt.WaterMark = "Please enter a note";
            this.note_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.note_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(4, 160);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(134, 43);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Reason for Status\r\nChange";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // CustomerUpdateStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(531, 350);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.note_txt);
            this.Controls.Add(this.CurrStatus_txt);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.newStatus_cmb);
            this.Controls.Add(this.metroLabel1);
            this.Name = "CustomerUpdateStatus";
            this.Text = "Customer Update Status";
            this.Load += new System.EventHandler(this.CustomerUpdateStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox newStatus_cmb;
        private MetroFramework.Controls.MetroLabel status_lbl;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox CurrStatus_txt;
        private MetroFramework.Controls.MetroTextBox note_txt;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}