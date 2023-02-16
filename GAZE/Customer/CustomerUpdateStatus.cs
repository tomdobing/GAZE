using Gaze.BusinessLogic.Config;
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
        public CustomerUpdateStatus()
        {
            InitializeComponent();
            formSettings.ChangeableFormSettings(this, Name);
            formSettings.SetFormSettings(this);
        }

        private void CustomerUpdateStatus_Load(object sender, EventArgs e)
        {
            metroLabel1.Text = "Customer ID: " + InfoSec.GlobalCustomerID;
            CustomerManagement.PopulateStatus(newStatus_cmb);
            CustomerManagement.GetCustomerStatus(CurrStatus_txt);
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CustomerManagement.SetCustomerStatus(newStatus_cmb);
        }
    }
}
