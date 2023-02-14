using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using MetroFramework.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerOverview : Form
    {
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        InfoSec InfoSec = new InfoSec();
        public CustomerOverview()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer");
        }


        private void CustomerOverview_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Customer ID: " + InfoSec.GlobalCustomerID;
            foreach (MetroFramework.Controls.MetroTextBox item in  groupBox1.Controls.OfType<MetroFramework.Controls.MetroTextBox>())
            {
                item.ReadOnly = true;
            }
            foreach (MetroFramework.Controls.MetroTextBox item in groupBox2.Controls.OfType<MetroFramework.Controls.MetroTextBox>())
            {
                item.ReadOnly = true;
            }
            metroCheckBox1.Enabled = false;
            CustomerManagement.GetCustomerOverview(title_txt, firstname_txt, surname_txt, dob_txt, ContactNmb_txt, AltContact_txt, EmailAddr_txt,metroCheckBox1,
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
    }
}
