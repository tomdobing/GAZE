using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace GAZE.Customer.Callback
{
    public partial class RequestCallback : Krypton.Toolkit.KryptonForm
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
        CustCallBack CustCallBack = new CustCallBack();
        #endregion


        public RequestCallback()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Request New Callback - CustomerID:" + InfoSec.GlobalCustomerID);
        }

        private void RequestCallback_Load(object sender, EventArgs e)
        {
            CallbackDate_dtp.CustomFormat = "yyyy/dd/MM hh:mm tt";
            CallbackDate_dtp.Value = DateTime.Now;
            agent_txt.Text = InfoSec.GlobalUsername;
            CustCallBack.GetCustNameForCallBack(CustName_txt);
        }

        private void CallbackDate_dtp_Leave(object sender, EventArgs e)
        {

            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (CallbackDate_dtp.Value < DateTime.Now)
            {
                KryptonMessageBox.Show(this, "Callback Date Cannot Be In The Past! \n\nPlease change the date to in the future",
                                             "Invalid Date Specified", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning,
                                              KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return;
            }
            if (string.IsNullOrEmpty(CustName_txt.Text))
            {
                KryptonMessageBox.Show(this, "Callback Details Cannot Be Empty! \n\nPlease enter call back details to continue",
                                             "Invalid Details Specified", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning,
                                              KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return;
            }
            CustCallBack.NewCallBackRequest(CallbackDate_dtp, callbckdet_txt, this);
        }
    }
}
