namespace GAZE.Customer.Tasks
{
    partial class TaskOverview
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
            this.cancel_btn = new Krypton.Toolkit.KryptonButton();
            this.Ok_btn = new Krypton.Toolkit.KryptonButton();
            this.CreateTsk_btn = new Krypton.Toolkit.KryptonButton();
            this.kryptonTabControl1 = new Krypton.Toolkit.Suite.Extended.Navigator.KryptonTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TaskActiveDGV = new Krypton.Toolkit.KryptonDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TaskClosedDGV = new Krypton.Toolkit.KryptonDataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TaskCancDGV = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskActiveDGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskClosedDGV)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskCancDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.CornerRoundingRadius = -1F;
            this.cancel_btn.Location = new System.Drawing.Point(1119, 559);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(2);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(120, 25);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Values.Text = "&Cancel";
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.CornerRoundingRadius = -1F;
            this.Ok_btn.Location = new System.Drawing.Point(995, 559);
            this.Ok_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(120, 25);
            this.Ok_btn.TabIndex = 3;
            this.Ok_btn.Values.Text = "&Ok";
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // CreateTsk_btn
            // 
            this.CreateTsk_btn.CornerRoundingRadius = -1F;
            this.CreateTsk_btn.Location = new System.Drawing.Point(4, 559);
            this.CreateTsk_btn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateTsk_btn.Name = "CreateTsk_btn";
            this.CreateTsk_btn.Size = new System.Drawing.Size(120, 25);
            this.CreateTsk_btn.TabIndex = 4;
            this.CreateTsk_btn.Values.Text = "&Create New Task";
            this.CreateTsk_btn.Click += new System.EventHandler(this.CreateTsk_btn_Click);
            // 
            // kryptonTabControl1
            // 
            this.kryptonTabControl1.AllowCloseButton = false;
            this.kryptonTabControl1.AllowContextButton = true;
            this.kryptonTabControl1.AllowNavigatorButtons = false;
            this.kryptonTabControl1.AllowSelectedTabHigh = false;
            this.kryptonTabControl1.BorderWidth = 1;
            this.kryptonTabControl1.Controls.Add(this.tabPage1);
            this.kryptonTabControl1.Controls.Add(this.tabPage2);
            this.kryptonTabControl1.Controls.Add(this.tabPage3);
            this.kryptonTabControl1.CornerRoundRadiusWidth = 12;
            this.kryptonTabControl1.CornerSymmetry = Krypton.Toolkit.Suite.Extended.Navigator.KryptonTabControl.CornSymmetry.Both;
            this.kryptonTabControl1.CornerType = Krypton.Toolkit.Suite.Extended.Drawing.DrawingMethods.CornerType.Rounded;
            this.kryptonTabControl1.CornerWidth = Krypton.Toolkit.Suite.Extended.Navigator.KryptonTabControl.CornWidth.Thin;
            this.kryptonTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.kryptonTabControl1.HotTrack = true;
            this.kryptonTabControl1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTabControl1.Name = "kryptonTabControl1";
            this.kryptonTabControl1.PreserveTabColour = false;
            this.kryptonTabControl1.SelectedIndex = 0;
            this.kryptonTabControl1.Size = new System.Drawing.Size(1243, 554);
            this.kryptonTabControl1.TabIndex = 6;
            this.kryptonTabControl1.UseExtendedLayout = false;
            this.kryptonTabControl1.SelectedIndexChanged += new System.EventHandler(this.kryptonTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TaskActiveDGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1235, 525);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = false;
            this.tabPage1.Text = "Active Tasks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TaskActiveDGV
            // 
            this.TaskActiveDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskActiveDGV.Location = new System.Drawing.Point(0, 0);
            this.TaskActiveDGV.Name = "TaskActiveDGV";
            this.TaskActiveDGV.Size = new System.Drawing.Size(1235, 525);
            this.TaskActiveDGV.TabIndex = 0;
            this.TaskActiveDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TaskActiveDGV_CellDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TaskClosedDGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1235, 525);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = false;
            this.tabPage2.Text = "Closed Tasks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TaskClosedDGV
            // 
            this.TaskClosedDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskClosedDGV.Location = new System.Drawing.Point(0, 0);
            this.TaskClosedDGV.Name = "TaskClosedDGV";
            this.TaskClosedDGV.Size = new System.Drawing.Size(1235, 525);
            this.TaskClosedDGV.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TaskCancDGV);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1235, 525);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = false;
            this.tabPage3.Text = "Cancelled Tasks";
            // 
            // TaskCancDGV
            // 
            this.TaskCancDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskCancDGV.Location = new System.Drawing.Point(0, 0);
            this.TaskCancDGV.Name = "TaskCancDGV";
            this.TaskCancDGV.Size = new System.Drawing.Size(1235, 525);
            this.TaskCancDGV.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(129, 564);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "kryptonLabel1";
            // 
            // TaskOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 592);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.kryptonTabControl1);
            this.Controls.Add(this.CreateTsk_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.cancel_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TaskOverview";
            this.Text = "TaskOverview";
            this.Load += new System.EventHandler(this.TaskOverview_Load);
            this.kryptonTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskActiveDGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskClosedDGV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskCancDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonButton cancel_btn;
        private Krypton.Toolkit.KryptonButton Ok_btn;
        private Krypton.Toolkit.KryptonButton CreateTsk_btn;
        private Krypton.Toolkit.Suite.Extended.Navigator.KryptonTabControl kryptonTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Krypton.Toolkit.KryptonDataGridView TaskActiveDGV;
        private Krypton.Toolkit.KryptonDataGridView TaskClosedDGV;
        private Krypton.Toolkit.KryptonDataGridView TaskCancDGV;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}