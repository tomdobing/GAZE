using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using GAZE.Customer.Callback;
using GAZE.Customer.Notes;
using GAZE.Customer.Policy;
using GAZE.Policy;
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
        CustCallBack CustCallBack = new CustCallBack();
        RoleManagement RoleManagement = new RoleManagement();
        CustomerLogic CustomerLogic = new CustomerLogic();
        #endregion

        #region Methods
        public CustomerOverViewV1()
        {
            
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "INDEV - Customer Overview - CustomerID:" + InfoSec.GlobalCustomerID);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            //RoleManagement.RestrictedControls(this, "admin");
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
            if (CustCallBack.CheckCustomerActiveCallBacks() == false)
            {
                updateCallbackDateToolStripMenuItem.Enabled = false;
                cancelCallbackToolStripMenuItem.Enabled = false;
            }
            else
            {
                updateCallbackDateToolStripMenuItem.Enabled = true;
                cancelCallbackToolStripMenuItem.Enabled = true;
            }
            if (string.IsNullOrEmpty(kryptonTextBox1.Text))
            {
                updateOverviewNoteToolStripMenuItem.Enabled =false;
                deleteNoteToolStripMenuItem.Enabled = false;
            }

        }

        private void CustomerOverViewV1_Load(object sender, EventArgs e)
        {
            
           ExecuteCustomerLoad();
           InfoSec.InsertFootPrint();
        }

        public void ExecuteCustomerLoad()
        {
            CustomerManagement.GetCustomerPoliciesForOverview(metroGrid1);

            Thread.Sleep(1000);

            CustomerManagement.GetCustomerOverViewV1(CustName_txt, CustTitle_txt, FName_txt, CSurname_txt, CDOB_txt, ContactNum_txt, AltCont_txt, EmailAddress_txt,
                addrL1_txt, AddrL2_txt, Town_txt, postalcode_txt, country_txt, PolicyID_txt, PolStatus_lbl, DeactReas_txt, PolEffStart_txt, PolEndDate_txt, discount_txt, ProdName_txt, ProdDesc_txt
                , ProdActDate_txt, CustID_txt, ProdEndDate_txt, PolID_Txt, StatID_txt);

            CustomerManagement.GetCustomerOverviewNote(kryptonTextBox1);

            SQLBilling.GetOverviewBillingDetails(BillingID_txt, bilRef_txt, BillingType_txt, BillingFreq_txt, Yearly_txt,
                                                MTotal_txt, billingstatus_txt, accountNum_txt,
                                                sortcode_txt, NextBillDay_txt);

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
                ExecuteCustomerLoad();
                //Application.Exit();
            }
            if (result == DialogResult.No)
            {
                return;
            };
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
                ExecuteCustomerLoad();
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

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustHistory custHistory = new CustHistory();
            custHistory.ShowDialog();
        }

        private void requestNewCallbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CustCallBack.CheckCustomerActiveCallBacks() == true)
            {
                KryptonMessageBox.Show("This customer already has an active callback.\n\nOnly one active call back is allowed per customer", 
                    "Access Restricted", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, 0, 0, false, false, false, false, null);
                return;
            }
            Callback.RequestCallback requestCallback = new Callback.RequestCallback();
            requestCallback.ShowDialog();
        }

        private void updateCallbackDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCallBack updateCallBack = new UpdateCallBack();
            updateCallBack.ShowDialog();
        }
        #endregion

        private void cancelCallbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you wish to cancel this customer's callback request? You will need to request a new call back!";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {

                CustCallBack.CancelCustomerCallBack();
            }
        }


        private void addNewPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCustomerPolicy newCustomerPolicy = new NewCustomerPolicy();
            newCustomerPolicy.ShowDialog();
        }

        private void updatePolicyStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PolicyStatus policyStatus = new PolicyStatus();
            policyStatus.ShowDialog();
        }

        private void createNewNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNote newNote = new NewNote();
            newNote.ShowDialog();
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustNotes custNotes = new CustNotes();
            custNotes.ShowDialog();
        }
    }
}
