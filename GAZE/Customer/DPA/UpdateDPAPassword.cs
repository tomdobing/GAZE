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

namespace GAZE.Customer.DPA
{
    public partial class UpdateDPAPassword : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        CustomerLogic CustomerLogic = new CustomerLogic();
        SQLDataAdmin SQLDataAdmin = new SQLDataAdmin();
        ControlAccessHelper ControlAccessHelper = new ControlAccessHelper();
        DataProtection DataProtection = new DataProtection();
        #endregion

        #region Methods
        public UpdateDPAPassword()
        {
            InitializeComponent();
            buildFormandSettings();
        }

        private void UpdateDPAPassword_Load(object sender, EventArgs e)
        {
            custinf_lbl.Text = "CustomerID: " + InfoSec.GlobalCustomerID;

        }





        #endregion

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DataProtection.UpdateCustomersDPAPassword(newPass_txt.Text);
        }

        private void buildFormandSettings()
        {
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "INDEV - Customer Overview - CustomerID:" + InfoSec.GlobalCustomerID);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            DataProtection.GetCustomersPassword(currPass_txt);
            currPass_txt.ReadOnly = true;


        }
    }
}
