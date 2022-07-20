namespace GAZE.Admin
{
    partial class LoginForm
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
            this.usernamelbl = new MetroFramework.Controls.MetroLabel();
            this.username_txt = new MetroFramework.Controls.MetroTextBox();
            this.password_txt = new MetroFramework.Controls.MetroTextBox();
            this.passwordlbl = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // usernamelbl
            // 
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.Location = new System.Drawing.Point(225, 50);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(68, 19);
            this.usernamelbl.TabIndex = 0;
            this.usernamelbl.Text = "Username";
            // 
            // username_txt
            // 
            // 
            // 
            // 
            this.username_txt.CustomButton.Image = null;
            this.username_txt.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.username_txt.CustomButton.Name = "";
            this.username_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.username_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.username_txt.CustomButton.TabIndex = 1;
            this.username_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.username_txt.CustomButton.UseSelectable = true;
            this.username_txt.CustomButton.Visible = false;
            this.username_txt.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.username_txt.Lines = new string[0];
            this.username_txt.Location = new System.Drawing.Point(312, 50);
            this.username_txt.MaxLength = 32767;
            this.username_txt.Name = "username_txt";
            this.username_txt.PasswordChar = '\0';
            this.username_txt.PromptText = "Username";
            this.username_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.username_txt.SelectedText = "";
            this.username_txt.SelectionLength = 0;
            this.username_txt.SelectionStart = 0;
            this.username_txt.ShortcutsEnabled = true;
            this.username_txt.Size = new System.Drawing.Size(250, 23);
            this.username_txt.TabIndex = 1;
            this.username_txt.UseSelectable = true;
            this.username_txt.WaterMark = "Username";
            this.username_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.username_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // password_txt
            // 
            // 
            // 
            // 
            this.password_txt.CustomButton.Image = null;
            this.password_txt.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.password_txt.CustomButton.Name = "";
            this.password_txt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.password_txt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.password_txt.CustomButton.TabIndex = 1;
            this.password_txt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.password_txt.CustomButton.UseSelectable = true;
            this.password_txt.CustomButton.Visible = false;
            this.password_txt.Lines = new string[0];
            this.password_txt.Location = new System.Drawing.Point(312, 96);
            this.password_txt.MaxLength = 32767;
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '\0';
            this.password_txt.PromptText = "Password";
            this.password_txt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password_txt.SelectedText = "";
            this.password_txt.SelectionLength = 0;
            this.password_txt.SelectionStart = 0;
            this.password_txt.ShortcutsEnabled = true;
            this.password_txt.Size = new System.Drawing.Size(250, 23);
            this.password_txt.TabIndex = 2;
            this.password_txt.UseSelectable = true;
            this.password_txt.WaterMark = "Password";
            this.password_txt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.password_txt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Location = new System.Drawing.Point(225, 96);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(63, 19);
            this.passwordlbl.TabIndex = 3;
            this.passwordlbl.Text = "Password";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 181);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.usernamelbl);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel usernamelbl;
        private MetroFramework.Controls.MetroTextBox username_txt;
        private MetroFramework.Controls.MetroTextBox password_txt;
        private MetroFramework.Controls.MetroLabel passwordlbl;
    }
}