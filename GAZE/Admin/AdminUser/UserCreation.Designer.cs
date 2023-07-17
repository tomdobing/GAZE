namespace GAZE.Admin.AdminUser
{
    partial class UserCreation
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
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.forname_txt = new Krypton.Toolkit.KryptonTextBox();
            this.surname_txt = new Krypton.Toolkit.KryptonTextBox();
            this.username_txt = new Krypton.Toolkit.KryptonTextBox();
            this.password1_txt = new Krypton.Toolkit.KryptonTextBox();
            this.password2_txt = new Krypton.Toolkit.KryptonTextBox();
            this.role_cmb = new Krypton.Toolkit.KryptonComboBox();
            this.create_btn = new Krypton.Toolkit.KryptonButton();
            this.cancel_btn = new Krypton.Toolkit.KryptonButton();
            this.passreqs_lbl = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.role_cmb)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(65, 26);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(70, 19);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Forname:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(65, 64);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(71, 19);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Surname:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(65, 103);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(79, 19);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Username:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(65, 168);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(76, 19);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Password:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(65, 202);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(128, 19);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "Confirm Password:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(65, 252);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(76, 19);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 5;
            this.kryptonLabel6.Values.Text = "User Role:";
            // 
            // forname_txt
            // 
            this.forname_txt.Location = new System.Drawing.Point(251, 26);
            this.forname_txt.Name = "forname_txt";
            this.forname_txt.Size = new System.Drawing.Size(243, 23);
            this.forname_txt.TabIndex = 6;
            // 
            // surname_txt
            // 
            this.surname_txt.Location = new System.Drawing.Point(251, 64);
            this.surname_txt.Name = "surname_txt";
            this.surname_txt.Size = new System.Drawing.Size(243, 23);
            this.surname_txt.TabIndex = 7;
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(251, 103);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(243, 23);
            this.username_txt.TabIndex = 8;
            this.username_txt.TextChanged += new System.EventHandler(this.username_txt_TextChanged);
            this.username_txt.Enter += new System.EventHandler(this.username_txt_Enter);
            // 
            // password1_txt
            // 
            this.password1_txt.Location = new System.Drawing.Point(251, 168);
            this.password1_txt.Name = "password1_txt";
            this.password1_txt.PasswordChar = '●';
            this.password1_txt.Size = new System.Drawing.Size(243, 23);
            this.password1_txt.TabIndex = 9;
            this.password1_txt.UseSystemPasswordChar = true;
            // 
            // password2_txt
            // 
            this.password2_txt.Location = new System.Drawing.Point(251, 202);
            this.password2_txt.Name = "password2_txt";
            this.password2_txt.PasswordChar = '●';
            this.password2_txt.Size = new System.Drawing.Size(243, 23);
            this.password2_txt.TabIndex = 10;
            this.password2_txt.UseSystemPasswordChar = true;
            // 
            // role_cmb
            // 
            this.role_cmb.CornerRoundingRadius = -1F;
            this.role_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.role_cmb.DropDownWidth = 243;
            this.role_cmb.IntegralHeight = false;
            this.role_cmb.Location = new System.Drawing.Point(251, 250);
            this.role_cmb.Name = "role_cmb";
            this.role_cmb.Size = new System.Drawing.Size(243, 21);
            this.role_cmb.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.role_cmb.TabIndex = 11;
            // 
            // create_btn
            // 
            this.create_btn.CornerRoundingRadius = -1F;
            this.create_btn.Location = new System.Drawing.Point(155, 290);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(104, 25);
            this.create_btn.TabIndex = 12;
            this.create_btn.Values.Text = "&Create User";
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.CornerRoundingRadius = -1F;
            this.cancel_btn.Location = new System.Drawing.Point(334, 290);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(104, 25);
            this.cancel_btn.TabIndex = 13;
            this.cancel_btn.Values.Text = "&Cancel";
            // 
            // passreqs_lbl
            // 
            this.passreqs_lbl.Location = new System.Drawing.Point(509, 30);
            this.passreqs_lbl.Name = "passreqs_lbl";
            this.passreqs_lbl.Size = new System.Drawing.Size(239, 92);
            this.passreqs_lbl.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passreqs_lbl.TabIndex = 14;
            this.passreqs_lbl.Values.Text = "Password Complexity:\r\nContain At least 12 Characters\r\nContain At Least 1 Capital " +
    "Letter\r\nContain At Least 1 Number\r\nContain At Least 1 Special Character\r\nNot Con" +
    "tain Common Words";
            // 
            // UserCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 339);
            this.Controls.Add(this.passreqs_lbl);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.create_btn);
            this.Controls.Add(this.role_cmb);
            this.Controls.Add(this.password2_txt);
            this.Controls.Add(this.password1_txt);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.surname_txt);
            this.Controls.Add(this.forname_txt);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Name = "UserCreation";
            this.Text = "UserCreation";
            this.Load += new System.EventHandler(this.UserCreation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.role_cmb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonTextBox forname_txt;
        private Krypton.Toolkit.KryptonTextBox surname_txt;
        private Krypton.Toolkit.KryptonTextBox username_txt;
        private Krypton.Toolkit.KryptonTextBox password1_txt;
        private Krypton.Toolkit.KryptonTextBox password2_txt;
        private Krypton.Toolkit.KryptonComboBox role_cmb;
        private Krypton.Toolkit.KryptonButton create_btn;
        private Krypton.Toolkit.KryptonButton cancel_btn;
        private Krypton.Toolkit.KryptonLabel passreqs_lbl;
    }
}