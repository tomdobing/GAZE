namespace GAZE.Customer.Tasks
{
    partial class _currentWindow
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
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.custid_txt = new Krypton.Toolkit.KryptonTextBox();
            this.tsktye_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.tskdesc_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.tskdtls_txt = new Krypton.Toolkit.Suite.Extended.Controls.KryptonRichTextBoxExtended();
            this.kryptonDateTimePicker1 = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.tskPrio_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.CrtTsk_btn = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.tsktye_cmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tskPrio_cmb)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 44);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel1.Size = new System.Drawing.Size(109, 25);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Customer ID:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(317, 43);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel2.Size = new System.Drawing.Size(93, 25);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Task Type:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 140);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel3.Size = new System.Drawing.Size(139, 25);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Task Description:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 240);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel4.Size = new System.Drawing.Size(107, 25);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Task Details:";
            // 
            // custid_txt
            // 
            this.custid_txt.Location = new System.Drawing.Point(13, 75);
            this.custid_txt.Name = "custid_txt";
            this.custid_txt.ReadOnly = true;
            this.custid_txt.Size = new System.Drawing.Size(276, 31);
            this.custid_txt.TabIndex = 4;
            // 
            // tsktye_cmb
            // 
            this.tsktye_cmb.CornerRoundingRadius = -1F;
            this.tsktye_cmb.DropDownWidth = 388;
            this.tsktye_cmb.IntegralHeight = false;
            this.tsktye_cmb.Location = new System.Drawing.Point(317, 75);
            this.tsktye_cmb.Name = "tsktye_cmb";
            this.tsktye_cmb.Size = new System.Drawing.Size(388, 29);
            this.tsktye_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tsktye_cmb.TabIndex = 5;
            this.tsktye_cmb.SelectedIndexChanged += new System.EventHandler(this.tsktye_cmb_SelectedIndexChanged);
            // 
            // tskdesc_txt
            // 
            this.tskdesc_txt.CueHint.CueHintText = "Task Description - A brief overview of the task";
            this.tskdesc_txt.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tskdesc_txt.Location = new System.Drawing.Point(13, 182);
            this.tskdesc_txt.Name = "tskdesc_txt";
            this.tskdesc_txt.Size = new System.Drawing.Size(964, 31);
            this.tskdesc_txt.TabIndex = 6;
            this.tskdesc_txt.TextChanged += new System.EventHandler(this.tskdesc_txt_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(989, 140);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel5.Size = new System.Drawing.Size(126, 25);
            this.kryptonLabel5.TabIndex = 9;
            this.kryptonLabel5.Values.Text = "Task Due Date:";
            // 
            // tskdtls_txt
            // 
            this.tskdtls_txt.CueHint.CueHintText = "Task Detail - Detailed description of the task";
            this.tskdtls_txt.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tskdtls_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tskdtls_txt.Location = new System.Drawing.Point(12, 271);
            this.tskdtls_txt.Multiline = true;
            this.tskdtls_txt.Name = "tskdtls_txt";
            this.tskdtls_txt.Size = new System.Drawing.Size(965, 351);
            this.tskdtls_txt.StateCommon.Content.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tskdtls_txt.TabIndex = 10;
            this.tskdtls_txt.TextChanged += new System.EventHandler(this.kryptonRichTextBoxExtended1_TextChanged);
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.CalendarShowWeekNumbers = true;
            this.kryptonDateTimePicker1.CalendarTodayDate = new System.DateTime(2023, 5, 30, 0, 0, 0, 0);
            this.kryptonDateTimePicker1.CornerRoundingRadius = -1F;
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(1006, 182);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(384, 30);
            this.kryptonDateTimePicker1.TabIndex = 11;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(727, 43);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.PaletteMode = Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.kryptonLabel6.Size = new System.Drawing.Size(108, 25);
            this.kryptonLabel6.TabIndex = 12;
            this.kryptonLabel6.Values.Text = "Task Priority:";
            // 
            // tskPrio_cmb
            // 
            this.tskPrio_cmb.CornerRoundingRadius = -1F;
            this.tskPrio_cmb.DropDownWidth = 388;
            this.tskPrio_cmb.IntegralHeight = false;
            this.tskPrio_cmb.Location = new System.Drawing.Point(727, 75);
            this.tskPrio_cmb.Name = "tskPrio_cmb";
            this.tskPrio_cmb.Size = new System.Drawing.Size(388, 29);
            this.tskPrio_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tskPrio_cmb.TabIndex = 13;
            // 
            // CrtTsk_btn
            // 
            this.CrtTsk_btn.CornerRoundingRadius = -1F;
            this.CrtTsk_btn.Location = new System.Drawing.Point(1023, 271);
            this.CrtTsk_btn.Name = "CrtTsk_btn";
            this.CrtTsk_btn.Size = new System.Drawing.Size(161, 52);
            this.CrtTsk_btn.TabIndex = 14;
            this.CrtTsk_btn.Values.Text = "&Create Task";
            this.CrtTsk_btn.Click += new System.EventHandler(this.CrtTsk_btn_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(1023, 349);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(161, 52);
            this.kryptonButton1.TabIndex = 15;
            this.kryptonButton1.Values.Text = "&Reset";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // _currentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1650, 692);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.CrtTsk_btn);
            this.Controls.Add(this.tskPrio_cmb);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(this.tskdtls_txt);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.tskdesc_txt);
            this.Controls.Add(this.tsktye_cmb);
            this.Controls.Add(this.custid_txt);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "_currentWindow";
            this.Text = "CreateNewTask";
            this.Load += new System.EventHandler(this.CreateNewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tsktye_cmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tskPrio_cmb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox custid_txt;
        private Krypton.Toolkit.KryptonComboBox tsktye_cmb;
        private Krypton.Toolkit.KryptonTextBox tskdesc_txt;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonRichTextBoxExtended tskdtls_txt;
        private Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonComboBox tskPrio_cmb;
        private Krypton.Toolkit.KryptonButton CrtTsk_btn;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}