namespace GAZE.Customer.Callback
{
    partial class RequestCallback
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
            this.CustName_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.CallbackDate_dtp = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.callbckdet_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.agent_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // CustName_txt
            // 
            this.CustName_txt.Location = new System.Drawing.Point(125, 26);
            this.CustName_txt.Name = "CustName_txt";
            this.CustName_txt.ReadOnly = true;
            this.CustName_txt.Size = new System.Drawing.Size(286, 23);
            this.CustName_txt.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 26);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel1.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Customer:";
            // 
            // CallbackDate_dtp
            // 
            this.CallbackDate_dtp.CalendarCloseOnTodayClick = true;
            this.CallbackDate_dtp.CalendarFirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.CallbackDate_dtp.CalendarShowWeekNumbers = true;
            this.CallbackDate_dtp.CornerRoundingRadius = -1F;
            this.CallbackDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CallbackDate_dtp.Location = new System.Drawing.Point(123, 123);
            this.CallbackDate_dtp.Name = "CallbackDate_dtp";
            this.CallbackDate_dtp.Size = new System.Drawing.Size(220, 21);
            this.CallbackDate_dtp.TabIndex = 6;
            this.CallbackDate_dtp.ValueNullable = new System.DateTime(2023, 4, 17, 11, 14, 0, 0);
            this.CallbackDate_dtp.Leave += new System.EventHandler(this.CallbackDate_dtp_Leave);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 123);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel2.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Callback Date:";
            // 
            // callbckdet_txt
            // 
            this.callbckdet_txt.Location = new System.Drawing.Point(123, 167);
            this.callbckdet_txt.Multiline = true;
            this.callbckdet_txt.Name = "callbckdet_txt";
            this.callbckdet_txt.Size = new System.Drawing.Size(521, 171);
            this.callbckdet_txt.TabIndex = 8;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 167);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel3.Size = new System.Drawing.Size(99, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Callback Details:";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(531, 344);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(113, 25);
            this.kryptonButton1.TabIndex = 9;
            this.kryptonButton1.Values.Text = "Request Callback";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // agent_txt
            // 
            this.agent_txt.Location = new System.Drawing.Point(125, 75);
            this.agent_txt.Name = "agent_txt";
            this.agent_txt.ReadOnly = true;
            this.agent_txt.Size = new System.Drawing.Size(286, 23);
            this.agent_txt.TabIndex = 4;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(11, 75);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonLabel4.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Agent:";
            // 
            // RequestCallback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 383);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.agent_txt);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.callbckdet_txt);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.CallbackDate_dtp);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.CustName_txt);
            this.Name = "RequestCallback";
            this.Text = "RequestCallback";
            this.Load += new System.EventHandler(this.RequestCallback_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox CustName_txt;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonDateTimePicker CallbackDate_dtp;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox callbckdet_txt;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonTextBox agent_txt;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}