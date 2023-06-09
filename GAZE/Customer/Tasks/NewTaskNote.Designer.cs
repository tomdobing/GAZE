namespace GAZE.Customer.Tasks
{
    partial class NewTaskNote
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
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.noteDes_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.noteDetails_rtb = new Krypton.Toolkit.Suite.Extended.Controls.KryptonRichTextBoxExtended();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.addNote_btn = new Krypton.Toolkit.KryptonButton();
            this.reset_btn = new Krypton.Toolkit.KryptonButton();
            this.remChar_lbl = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionOverlap = 0D;
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonButton1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.remChar_lbl);
            this.kryptonGroupBox1.Panel.Controls.Add(this.reset_btn);
            this.kryptonGroupBox1.Panel.Controls.Add(this.addNote_btn);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.noteDetails_rtb);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.noteDes_txt);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(800, 411);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Add New Note";
            // 
            // noteDes_txt
            // 
            this.noteDes_txt.Location = new System.Drawing.Point(168, 37);
            this.noteDes_txt.Name = "noteDes_txt";
            this.noteDes_txt.Size = new System.Drawing.Size(618, 20);
            this.noteDes_txt.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteDes_txt.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(11, 37);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Note Description";
            // 
            // noteDetails_rtb
            // 
            this.noteDetails_rtb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteDetails_rtb.Location = new System.Drawing.Point(168, 87);
            this.noteDetails_rtb.Multiline = true;
            this.noteDetails_rtb.Name = "noteDetails_rtb";
            this.noteDetails_rtb.Size = new System.Drawing.Size(618, 248);
            this.noteDetails_rtb.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteDetails_rtb.TabIndex = 2;
            this.noteDetails_rtb.TextChanged += new System.EventHandler(this.kryptonRichTextBoxExtended1_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(11, 87);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Note Details";
            // 
            // addNote_btn
            // 
            this.addNote_btn.CornerRoundingRadius = -1F;
            this.addNote_btn.Location = new System.Drawing.Point(168, 350);
            this.addNote_btn.Name = "addNote_btn";
            this.addNote_btn.Size = new System.Drawing.Size(114, 25);
            this.addNote_btn.TabIndex = 4;
            this.addNote_btn.Values.Text = "Add Note";
            this.addNote_btn.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.CornerRoundingRadius = -1F;
            this.reset_btn.Location = new System.Drawing.Point(305, 350);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(114, 25);
            this.reset_btn.TabIndex = 5;
            this.reset_btn.Values.Text = "Reset";
            this.reset_btn.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // remChar_lbl
            // 
            this.remChar_lbl.Location = new System.Drawing.Point(5, 253);
            this.remChar_lbl.Name = "remChar_lbl";
            this.remChar_lbl.Size = new System.Drawing.Size(150, 16);
            this.remChar_lbl.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remChar_lbl.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remChar_lbl.TabIndex = 6;
            this.remChar_lbl.Values.Text = "Remaining Characters:500";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(434, 350);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(114, 25);
            this.kryptonButton1.TabIndex = 7;
            this.kryptonButton1.Values.Text = "Reset";
            // 
            // NewTaskNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Name = "NewTaskNote";
            this.Text = "NewTaskNote";
            this.Load += new System.EventHandler(this.NewTaskNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonRichTextBoxExtended noteDetails_rtb;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox noteDes_txt;
        private Krypton.Toolkit.KryptonButton addNote_btn;
        private Krypton.Toolkit.KryptonLabel remChar_lbl;
        private Krypton.Toolkit.KryptonButton reset_btn;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}