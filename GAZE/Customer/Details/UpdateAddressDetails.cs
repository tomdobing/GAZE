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

namespace GAZE.Customer.Details
{
    public partial class UpdateAddressDetails : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        HomePage HomePage = new HomePage();
        CustomerLogic CustomerLogic = new CustomerLogic();
        ControlManagement ControlManagement = new ControlManagement();
        #endregion


        public UpdateAddressDetails()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Update Address Details - CustomerID:" + InfoSec.GlobalCustomerID);
            Palette = HomePage.kryptonManager1.GlobalPalette;
        }

        private void UpdateAddressDetails_Load(object sender, EventArgs e)
        {
           ControlManagement.PopulateCountries(county_cmb);
           CustomerLogic.GetCustomerNameForUpdateAddress(kryptonLabel1);
           CustomerLogic.GetCustomerAddressForUpdateAddress(addrl1_txt, addrl2, town_txt, postalcode_txt, county_cmb);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CustomerLogic.UpdateCustomerAddressDetails(addrl1_txt.Text, addrl2.Text, town_txt.Text, 
                                                       postalcode_txt.Text, county_cmb.SelectedText);
        }
    }
}
