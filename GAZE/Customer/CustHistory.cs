using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustHistory : KryptonForm
    {

        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        CustomerHistory CustomerHistory = new CustomerHistory();
        CustomerLogic CustomerLogic = new CustomerLogic();
        #endregion

        public CustHistory()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Customer History - CustomerID:" + InfoSec.GlobalCustomerID);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
        }

        private void CustomerHistory_Load(object sender, EventArgs e)
        {
            CustomerHistory.GetCustomerAddressHistory(addressHis_dgv);
            CustomerHistory.GetCustomerPolicyHistory(PolicyHis_dgv);
            CustomerHistory.GetCustomerContactHistory(contactHis_dgv);
            CustomerHistory.GetCustomerBillingHistory(billingH_dgv);
            CustomerLogic.GetCustomerHistoryDetails(CustName_txt, CustID_txt, PolCount_txt);
        }

        private void kryptonGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonGroupBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
