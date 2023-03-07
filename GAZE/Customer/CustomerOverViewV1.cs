using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerOverViewV1 : Form
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        #endregion
        public CustomerOverViewV1()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "INDEV - Customer Overview - CustomerID:");
        }

        private void CustomerOverViewV1_Load(object sender, EventArgs e)
        {
            CustomerManagement.GetCustomerPoliciesForOverview(metroGrid1);
            Thread.Sleep(1000);
            CustomerManagement.GetCustomerOverViewV1(CustName_txt, CustTitle_txt, FName_txt, CSurname_txt, CDOB_txt, ContactNum_txt, AltCont_txt, EmailAddress_txt,
            addrL1_txt, AddrL2_txt, Town_txt, postalcode_txt, country_txt, PolicyID_txt, PolStatus_lbl, ProdName_txt, ProdDesc_txt, ProdPrice_txt, ProdActDate_txt,
            CustID_txt);
        }
    }
}
