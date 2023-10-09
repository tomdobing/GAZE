namespace GAZE.Customer.DPA
{
    partial class UpdateDPAPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateDPAPassword));
            this.custinf_lbl = new Krypton.Toolkit.KryptonLabel();
            this.currPass_txt = new Krypton.Toolkit.KryptonTextBox();
            this.currPass_lbl = new Krypton.Toolkit.KryptonLabel();
            this.newPass_lbl = new Krypton.Toolkit.KryptonLabel();
            this.newPass_txt = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // custinf_lbl
            // 
            this.custinf_lbl.Location = new System.Drawing.Point(12, 12);
            this.custinf_lbl.Name = "custinf_lbl";
            this.custinf_lbl.Size = new System.Drawing.Size(88, 20);
            this.custinf_lbl.TabIndex = 0;
            this.custinf_lbl.Values.Text = "kryptonLabel1";
            // 
            // currPass_txt
            // 
            this.currPass_txt.Location = new System.Drawing.Point(116, 46);
            this.currPass_txt.Name = "currPass_txt";
            this.currPass_txt.Size = new System.Drawing.Size(328, 20);
            this.currPass_txt.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currPass_txt.TabIndex = 1;
            // 
            // currPass_lbl
            // 
            this.currPass_lbl.Location = new System.Drawing.Point(4, 49);
            this.currPass_lbl.Name = "currPass_lbl";
            this.currPass_lbl.Size = new System.Drawing.Size(107, 16);
            this.currPass_lbl.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currPass_lbl.TabIndex = 2;
            this.currPass_lbl.Values.Text = "Current Password:";
            // 
            // newPass_lbl
            // 
            this.newPass_lbl.Location = new System.Drawing.Point(4, 105);
            this.newPass_lbl.Name = "newPass_lbl";
            this.newPass_lbl.Size = new System.Drawing.Size(91, 16);
            this.newPass_lbl.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPass_lbl.TabIndex = 4;
            this.newPass_lbl.Values.Text = "New Password:";
            // 
            // newPass_txt
            // 
            this.newPass_txt.Location = new System.Drawing.Point(116, 102);
            this.newPass_txt.Name = "newPass_txt";
            this.newPass_txt.Size = new System.Drawing.Size(328, 20);
            this.newPass_txt.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPass_txt.TabIndex = 3;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(143, 128);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(118, 25);
            this.kryptonButton1.TabIndex = 5;
            this.kryptonButton1.UseAsUACElevationButton = true;
            this.kryptonButton1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.Values.Image")));
            this.kryptonButton1.Values.Text = "Submit";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(267, 128);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(118, 25);
            this.kryptonButton2.TabIndex = 6;
            this.kryptonButton2.Values.Text = "Cancel";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // UpdateDPAPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 177);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.newPass_lbl);
            this.Controls.Add(this.newPass_txt);
            this.Controls.Add(this.currPass_lbl);
            this.Controls.Add(this.currPass_txt);
            this.Controls.Add(this.custinf_lbl);
            this.Name = "UpdateDPAPassword";
            this.Text = "UpdateDPAPassword";
            this.Load += new System.EventHandler(this.UpdateDPAPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel custinf_lbl;
        private Krypton.Toolkit.KryptonTextBox currPass_txt;
        private Krypton.Toolkit.KryptonLabel currPass_lbl;
        private Krypton.Toolkit.KryptonLabel newPass_lbl;
        private Krypton.Toolkit.KryptonTextBox newPass_txt;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}