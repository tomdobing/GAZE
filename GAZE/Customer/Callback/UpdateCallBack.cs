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

namespace GAZE.Customer.Callback
{
    public partial class UpdateCallBack : KryptonForm
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

        public UpdateCallBack()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Update Callback - CustomerID:" + InfoSec.GlobalCustomerID);
        }

        private void UpdateCallBack_Load(object sender, EventArgs e)
        {
            CurrCallDate_dtp.Format = DateTimePickerFormat.Custom;
            CurrCallDate_dtp.CustomFormat = "yyyy/dd/MM hh:mm tt";
            CurrCallDate_dtp.Value = DateTime.Now;

            newcallbck_dtp.Format = DateTimePickerFormat.Custom;
            newcallbck_dtp.CustomFormat = "yyyy/dd/MM hh:mm tt";
            CustCallBack.GetCurrentCallBackForUpdate(CurrCallDate_dtp);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (newcallbck_dtp.Value < DateTime.Now)
            {
                KryptonMessageBox.Show(this, "Callback Date Cannot Be In The Past! \n\nPlease change the date to in the future",
                                             "Invalid Date Specified", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning,
                                              KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return;
            }
            CustCallBack.UpdateCallBackDate(newcallbck_dtp, this);

        }
    }
}
