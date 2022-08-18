namespace GAZE.Admin
{
    partial class CreateUser
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
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.admin_chk = new MetroFramework.Controls.MetroCheckBox();
            this.addusr_txt = new MetroFramework.Controls.MetroButton();
            this.FName_txt = new MetroFramework.Controls.MetroTextBox();
            this.sName_txt = new MetroFramework.Controls.MetroTextBox();
            this.username_txt = new MetroFramework.Controls.MetroTextBox();
            this.password_txt = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 16);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(73, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "First Name";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 45);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(61, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Surname";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(31, 78);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "Username";
            // 
            // admin_chk
            // 
            this.admin_chk.AutoSize = true;
            this.admin_chk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.admin_chk.Location = new System.Drawing.Point(28, 139);
            this.admin_chk.Name = "admin_chk";
            this.admin_chk.Size = new System.Drawing.Size(183, 15);
            this.admin_chk.TabIndex = 3;
            this.admin_chk.Text = "Admin User?                               ";
            this.admin_chk.UseSelectable = true;
            // 
            // addusr_txt
            // 
            this.addusr_txt.Location = new System.Drawing.Point(116, 167);
            this.addusr_txt.Name = "addusr_txt";
            this.addusr_txt.Size = new System.Drawing.Size(169, 23);
            this.addusr_txt.TabIndex = 4;
            this.addusr_txt.Text = "Create User";
            this.addusr_txt.UseSelectable = true;
            this.addusr_txt.Click += new System.EventHandler(this.Addusr_txt_Click);
            // 
            // FName_txt
            // 
            // 
            // 
            // 
            this.FName_txt.CustomButton.Image = null;
            this.FName_txt.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.FName_txt.CustomButton.Name = "";
            this.FName_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FName_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FName_txt.CustomButton.TabIndex = 1;
            this.FName_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FName_txt.CustomButton.UseSelectable = true;
            this.FName_txt.CustomButton.Visible = false;
            this.FName_txt.Lines = new string[0];
            this.FName_txt.Location = new System.Drawing.Point(130, 16);
            this.FName_txt.MaxLength = 32767;
            this.FName_txt.Name = "FName_txt";
            this.FName_txt.PasswordChar = '\0';
            this.FName_txt.PromptText = "First Name";
            this.FName_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FName_txt.SelectedText = "";
            this.FName_txt.SelectionLength = 0;
            this.FName_txt.SelectionStart = 0;
            this.FName_txt.ShortcutsEnabled = true;
            this.FName_txt.Size = new System.Drawing.Size(169, 23);
            this.FName_txt.TabIndex = 5;
            this.FName_txt.UseSelectable = true;
            this.FName_txt.WaterMark = "First Name";
            this.FName_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FName_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sName_txt
            // 
            // 
            // 
            // 
            this.sName_txt.CustomButton.Image = null;
            this.sName_txt.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.sName_txt.CustomButton.Name = "";
            this.sName_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.sName_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sName_txt.CustomButton.TabIndex = 1;
            this.sName_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sName_txt.CustomButton.UseSelectable = true;
            this.sName_txt.CustomButton.Visible = false;
            this.sName_txt.Lines = new string[0];
            this.sName_txt.Location = new System.Drawing.Point(130, 45);
            this.sName_txt.MaxLength = 32767;
            this.sName_txt.Name = "sName_txt";
            this.sName_txt.PasswordChar = '\0';
            this.sName_txt.PromptText = "Surname";
            this.sName_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sName_txt.SelectedText = "";
            this.sName_txt.SelectionLength = 0;
            this.sName_txt.SelectionStart = 0;
            this.sName_txt.ShortcutsEnabled = true;
            this.sName_txt.Size = new System.Drawing.Size(169, 23);
            this.sName_txt.TabIndex = 6;
            this.sName_txt.UseSelectable = true;
            this.sName_txt.WaterMark = "Surname";
            this.sName_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sName_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // username_txt
            // 
            // 
            // 
            // 
            this.username_txt.CustomButton.Image = null;
            this.username_txt.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.username_txt.CustomButton.Name = "";
            this.username_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.username_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.username_txt.CustomButton.TabIndex = 1;
            this.username_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.username_txt.CustomButton.UseSelectable = true;
            this.username_txt.CustomButton.Visible = false;
            this.username_txt.Lines = new string[0];
            this.username_txt.Location = new System.Drawing.Point(130, 74);
            this.username_txt.MaxLength = 32767;
            this.username_txt.Name = "username_txt";
            this.username_txt.PasswordChar = '\0';
            this.username_txt.PromptText = "Username";
            this.username_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.username_txt.SelectedText = "";
            this.username_txt.SelectionLength = 0;
            this.username_txt.SelectionStart = 0;
            this.username_txt.ShortcutsEnabled = true;
            this.username_txt.Size = new System.Drawing.Size(169, 23);
            this.username_txt.TabIndex = 7;
            this.username_txt.UseSelectable = true;
            this.username_txt.WaterMark = "Username";
            this.username_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.username_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.username_txt.Click += new System.EventHandler(this.Username_txt_Click);
            this.username_txt.Enter += new System.EventHandler(this.Username_txt_Enter);
            // 
            // password_txt
            // 
            // 
            // 
            // 
            this.password_txt.CustomButton.Image = null;
            this.password_txt.CustomButton.Location = new System.Drawing.Point(147, 1);
            this.password_txt.CustomButton.Name = "";
            this.password_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.password_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password_txt.CustomButton.TabIndex = 1;
            this.password_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password_txt.CustomButton.UseSelectable = true;
            this.password_txt.CustomButton.Visible = false;
            this.password_txt.Lines = new string[0];
            this.password_txt.Location = new System.Drawing.Point(130, 103);
            this.password_txt.MaxLength = 32767;
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '\0';
            this.password_txt.PromptText = "Password";
            this.password_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password_txt.SelectedText = "";
            this.password_txt.SelectionLength = 0;
            this.password_txt.SelectionStart = 0;
            this.password_txt.ShortcutsEnabled = true;
            this.password_txt.Size = new System.Drawing.Size(169, 23);
            this.password_txt.TabIndex = 9;
            this.password_txt.UseSelectable = true;
            this.password_txt.WaterMark = "Password";
            this.password_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(31, 107);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(63, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Password";
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 206);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.sName_txt);
            this.Controls.Add(this.FName_txt);
            this.Controls.Add(this.addusr_txt);
            this.Controls.Add(this.admin_chk);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "CreateUser";
            this.Text = "CreateUser";
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox admin_chk;
        private MetroFramework.Controls.MetroButton addusr_txt;
        private MetroFramework.Controls.MetroTextBox FName_txt;
        private MetroFramework.Controls.MetroTextBox sName_txt;
        private MetroFramework.Controls.MetroTextBox username_txt;
        private MetroFramework.Controls.MetroTextBox password_txt;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}