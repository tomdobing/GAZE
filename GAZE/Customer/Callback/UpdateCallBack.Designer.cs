namespace GAZE.Customer.Callback
{
    partial class UpdateCallBack
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
            this.CurrCallDate_dtp = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.newcallbck_dtp = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // CurrCallDate_dtp
            // 
            this.CurrCallDate_dtp.CalendarFirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.CurrCallDate_dtp.CalendarShowWeekNumbers = true;
            this.CurrCallDate_dtp.CornerRoundingRadius = -1F;
            this.CurrCallDate_dtp.Location = new System.Drawing.Point(125, 31);
            this.CurrCallDate_dtp.Name = "CurrCallDate_dtp";
            this.CurrCallDate_dtp.Size = new System.Drawing.Size(202, 21);
            this.CurrCallDate_dtp.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 32);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel1.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Current Call Date:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 81);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel2.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "New Call Date:";
            // 
            // newcallbck_dtp
            // 
            this.newcallbck_dtp.CalendarFirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.newcallbck_dtp.CalendarShowWeekNumbers = true;
            this.newcallbck_dtp.CornerRoundingRadius = -1F;
            this.newcallbck_dtp.Location = new System.Drawing.Point(125, 80);
            this.newcallbck_dtp.Name = "newcallbck_dtp";
            this.newcallbck_dtp.Size = new System.Drawing.Size(202, 21);
            this.newcallbck_dtp.TabIndex = 2;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(141, 127);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(114, 25);
            this.kryptonButton1.TabIndex = 4;
            this.kryptonButton1.Values.Text = "Update Callback";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // UpdateCallBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 179);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.newcallbck_dtp);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.CurrCallDate_dtp);
            this.Name = "UpdateCallBack";
            this.Text = "UpdateCallBack";
            this.Load += new System.EventHandler(this.UpdateCallBack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonDateTimePicker CurrCallDate_dtp;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonDateTimePicker newcallbck_dtp;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}