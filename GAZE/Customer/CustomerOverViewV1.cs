using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.ComponentModel;
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
        SQLBilling SQLBilling = new SQLBilling();
        #endregion
        public CustomerOverViewV1()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "INDEV - Customer Overview - CustomerID:" + InfoSec.GlobalCustomerID);
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
                addrL1_txt, AddrL2_txt, Town_txt, postalcode_txt, country_txt, PolicyID_txt, PolStatus_lbl, DeactReas_txt, PolEffStart_txt, PolEndDate_txt,discount_txt, ProdName_txt, ProdDesc_txt
                , ProdActDate_txt, CustID_txt, ProdEndDate_txt, PolID_Txt, StatID_txt);

            CustomerManagement.GetCustomerOverviewNote(kryptonTextBox1);

            SQLBilling.GetOverviewBillingDetails(BillingID_txt, bilRef_txt,BillingType_txt, BillingFreq_txt, Yearly_txt, 
                                                MTotal_txt,billingstatus_txt, accountNum_txt, 
                                                sortcode_txt, NextBillDay_txt );

            metroTabControl1.SelectedTab = metroTabPage1;
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

        }

        private void deleteNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string message = "Are you sure you wish to delete this Customers overview note?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {
                CustomerManagement.RemoveOverviewNote();
                //Application.Exit();
            }
            if (result == DialogResult.No)
            {
                return;
            };
        }

        private void viewBillingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cancelBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you wish to cancel this customers Billing Account? \n\nThe Customer will need to provide their banking information" +
                " again in order to reactivate and continue with their product!";
            string caption = "Are you sure?";
            
            DialogResult result;

            result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {
                SQLBilling.CancelCustomerBilling();
                this.Close();
                //Application.Exit();
            }
            if (result == DialogResult.No)
            {
                return;
            };
        }

        private void editBillingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing.UpdateBankingDetails updateBankingDetails = new Billing.UpdateBankingDetails();
            updateBankingDetails.ShowDialog();
        }
    }
}
