using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerOverViewV1 : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        #endregion
        public CustomerOverViewV1()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "INDEV - Customer Overview - CustomerID:");
            this.Palette = HomePage.kryptonManager1.GlobalPalette;

            foreach (MetroTabPage tab in metroTabControl1.TabPages)
            {
                foreach (KryptonTextBox control1 in tab.Controls.OfType<KryptonTextBox>())
                {
                    control1.PaletteMode = PaletteMode.SparklePurpleDarkMode;
                    control1.ReadOnly = true;
                }
                foreach (KryptonMaskedTextBox item in tab.Controls.OfType<KryptonMaskedTextBox>())
                {
                    item.PaletteMode = PaletteMode.SparklePurpleDarkMode;
                    item.ReadOnly = true;
                }
            }

        }

        private void CustomerOverViewV1_Load(object sender, EventArgs e)
        {
            CustomerManagement.GetCustomerPoliciesForOverview(metroGrid1);
            Thread.Sleep(1000);
            CustomerManagement.GetCustomerOverViewV1(CustName_txt, CustTitle_txt, FName_txt, CSurname_txt, CDOB_txt, ContactNum_txt, AltCont_txt, EmailAddress_txt,
                addrL1_txt, AddrL2_txt, Town_txt, postalcode_txt, country_txt, PolicyID_txt, PolStatus_lbl, DeactReas_txt, PolEffStart_txt, PolEndDate_txt, ProdName_txt, ProdDesc_txt
                , ProdPrice_txt, ProdActDate_txt, CustID_txt, ProdEndDate_txt, PolID_Txt, StatID_txt);

        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (metroGrid1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = metroGrid1.SelectedRows[0];
                string PolicyID = selectedRow.Cells["PolicyID"].Value.ToString();
                InfoSec.GlobalSelectedPolicyID = PolicyID;
                PolicySQLManagement.GetPolicyDataViaPolicyID(CustName_txt, CustTitle_txt, FName_txt, CSurname_txt, CDOB_txt, ContactNum_txt, AltCont_txt, EmailAddress_txt,
                addrL1_txt, AddrL2_txt, Town_txt, postalcode_txt, country_txt, PolicyID_txt, PolStatus_lbl,DeactReas_txt, PolEffStart_txt, PolEndDate_txt ,ProdName_txt, ProdDesc_txt
                , ProdPrice_txt, ProdActDate_txt,CustID_txt, ProdEndDate_txt, PolID_Txt, StatID_txt);



            }
            
        }

        private void changePolicyPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverridePolicyPrice overridePolicyPrice = new OverridePolicyPrice();
            overridePolicyPrice.ShowDialog();
        }
    }
}
