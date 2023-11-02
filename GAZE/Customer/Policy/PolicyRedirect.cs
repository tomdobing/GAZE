using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.Security.Management;
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
    public partial class PolicyRedirect : KryptonForm
    {
        #region Declarations
        readonly FormSettings FormSettings = new FormSettings();
        readonly InfoSec Infosec = new InfoSec();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly SQLManagement PolicySQLManagement = new SQLManagement();
        readonly HomePage HomePage = new HomePage();
        readonly SQLBilling SQLBilling = new SQLBilling();
        readonly CustomerLogic CustomerLogic = new CustomerLogic();
        readonly SQLDataAdmin SQLDataAdmin = new SQLDataAdmin();
        readonly ControlAccessHelper ControlAccessHelper = new ControlAccessHelper();
        readonly DataProtection DataProtection = new DataProtection();
        readonly ControlManagement ControlManagement = new ControlManagement();
        readonly PolicySecurity policySecurity = new PolicySecurity();
        #endregion

        public PolicyRedirect()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Policy ReDirect");
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            yes_chk.CheckedChanged += HandleCheckboxCheck;
            no_chk.CheckedChanged += HandleCheckboxCheck;
            ControlManagement.PopulateDepartment(department_cmb);
        }

        private void PolicyRedirect_Load(object sender, EventArgs e)
        {
            polID_txt.Text = InfoSec.GlobalSelectedPolicyID;
            policySecurity.GetPolicyReDirectDetails(department_cmb, message_txt, yes_chk, no_chk, this);
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Allows only one check box to be checked at 1 time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCheckboxCheck(object sender, EventArgs e)
        {
            KryptonCheckBox currcheckbox = (KryptonCheckBox)sender;
            if (currcheckbox.Checked)
            {
                if (currcheckbox == yes_chk)
                {
                    no_chk.Checked = false;
                }
                else if (currcheckbox == no_chk)
                {
                    yes_chk.Checked = false;
                }
            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //if (yes_chk.CheckState == CheckState.Checked)
            //{
            //    ///set policy redirect

            //}
            //if (no_chk.CheckState == CheckState.Checked)
            //{
            //    ///Remove policy redirect
            //}
            policySecurity.InsertPolicyReDirect(yes_chk, no_chk, polID_txt.Text, department_cmb, message_txt.Text, this);
        }
    }
}
