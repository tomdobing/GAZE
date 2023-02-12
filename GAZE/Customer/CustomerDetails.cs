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
    public partial class CustomerDetails : Form
    {
        readonly FormSettings FormSettings = new FormSettings();
        readonly CustomerManagement customerManagement = new CustomerManagement();

        public CustomerDetails()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, Name);
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            
            
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            CustID_lbl.Text = "Customer ID " + InfoSec.GlobalCustomerID;
            customerManagement.GetCustomerDetails(title_txt, Firstname_txt, Surname_txt,
                Dob_txt, contact_txt, Altcnt_txt, email_txt);

            if (Altcnt_txt.Text == "")
            {
                Altcnt_txt.Text = "NULL";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
              

            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
               
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            CustID_lbl.Text = "Customer ID " + InfoSec.GlobalCustomerID;
            customerManagement.GetCustomerDetails(title_txt, Firstname_txt, Surname_txt,
                Dob_txt, contact_txt, Altcnt_txt, email_txt);

            checkBox1.CheckState = CheckState.Unchecked;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
