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

namespace GAZE.Customer.AdminControls
{
    public partial class ViewFootPrints : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        ControlManagement ControlManagement = new ControlManagement();
        NoteManagement NoteManagement = new NoteManagement();
        SecureConfig SecureConfig = new SecureConfig();
        #endregion

        public ViewFootPrints()
        {
            InitializeComponent();
            
            FormSettings.ChangeableFormSettings(this, "View Footprints - CustomerID:" + InfoSec.GlobalCustomerID);
            FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            SecureConfig.AdminPopulateNotesFootPrints(kryptonDataGridView1);
        }

        private void ViewFootPrints_Load(object sender, EventArgs e)
        {

        }
    }
}
