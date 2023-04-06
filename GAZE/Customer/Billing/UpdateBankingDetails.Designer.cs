namespace GAZE.Customer.Billing
{
    partial class UpdateBankingDetails
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
            this.CurrAccountNumber_txt = new Krypton.Toolkit.KryptonTextBox();
            this.CurrSortCode_txt = new Krypton.Toolkit.KryptonTextBox();
            this.NewSortcode_txt = new Krypton.Toolkit.KryptonTextBox();
            this.NewAccountNumber_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(31, 41);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007SilverDarkMode;
            this.kryptonLabel1.Size = new System.Drawing.Size(151, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Current Account Number:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(362, 42);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007SilverDarkMode;
            this.kryptonLabel2.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Current SortCode:";
            // 
            // CurrAccountNumber_txt
            // 
            this.CurrAccountNumber_txt.Location = new System.Drawing.Point(31, 67);
            this.CurrAccountNumber_txt.Name = "CurrAccountNumber_txt";
            this.CurrAccountNumber_txt.ReadOnly = true;
            this.CurrAccountNumber_txt.Size = new System.Drawing.Size(241, 23);
            this.CurrAccountNumber_txt.TabIndex = 2;
            // 
            // CurrSortCode_txt
            // 
            this.CurrSortCode_txt.Location = new System.Drawing.Point(362, 68);
            this.CurrSortCode_txt.Name = "CurrSortCode_txt";
            this.CurrSortCode_txt.ReadOnly = true;
            this.CurrSortCode_txt.Size = new System.Drawing.Size(241, 23);
            this.CurrSortCode_txt.TabIndex = 3;
            // 
            // NewSortcode_txt
            // 
            this.NewSortcode_txt.Location = new System.Drawing.Point(362, 146);
            this.NewSortcode_txt.MaxLength = 6;
            this.NewSortcode_txt.Name = "NewSortcode_txt";
            this.NewSortcode_txt.Size = new System.Drawing.Size(241, 23);
            this.NewSortcode_txt.TabIndex = 7;
            this.NewSortcode_txt.TextChanged += new System.EventHandler(this.NewSortcode_txt_TextChanged);
            this.NewSortcode_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewSortcode_txt_KeyPress);
            this.NewSortcode_txt.Leave += new System.EventHandler(this.NewSortcode_txt_Leave);
            // 
            // NewAccountNumber_txt
            // 
            this.NewAccountNumber_txt.Location = new System.Drawing.Point(31, 146);
            this.NewAccountNumber_txt.MaxLength = 8;
            this.NewAccountNumber_txt.Name = "NewAccountNumber_txt";
            this.NewAccountNumber_txt.Size = new System.Drawing.Size(241, 23);
            this.NewAccountNumber_txt.TabIndex = 6;
            this.NewAccountNumber_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewAccountNumber_txt_KeyPress);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(362, 120);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007SilverDarkMode;
            this.kryptonLabel3.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Current SortCode:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(28, 120);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.PaletteMode = Krypton.Toolkit.PaletteMode.Office2007SilverDarkMode;
            this.kryptonLabel4.Size = new System.Drawing.Size(134, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "New Account Number:";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(258, 197);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(120, 25);
            this.kryptonButton1.TabIndex = 8;
            this.kryptonButton1.Values.Text = "Continue";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // UpdateBankingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 245);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.NewSortcode_txt);
            this.Controls.Add(this.NewAccountNumber_txt);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.CurrSortCode_txt);
            this.Controls.Add(this.CurrAccountNumber_txt);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Name = "UpdateBankingDetails";
            this.Text = "UpdateBankingDetails";
            this.Load += new System.EventHandler(this.UpdateBankingDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox CurrAccountNumber_txt;
        private Krypton.Toolkit.KryptonTextBox CurrSortCode_txt;
        private Krypton.Toolkit.KryptonTextBox NewSortcode_txt;
        private Krypton.Toolkit.KryptonTextBox NewAccountNumber_txt;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}