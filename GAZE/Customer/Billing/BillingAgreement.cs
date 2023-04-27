using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.Security;
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

namespace GAZE.Customer.Billing
{
    public partial class BillingAgreement : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        #endregion
        public BillingAgreement()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Billing Agreement - CustomerID:" + InfoSec.GlobalCustomerID);
            
        }

        private void BillingAgreement_Load(object sender, EventArgs e)
        {
            kryptonButton1.Enabled = false;
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox1.CheckState == CheckState.Checked)
            {
                kryptonButton1.Enabled = true;
            }
            else
            {
                kryptonButton1.Enabled = false;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SQLBilling.UpdateBankingDetails();
            this.Close();
            Banking.accnum = null;
            Banking.sortcode = null;

            
        }

        private void BillingAgreement_FormClosing(object sender, FormClosingEventArgs e)
        {
            CustomerOverViewV1 customerOverViewV1 = new CustomerOverViewV1();
            customerOverViewV1.ExecuteCustomerLoad();
        }
    }
}
