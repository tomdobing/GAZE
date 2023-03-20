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
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.PolicyManagement;

namespace GAZE.Customer
{
    public partial class OverridePolicyPrice : KryptonForm
    {

        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        SQLManagement PolicySQLManagement = new SQLManagement();

        public OverridePolicyPrice()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "ADMIN - Override Policy Price");
            FormSettings.SetFormSettings(this);
            kryptonLabel3.Text = "PolicyID: " + InfoSec.GlobalSelectedPolicyID;
            

        }

        private void OverridePolicyPrice_Load(object sender, EventArgs e)
        {
            //PolicySQLManagement.GetCurrentPolicyPrice(CurrPolPri_txt);
            PolicySQLManagement.GetCurrentPolicyPrice(CurrPolPri_txt);

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewPolPri_txt.Text))
            {
                KryptonMessageBox.Show("The new Policy Price cannot be null. Please check and try again!", "Validation Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            PolicySQLManagement.UpdatePolicyPrice(NewPolPri_txt);
            PolicySQLManagement.InsertPolicyOverrideNote(CurrPolPri_txt, NewPolPri_txt);
        }
    }
}
