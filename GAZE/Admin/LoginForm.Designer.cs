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
        [System.Obsolete]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernamelbl = new MetroFramework.Controls.MetroLabel();
            this.passwordlbl = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SQLError_lbl = new System.Windows.Forms.Label();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.username_txt = new Krypton.Toolkit.KryptonTextBox();
            this.Pass_txt = new Krypton.Toolkit.KryptonTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernamelbl
            // 
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.Location = new System.Drawing.Point(291, 77);
            this.usernamelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(68, 19);
            this.usernamelbl.TabIndex = 0;
            this.usernamelbl.Text = "Username";
            // 
            // passwordlbl
            // 
            this.passwordlbl.AutoSize = true;
            this.passwordlbl.Location = new System.Drawing.Point(291, 148);
            this.passwordlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(63, 19);
            this.passwordlbl.TabIndex = 3;
            this.passwordlbl.Text = "Password";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(442, 34);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(280, 25);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Welcome to G.A.Z.E. Please Sign In!";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(0, 248);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(128, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "PRODUCT VERSION";
            // 
            // SQLError_lbl
            // 
            this.SQLError_lbl.AutoSize = true;
            this.SQLError_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SQLError_lbl.Location = new System.Drawing.Point(333, 238);
            this.SQLError_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SQLError_lbl.Name = "SQLError_lbl";
            this.SQLError_lbl.Size = new System.Drawing.Size(554, 36);
            this.SQLError_lbl.TabIndex = 8;
            this.SQLError_lbl.Text = "SQLSERVERERRORPLACEHOLDER";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(422, 194);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365BlueDarkMode;
            this.kryptonButton1.Size = new System.Drawing.Size(464, 38);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonButton1.TabIndex = 9;
            this.kryptonButton1.UseAsUACElevationButton = true;
            this.kryptonButton1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.Values.Image")));
            this.kryptonButton1.Values.Text = "Login";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // username_txt
            // 
            this.username_txt.Location = new System.Drawing.Point(422, 74);
            this.username_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(464, 31);
            this.username_txt.TabIndex = 10;
            // 
            // Pass_txt
            // 
            this.Pass_txt.Location = new System.Drawing.Point(422, 148);
            this.Pass_txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Pass_txt.Name = "Pass_txt";
            this.Pass_txt.Size = new System.Drawing.Size(464, 31);
            this.Pass_txt.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GAZE.Properties.Resources.LoginSmall;
            this.pictureBox1.Location = new System.Drawing.Point(34, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 209);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.kryptonButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 275);
            this.Controls.Add(this.Pass_txt);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.SQLError_lbl);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.usernamelbl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel usernamelbl;
        private MetroFramework.Controls.MetroLabel passwordlbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.Label SQLError_lbl;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonTextBox username_txt;
        private Krypton.Toolkit.KryptonTextBox Pass_txt;
    }
}