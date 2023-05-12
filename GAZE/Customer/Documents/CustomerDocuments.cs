using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using GAZE.BusinessLogic.DocumentManagement;
using System.Windows.Forms;

namespace GAZE.Customer.Documents
{
    public partial class CustomerDocuments : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        CustCallBack CustCallBack = new CustCallBack();
        ControlManagement ControlManagement = new ControlManagement();
        NoteManagement NoteManagement = new NoteManagement();
        DocumentRetrieval DocumentRetrieval = new DocumentRetrieval();
        #endregion

        public CustomerDocuments()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Customer Documents - CustomerID:" + InfoSec.GlobalCustomerID);
            FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            kryptonHeader1.Values.Description = "CustomerID: " + InfoSec.GlobalCustomerID;
        }

        private void CustomerDocuments_Load(object sender, EventArgs e)
        {
            DocumentRetrieval.GetCustomerDocuments(kryptonDataGridView1);
        }

        
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            DataGridViewRow selectedRow = kryptonDataGridView1.Rows[selectedRowIndex];

            int rowID = Convert.ToInt32(selectedRow.Cells["DocumentID"].Value);
            DocumentRetrieval.ValidateFilePath(rowID);
        }
    }
}
