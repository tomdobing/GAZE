using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerOverview : KryptonForm
    {
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        InfoSec InfoSec = new InfoSec();
        RoleManagement RoleManagement = new RoleManagement();
        MessageHandler MessageHandler = new MessageHandler();

        public CustomerOverview()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer");
            metroToolTip1.SetToolTip(title_txt, "Customer Title");
        }


        private void CustomerOverview_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Customer ID: " + InfoSec.GlobalCustomerID;
            foreach (MetroFramework.Controls.MetroTextBox item in groupBox1.Controls.OfType<MetroFramework.Controls.MetroTextBox>())
            {
                item.ReadOnly = true;
            }
            foreach (MetroFramework.Controls.MetroTextBox item in groupBox2.Controls.OfType<MetroFramework.Controls.MetroTextBox>())
            {
                item.ReadOnly = true;
            }
            metroCheckBox1.Enabled = false;
            CustomerManagement.GetCustomerOverview(title_txt, firstname_txt, surname_txt, dob_txt, ContactNmb_txt, AltContact_txt, EmailAddr_txt, metroCheckBox1,
                                                   AddrL1_txt, AddrL2_txt, Town_txt, Postalcode_txt, country_txt, toolStripLabel2);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InfoSec.GlobalCustomerID = null;
            Thread.Sleep(2500);
            this.Close();
        }

        private void viewNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerNotes customerNotes = new CustomerNotes();
            customerNotes.ShowDialog();
        }

        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCustomerNote newCustomerNote = new NewCustomerNote();
            newCustomerNote.ShowDialog();
        }

        private void setCustomerStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RoleManagement.DisableNonAdminControls() == false)
            {
                KryptonMessageBox.Show("You are not Authorized to set the customer Status.\n\nPlease Contact a manager to change the status", "Unauthorised User - Access Denied!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Stop, 0, 0, false, false, false, false, null);
            }
            else
            {
                CustomerUpdateStatus status = new CustomerUpdateStatus();
                status.ShowDialog();
            }

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails();
            updateCustomerDetails.ShowDialog();
        }

        private void title_txt_MouseHover(object sender, EventArgs e)
        {

        }

        private void customerDetailsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerHistory customerHistory = new CustomerHistory();
            customerHistory.ShowDialog();
        }
    }
}
