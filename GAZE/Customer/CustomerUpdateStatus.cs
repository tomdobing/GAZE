using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
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
    public partial class CustomerUpdateStatus : Form
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
               messageHandler.ReturnInfoBox("Note cannot be empty \n\nYou must enter a note!!", 
                   InfoBox.InformationBoxButtons.OK,
                   InfoBox.InformationBoxIcon.Exclamation);
                return;
            }
            
            CustomerManagement.SetCustomerStatus(newStatus_cmb, note_txt.Text);
            Close();
        }
    }
}
