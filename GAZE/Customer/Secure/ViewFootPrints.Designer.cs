namespace GAZE.Customer.AdminControls
{
    partial class ViewFootPrints
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonDataGridView1 = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonDataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 419);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Policy Foot Prints";
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(3, 16);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(812, 400);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.CornerRoundingRadius = -1F;
            this.kryptonButton3.Location = new System.Drawing.Point(572, 422);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(120, 25);
            this.kryptonButton3.TabIndex = 6;
            this.kryptonButton3.Values.Text = "Ok";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(695, 422);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(120, 25);
            this.kryptonButton2.TabIndex = 5;
            this.kryptonButton2.Values.Text = "Cancel";
            // 
            // ViewFootPrints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 450);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ViewFootPrints";
            this.Text = "ViewFootPrints";
            this.Load += new System.EventHandler(this.ViewFootPrints_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}