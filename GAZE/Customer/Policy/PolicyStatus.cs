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

namespace GAZE.Customer.Policy
{
    public partial class PolicyStatus : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        ControlManagement ControlManagement = new ControlManagement();
        #endregion

        #region Methods
        public PolicyStatus()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Policy Cancellation - CustomerID:" + InfoSec.GlobalCustomerID);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            this.ControlBox = false;
            ControlManagement.PopulatePolicyStatus(newPolStat_cmb);
        }

        private void PolicyStatus_Load(object sender, EventArgs e)
        {
            CurrPolStatus_txt.ReadOnly = true;
            PolicySQLManagement.GetCurrentPolicyStatus(CurrPolStatus_txt);
        }





        #endregion

        private void kryptonGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            this.Close();
            CustomerOverViewV1 customerOverViewV1 = new CustomerOverViewV1();
            customerOverViewV1.ExecuteCustomerLoad();
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PolicyStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            CustomerOverViewV1 customerOverViewV1  = new CustomerOverViewV1();
            customerOverViewV1.ExecuteCustomerLoad();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (CurrPolStatus_txt.Text == newPolStat_cmb.SelectedText)
            {
                KryptonMessageBox.Show("This customers Policy Status is already " + CurrPolStatus_txt.Text + "\n\nPlease try again",
                   "Unable to set Status", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            if (newPolStat_cmb.SelectedIndex == -1)
            {
                KryptonMessageBox.Show("You have not selected a status to update.\n\nPlease check and try again",
                 "Unable to set Status", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            PolicySQLManagement.UpdateCustomerPolicyStatus(newPolStat_cmb, this);
        }
    }
}
