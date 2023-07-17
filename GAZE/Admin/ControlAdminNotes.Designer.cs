namespace GAZE.Admin
{
    partial class ControlAdminNotes
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
            this.currNoteValue_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.catType_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.catNoteDesc_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.catNoteName_txt = new Krypton.Toolkit.KryptonTextBox();
            this.createCat_btn = new Krypton.Toolkit.KryptonButton();
            this.closebtn = new Krypton.Toolkit.KryptonButton();
            this.disablecat_chk = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.currNoteValue_cmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catType_cmb)).BeginInit();
            this.SuspendLayout();
            // 
            // currNoteValue_cmb
            // 
            this.currNoteValue_cmb.CornerRoundingRadius = 15F;
            this.currNoteValue_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currNoteValue_cmb.DropDownWidth = 273;
            this.currNoteValue_cmb.IntegralHeight = false;
            this.currNoteValue_cmb.Location = new System.Drawing.Point(244, 21);
            this.currNoteValue_cmb.Name = "currNoteValue_cmb";
            this.currNoteValue_cmb.Size = new System.Drawing.Size(283, 31);
            this.currNoteValue_cmb.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.currNoteValue_cmb.StateCommon.ComboBox.Border.Rounding = 15F;
            this.currNoteValue_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.currNoteValue_cmb.TabIndex = 0;
            this.currNoteValue_cmb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.currNoteValue_cmb_DrawItem);
            this.currNoteValue_cmb.SelectedIndexChanged += new System.EventHandler(this.kryptonComboBox1_SelectedIndexChanged);
            this.currNoteValue_cmb.SelectedValueChanged += new System.EventHandler(this.kryptonComboBox1_SelectedValueChanged);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionOverlap = 0D;
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.catType_cmb);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.catNoteDesc_txt);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.catNoteName_txt);
            this.kryptonGroupBox1.Panel.Controls.Add(this.currNoteValue_cmb);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(564, 300);
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "Control Values";
            // 
            // catType_cmb
            // 
            this.catType_cmb.CornerRoundingRadius = 15F;
            this.catType_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catType_cmb.DropDownWidth = 273;
            this.catType_cmb.IntegralHeight = false;
            this.catType_cmb.Location = new System.Drawing.Point(244, 209);
            this.catType_cmb.Name = "catType_cmb";
            this.catType_cmb.Size = new System.Drawing.Size(283, 31);
            this.catType_cmb.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.catType_cmb.StateCommon.ComboBox.Border.Rounding = 15F;
            this.catType_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.catType_cmb.TabIndex = 7;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(10, 209);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(120, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "New Category Type:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(10, 120);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(156, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "New Category Description:";
            // 
            // catNoteDesc_txt
            // 
            this.catNoteDesc_txt.Location = new System.Drawing.Point(244, 120);
            this.catNoteDesc_txt.Multiline = true;
            this.catNoteDesc_txt.Name = "catNoteDesc_txt";
            this.catNoteDesc_txt.Size = new System.Drawing.Size(283, 74);
            this.catNoteDesc_txt.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.catNoteDesc_txt.StateCommon.Border.Rounding = 5F;
            this.catNoteDesc_txt.TabIndex = 4;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(10, 20);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(141, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Current Category Value:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(10, 74);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(127, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "New Category Name:";
            // 
            // catNoteName_txt
            // 
            this.catNoteName_txt.Location = new System.Drawing.Point(244, 74);
            this.catNoteName_txt.Name = "catNoteName_txt";
            this.catNoteName_txt.Size = new System.Drawing.Size(283, 27);
            this.catNoteName_txt.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.catNoteName_txt.StateCommon.Border.Rounding = 5F;
            this.catNoteName_txt.TabIndex = 1;
            // 
            // createCat_btn
            // 
            this.createCat_btn.CornerRoundingRadius = -1F;
            this.createCat_btn.Location = new System.Drawing.Point(12, 306);
            this.createCat_btn.Name = "createCat_btn";
            this.createCat_btn.Size = new System.Drawing.Size(138, 25);
            this.createCat_btn.TabIndex = 2;
            this.createCat_btn.Values.Text = "Create";
            this.createCat_btn.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // closebtn
            // 
            this.closebtn.CornerRoundingRadius = -1F;
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.closebtn.Location = new System.Drawing.Point(172, 306);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(138, 25);
            this.closebtn.TabIndex = 3;
            this.closebtn.Values.Text = "Close";
            this.closebtn.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // disablecat_chk
            // 
            this.disablecat_chk.Location = new System.Drawing.Point(337, 307);
            this.disablecat_chk.Name = "disablecat_chk";
            this.disablecat_chk.Size = new System.Drawing.Size(172, 20);
            this.disablecat_chk.TabIndex = 4;
            this.disablecat_chk.Values.Text = "DIsable Selected Category?";
            this.disablecat_chk.CheckedChanged += new System.EventHandler(this.kryptonCheckBox1_CheckedChanged);
            // 
            // ControlAdminNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 343);
            this.Controls.Add(this.disablecat_chk);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.createCat_btn);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Name = "ControlAdminNotes";
            this.Text = "ControlAdminNotes";
            this.Load += new System.EventHandler(this.ControlAdminNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currNoteValue_cmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.catType_cmb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonComboBox currNoteValue_cmb;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonTextBox catNoteName_txt;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton createCat_btn;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton closebtn;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox catNoteDesc_txt;
        private Krypton.Toolkit.KryptonCheckBox disablecat_chk;
        private Krypton.Toolkit.KryptonComboBox catType_cmb;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}