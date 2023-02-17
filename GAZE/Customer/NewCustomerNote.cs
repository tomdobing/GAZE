using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class NewCustomerNote : Form
    {

        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly InfoSec InfoSec = new InfoSec();

        public NewCustomerNote()
        {
            InitializeComponent();
            formSettings.ChangeableFormSettings(this, Name);
            formSettings.SetFormSettings(this);
        }

        private void NewCustomerNote_Load(object sender, EventArgs e)
        {
            CustID_txt.Text = InfoSec.GlobalCustomerID;
            CustID_txt.ReadOnly = true;
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            NoteDesc_txt.Text = string.Empty;
            NoteDetails_txt.Text = string.Empty;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Create_btn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            CustomerManagement.InsertNewCustomerNote(NoteDesc_txt.Text, NoteDetails_txt.Text,true ,this);
        }
    }
}
