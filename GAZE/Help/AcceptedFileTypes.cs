using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using GAZE.BusinessLogic.DocumentManagement;
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

namespace GAZE.Help
{
    public partial class AcceptedFileTypes : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        CustCallBack CustCallBack = new CustCallBack();
        CustomerLogic CustomerLogic = new CustomerLogic();
        DocumentRetrieval DocumentRetrieval = new DocumentRetrieval();
        #endregion

        #region Methods
        public AcceptedFileTypes()
        {
            InitializeComponent();
            DocumentRetrieval.GetAcceptableFileTypesForHelpPage(kryptonDataGridView1);
        }

        private void AcceptedFileTypes_Load(object sender, EventArgs e)
        {
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "HELP - Accepted File Types");
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
        }





        #endregion
    }
}
