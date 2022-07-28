namespace GAZE.Admin
{
    partial class UserMgr
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
            this.fstname_txt = new MetroFramework.Controls.MetroTextBox();
            this.surname_txt = new MetroFramework.Controls.MetroTextBox();
            this.usrname_txt = new MetroFramework.Controls.MetroTextBox();
            this.psswrd_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.id_txt = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 186);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // fstname_txt
            // 
            // 
            // 
            // 
            this.fstname_txt.CustomButton.Image = null;
            this.fstname_txt.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.fstname_txt.CustomButton.Name = "";
            this.fstname_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.fstname_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.fstname_txt.CustomButton.TabIndex = 1;
            this.fstname_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.fstname_txt.CustomButton.UseSelectable = true;
            this.fstname_txt.CustomButton.Visible = false;
            this.fstname_txt.Lines = new string[0];
            this.fstname_txt.Location = new System.Drawing.Point(137, 52);
            this.fstname_txt.MaxLength = 32767;
            this.fstname_txt.Name = "fstname_txt";
            this.fstname_txt.PasswordChar = '\0';
            this.fstname_txt.PromptText = "FirstName";
            this.fstname_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.fstname_txt.SelectedText = "";
            this.fstname_txt.SelectionLength = 0;
            this.fstname_txt.SelectionStart = 0;
            this.fstname_txt.ShortcutsEnabled = true;
            this.fstname_txt.Size = new System.Drawing.Size(175, 23);
            this.fstname_txt.TabIndex = 1;
            this.fstname_txt.UseSelectable = true;
            this.fstname_txt.WaterMark = "FirstName";
            this.fstname_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.fstname_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // surname_txt
            // 
            // 
            // 
            // 
            this.surname_txt.CustomButton.Image = null;
            this.surname_txt.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.surname_txt.CustomButton.Name = "";
            this.surname_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.surname_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.surname_txt.CustomButton.TabIndex = 1;
            this.surname_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.surname_txt.CustomButton.UseSelectable = true;
            this.surname_txt.CustomButton.Visible = false;
            this.surname_txt.Lines = new string[0];
            this.surname_txt.Location = new System.Drawing.Point(137, 81);
            this.surname_txt.MaxLength = 32767;
            this.surname_txt.Name = "surname_txt";
            this.surname_txt.PasswordChar = '\0';
            this.surname_txt.PromptText = "Surname";
            this.surname_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.surname_txt.SelectedText = "";
            this.surname_txt.SelectionLength = 0;
            this.surname_txt.SelectionStart = 0;
            this.surname_txt.ShortcutsEnabled = true;
            this.surname_txt.Size = new System.Drawing.Size(175, 23);
            this.surname_txt.TabIndex = 2;
            this.surname_txt.UseSelectable = true;
            this.surname_txt.WaterMark = "Surname";
            this.surname_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.surname_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // usrname_txt
            // 
            // 
            // 
            // 
            this.usrname_txt.CustomButton.Image = null;
            this.usrname_txt.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.usrname_txt.CustomButton.Name = "";
            this.usrname_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.usrname_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usrname_txt.CustomButton.TabIndex = 1;
            this.usrname_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usrname_txt.CustomButton.UseSelectable = true;
            this.usrname_txt.CustomButton.Visible = false;
            this.usrname_txt.Lines = new string[0];
            this.usrname_txt.Location = new System.Drawing.Point(137, 110);
            this.usrname_txt.MaxLength = 32767;
            this.usrname_txt.Name = "usrname_txt";
            this.usrname_txt.PasswordChar = '\0';
            this.usrname_txt.PromptText = "Username";
            this.usrname_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usrname_txt.SelectedText = "";
            this.usrname_txt.SelectionLength = 0;
            this.usrname_txt.SelectionStart = 0;
            this.usrname_txt.ShortcutsEnabled = true;
            this.usrname_txt.Size = new System.Drawing.Size(175, 23);
            this.usrname_txt.TabIndex = 3;
            this.usrname_txt.UseSelectable = true;
            this.usrname_txt.WaterMark = "Username";
            this.usrname_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usrname_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // psswrd_txt
            // 
            // 
            // 
            // 
            this.psswrd_txt.CustomButton.Image = null;
            this.psswrd_txt.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.psswrd_txt.CustomButton.Name = "";
            this.psswrd_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.psswrd_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.psswrd_txt.CustomButton.TabIndex = 1;
            this.psswrd_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.psswrd_txt.CustomButton.UseSelectable = true;
            this.psswrd_txt.CustomButton.Visible = false;
            this.psswrd_txt.Lines = new string[0];
            this.psswrd_txt.Location = new System.Drawing.Point(137, 139);
            this.psswrd_txt.MaxLength = 32767;
            this.psswrd_txt.Name = "psswrd_txt";
            this.psswrd_txt.PasswordChar = '\0';
            this.psswrd_txt.PromptText = "Password";
            this.psswrd_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.psswrd_txt.SelectedText = "";
            this.psswrd_txt.SelectionLength = 0;
            this.psswrd_txt.SelectionStart = 0;
            this.psswrd_txt.ShortcutsEnabled = true;
            this.psswrd_txt.Size = new System.Drawing.Size(175, 23);
            this.psswrd_txt.TabIndex = 4;
            this.psswrd_txt.UseSelectable = true;
            this.psswrd_txt.WaterMark = "Password";
            this.psswrd_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.psswrd_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(137, 169);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(76, 15);
            this.metroCheckBox1.TabIndex = 5;
            this.metroCheckBox1.Text = "IS Admin?";
            this.metroCheckBox1.UseSelectable = true;
            // 
            // id_txt
            // 
            // 
            // 
            // 
            this.id_txt.CustomButton.Image = null;
            this.id_txt.CustomButton.Location = new System.Drawing.Point(74, 1);
            this.id_txt.CustomButton.Name = "";
            this.id_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.id_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.id_txt.CustomButton.TabIndex = 1;
            this.id_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.id_txt.CustomButton.UseSelectable = true;
            this.id_txt.CustomButton.Visible = false;
            this.id_txt.Lines = new string[0];
            this.id_txt.Location = new System.Drawing.Point(137, 23);
            this.id_txt.MaxLength = 32767;
            this.id_txt.Name = "id_txt";
            this.id_txt.PasswordChar = '\0';
            this.id_txt.PromptText = "ID";
            this.id_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.id_txt.SelectedText = "";
            this.id_txt.SelectionLength = 0;
            this.id_txt.SelectionStart = 0;
            this.id_txt.ShortcutsEnabled = true;
            this.id_txt.Size = new System.Drawing.Size(96, 23);
            this.id_txt.TabIndex = 6;
            this.id_txt.UseSelectable = true;
            this.id_txt.WaterMark = "ID";
            this.id_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.id_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UserMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 208);
            this.Controls.Add(this.id_txt);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.psswrd_txt);
            this.Controls.Add(this.usrname_txt);
            this.Controls.Add(this.surname_txt);
            this.Controls.Add(this.fstname_txt);
            this.Controls.Add(this.listBox1);
            this.Name = "UserMgr";
            this.Text = "UserMgr";
            this.Load += new System.EventHandler(this.UserMgr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroTextBox fstname_txt;
        private MetroFramework.Controls.MetroTextBox surname_txt;
        private MetroFramework.Controls.MetroTextBox usrname_txt;
        private MetroFramework.Controls.MetroTextBox psswrd_txt;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroTextBox id_txt;
    }
}