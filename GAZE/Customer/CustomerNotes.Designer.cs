﻿namespace GAZE.Customer
{
    partial class CustomerNotes
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
            this.NoteDataGridView = new System.Windows.Forms.DataGridView();
            this.note_lbl = new MetroFramework.Controls.MetroLabel();
            this.CustName_lbl = new MetroFramework.Controls.MetroLabel();
            this.CustName_txt = new MetroFramework.Controls.MetroTextBox();
            this.Notelbl = new MetroFramework.Controls.MetroLabel();
            this.notedetails_txt = new MetroFramework.Controls.MetroTextBox();
            this.NoteID_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.CreateDate_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.CreateBy_txt = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NoteDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteDataGridView
            // 
            this.NoteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NoteDataGridView.Location = new System.Drawing.Point(13, 268);
            this.NoteDataGridView.Name = "NoteDataGridView";
            this.NoteDataGridView.Size = new System.Drawing.Size(775, 227);
            this.NoteDataGridView.TabIndex = 0;
            this.NoteDataGridView.SelectionChanged += new System.EventHandler(this.NoteDataGridView_SelectionChanged);
            // 
            // note_lbl
            // 
            this.note_lbl.AutoSize = true;
            this.note_lbl.Location = new System.Drawing.Point(13, 18);
            this.note_lbl.Name = "note_lbl";
            this.note_lbl.Size = new System.Drawing.Size(53, 19);
            this.note_lbl.TabIndex = 1;
            this.note_lbl.Text = "NoteID:";
            // 
            // CustName_lbl
            // 
            this.CustName_lbl.AutoSize = true;
            this.CustName_lbl.Location = new System.Drawing.Point(13, 46);
            this.CustName_lbl.Name = "CustName_lbl";
            this.CustName_lbl.Size = new System.Drawing.Size(109, 19);
            this.CustName_lbl.TabIndex = 2;
            this.CustName_lbl.Text = "Customer Name:";
            // 
            // CustName_txt
            // 
            // 
            // 
            // 
            this.CustName_txt.CustomButton.Image = null;
            this.CustName_txt.CustomButton.Location = new System.Drawing.Point(638, 1);
            this.CustName_txt.CustomButton.Name = "";
            this.CustName_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CustName_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CustName_txt.CustomButton.TabIndex = 1;
            this.CustName_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CustName_txt.CustomButton.UseSelectable = true;
            this.CustName_txt.CustomButton.Visible = false;
            this.CustName_txt.Lines = new string[0];
            this.CustName_txt.Location = new System.Drawing.Point(128, 46);
            this.CustName_txt.MaxLength = 32767;
            this.CustName_txt.Name = "CustName_txt";
            this.CustName_txt.PasswordChar = '\0';
            this.CustName_txt.PromptText = "Customer Name";
            this.CustName_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CustName_txt.SelectedText = "";
            this.CustName_txt.SelectionLength = 0;
            this.CustName_txt.SelectionStart = 0;
            this.CustName_txt.ShortcutsEnabled = true;
            this.CustName_txt.Size = new System.Drawing.Size(660, 23);
            this.CustName_txt.TabIndex = 3;
            this.CustName_txt.UseSelectable = true;
            this.CustName_txt.WaterMark = "Customer Name";
            this.CustName_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CustName_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Notelbl
            // 
            this.Notelbl.AutoSize = true;
            this.Notelbl.Location = new System.Drawing.Point(13, 78);
            this.Notelbl.Name = "Notelbl";
            this.Notelbl.Size = new System.Drawing.Size(83, 19);
            this.Notelbl.TabIndex = 4;
            this.Notelbl.Text = "Note Details:";
            // 
            // notedetails_txt
            // 
            // 
            // 
            // 
            this.notedetails_txt.CustomButton.Image = null;
            this.notedetails_txt.CustomButton.Location = new System.Drawing.Point(530, 2);
            this.notedetails_txt.CustomButton.Name = "";
            this.notedetails_txt.CustomButton.Size = new System.Drawing.Size(127, 127);
            this.notedetails_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.notedetails_txt.CustomButton.TabIndex = 1;
            this.notedetails_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.notedetails_txt.CustomButton.UseSelectable = true;
            this.notedetails_txt.CustomButton.Visible = false;
            this.notedetails_txt.Lines = new string[0];
            this.notedetails_txt.Location = new System.Drawing.Point(128, 73);
            this.notedetails_txt.MaxLength = 32767;
            this.notedetails_txt.Multiline = true;
            this.notedetails_txt.Name = "notedetails_txt";
            this.notedetails_txt.PasswordChar = '\0';
            this.notedetails_txt.PromptText = "Note Details";
            this.notedetails_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.notedetails_txt.SelectedText = "";
            this.notedetails_txt.SelectionLength = 0;
            this.notedetails_txt.SelectionStart = 0;
            this.notedetails_txt.ShortcutsEnabled = true;
            this.notedetails_txt.Size = new System.Drawing.Size(660, 132);
            this.notedetails_txt.TabIndex = 5;
            this.notedetails_txt.UseSelectable = true;
            this.notedetails_txt.WaterMark = "Note Details";
            this.notedetails_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.notedetails_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // NoteID_txt
            // 
            // 
            // 
            // 
            this.NoteID_txt.CustomButton.Image = null;
            this.NoteID_txt.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.NoteID_txt.CustomButton.Name = "";
            this.NoteID_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.NoteID_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NoteID_txt.CustomButton.TabIndex = 1;
            this.NoteID_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NoteID_txt.CustomButton.UseSelectable = true;
            this.NoteID_txt.CustomButton.Visible = false;
            this.NoteID_txt.Lines = new string[0];
            this.NoteID_txt.Location = new System.Drawing.Point(128, 18);
            this.NoteID_txt.MaxLength = 32767;
            this.NoteID_txt.Name = "NoteID_txt";
            this.NoteID_txt.PasswordChar = '\0';
            this.NoteID_txt.PromptText = "Note ID";
            this.NoteID_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NoteID_txt.SelectedText = "";
            this.NoteID_txt.SelectionLength = 0;
            this.NoteID_txt.SelectionStart = 0;
            this.NoteID_txt.ShortcutsEnabled = true;
            this.NoteID_txt.Size = new System.Drawing.Size(133, 23);
            this.NoteID_txt.TabIndex = 6;
            this.NoteID_txt.UseSelectable = true;
            this.NoteID_txt.WaterMark = "Note ID";
            this.NoteID_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NoteID_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(306, 18);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 23);
            this.metroButton1.TabIndex = 7;
            this.metroButton1.Text = "Close";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // CreateDate_txt
            // 
            // 
            // 
            // 
            this.CreateDate_txt.CustomButton.Image = null;
            this.CreateDate_txt.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.CreateDate_txt.CustomButton.Name = "";
            this.CreateDate_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CreateDate_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CreateDate_txt.CustomButton.TabIndex = 1;
            this.CreateDate_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CreateDate_txt.CustomButton.UseSelectable = true;
            this.CreateDate_txt.CustomButton.Visible = false;
            this.CreateDate_txt.Lines = new string[0];
            this.CreateDate_txt.Location = new System.Drawing.Point(128, 212);
            this.CreateDate_txt.MaxLength = 32767;
            this.CreateDate_txt.Name = "CreateDate_txt";
            this.CreateDate_txt.PasswordChar = '\0';
            this.CreateDate_txt.PromptText = "Created Date";
            this.CreateDate_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CreateDate_txt.SelectedText = "";
            this.CreateDate_txt.SelectionLength = 0;
            this.CreateDate_txt.SelectionStart = 0;
            this.CreateDate_txt.ShortcutsEnabled = true;
            this.CreateDate_txt.Size = new System.Drawing.Size(133, 23);
            this.CreateDate_txt.TabIndex = 8;
            this.CreateDate_txt.UseSelectable = true;
            this.CreateDate_txt.WaterMark = "Created Date";
            this.CreateDate_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CreateDate_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(13, 212);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "Created Date:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 239);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Created By:";
            // 
            // CreateBy_txt
            // 
            // 
            // 
            // 
            this.CreateBy_txt.CustomButton.Image = null;
            this.CreateBy_txt.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.CreateBy_txt.CustomButton.Name = "";
            this.CreateBy_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CreateBy_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CreateBy_txt.CustomButton.TabIndex = 1;
            this.CreateBy_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CreateBy_txt.CustomButton.UseSelectable = true;
            this.CreateBy_txt.CustomButton.Visible = false;
            this.CreateBy_txt.Lines = new string[0];
            this.CreateBy_txt.Location = new System.Drawing.Point(128, 239);
            this.CreateBy_txt.MaxLength = 32767;
            this.CreateBy_txt.Name = "CreateBy_txt";
            this.CreateBy_txt.PasswordChar = '\0';
            this.CreateBy_txt.PromptText = "Created By";
            this.CreateBy_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CreateBy_txt.SelectedText = "";
            this.CreateBy_txt.SelectionLength = 0;
            this.CreateBy_txt.SelectionStart = 0;
            this.CreateBy_txt.ShortcutsEnabled = true;
            this.CreateBy_txt.Size = new System.Drawing.Size(133, 23);
            this.CreateBy_txt.TabIndex = 10;
            this.CreateBy_txt.UseSelectable = true;
            this.CreateBy_txt.WaterMark = "Created By";
            this.CreateBy_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CreateBy_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CustomerNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.CreateBy_txt);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.CreateDate_txt);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.NoteID_txt);
            this.Controls.Add(this.notedetails_txt);
            this.Controls.Add(this.Notelbl);
            this.Controls.Add(this.CustName_txt);
            this.Controls.Add(this.CustName_lbl);
            this.Controls.Add(this.note_lbl);
            this.Controls.Add(this.NoteDataGridView);
            this.Name = "CustomerNotes";
            this.Text = "CustomerNotes";
            this.Load += new System.EventHandler(this.CustomerNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NoteDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView NoteDataGridView;
        private MetroFramework.Controls.MetroLabel note_lbl;
        private MetroFramework.Controls.MetroLabel CustName_lbl;
        private MetroFramework.Controls.MetroTextBox CustName_txt;
        private MetroFramework.Controls.MetroLabel Notelbl;
        private MetroFramework.Controls.MetroTextBox notedetails_txt;
        private MetroFramework.Controls.MetroTextBox NoteID_txt;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox CreateDate_txt;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox CreateBy_txt;
    }
}