using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
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

namespace GAZE.Customer
{
    public partial class CustomerUpdateStatus : KryptonForm
    {
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly InfoSec InfoSec = new InfoSec();
        readonly MessageHandler messageHandler = new MessageHandler();
        readonly ControlManagement controlManagement = new ControlManagement();
        public CustomerUpdateStatus()
        {
            InitializeComponent();
            formSettings.ChangeableFormSettings(this, Name);
            formSettings.SetFormSettings(this);
        }

        private void CustomerUpdateStatus_Load(object sender, EventArgs e)
        {
            metroLabel1.Text = "Customer ID: " + InfoSec.GlobalCustomerID;
            controlManagement.PopulateStatus(newStatus_cmb);
            CustomerManagement.GetCustomerStatus(CurrStatus_txt);
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(note_txt.Text))
            {
                KryptonMessageBox.Show("Note cannot be empty \n\nYou must enter a note!!", "Validation Failure!",
                    MessageBoxButtons.OK, KryptonMessageBoxIcon.Exclamation, 0, 0, false, false, false, false, null);

                return;
            }
            
            CustomerManagement.SetCustomerStatus(newStatus_cmb, note_txt.Text);
            Close();
        }
    }
}
