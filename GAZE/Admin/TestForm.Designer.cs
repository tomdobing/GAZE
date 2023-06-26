namespace GAZE.Admin
{
    partial class TestForm
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
            this.kryptonRibbon1 = new Krypton.Ribbon.KryptonRibbon();
            this.Tasks = new Krypton.Ribbon.KryptonRibbonTab();
            this.Customer = new Krypton.Ribbon.KryptonRibbonTab();
            this.Policy = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup1 = new Krypton.Ribbon.KryptonRibbonGroup();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonRibbon1
            // 
            this.kryptonRibbon1.InDesignHelperMode = true;
            this.kryptonRibbon1.Name = "kryptonRibbon1";
            this.kryptonRibbon1.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] {
            this.Customer,
            this.Tasks,
            this.Policy});
            this.kryptonRibbon1.SelectedContext = null;
            this.kryptonRibbon1.SelectedTab = this.Customer;
            this.kryptonRibbon1.Size = new System.Drawing.Size(1135, 143);
            this.kryptonRibbon1.TabIndex = 0;
            // 
            // Tasks
            // 
            this.Tasks.Text = "Tasks";
            // 
            // Customer
            // 
            this.Customer.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1});
            this.Customer.Text = "Customer";
            // 
            // Policy
            // 
            this.Policy.Text = "Policy";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 496);
            this.Controls.Add(this.kryptonRibbon1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private Krypton.Ribbon.KryptonRibbonTab Tasks;
        private Krypton.Ribbon.KryptonRibbonTab Customer;
        private Krypton.Ribbon.KryptonRibbonTab Policy;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
    }
}