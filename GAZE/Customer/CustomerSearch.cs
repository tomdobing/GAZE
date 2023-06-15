using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerSearch : KryptonForm
    {
        readonly InfoSec infoSec = new InfoSec();
        readonly FormSettings FormSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly MessageHandler messageHandler = new MessageHandler();
        SQLManagement SQLManagement = new SQLManagement();
        readonly CustomerLogic customerLogic = new CustomerLogic();
        HomePage HomePage = new HomePage();
        public CustomerSearch()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, Name);
            Palette = HomePage.kryptonManager1.GlobalPalette;

        }




        private void CustomerSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoSec.GlobalCustomerID = null;
        }


        private void metroButton4_Click(object sender, EventArgs e)
        {
        }

        private void CustomerSearch_Load_1(object sender, EventArgs e)
        {
            this.ActiveControl = searchPolID_txt;

            //SearchNum_txt.Enabled = false;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (SQLManagement.CheckIfPolicyIDExists(searchPolID_txt.Text) == false)
            {
                KryptonMessageBox.Show("Policy Not Found!!\n\n\nPlease check and try again.", "Not Found", MessageBoxButtons.OK, KryptonMessageBoxIcon.Exclamation, 0, 0, false, false, false, false, null);
                return;
            }

            CustomerManagement.GetCustomerPoliciesByPolicyID(searchPolID_txt.Text, kryptonDataGridView1);

        }


        private void CustomerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    metroButton2.PerformClick();
            //}
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CustomerManagement.GetCustomerPoliciesByPolicyID(searchPolID_txt.Text, kryptonDataGridView1);
            if (SQLManagement.CheckIfPolicyIDExists(searchPolID_txt.Text) == false)
            {
                KryptonMessageBox.Show(this, "Policy Not Found!!\n\n\nPlease check and try again.",
                                             "Not Found", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error,
                                              KryptonMessageBoxDefaultButton.Button3, 0, false, false);


                return;
            }

        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedRow = kryptonDataGridView1.Rows[selectedRowIndex];

                int rowID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
                InfoSec.GlobalCustomerID = rowID.ToString();


                int rowid = Convert.ToInt32(selectedRow.Cells["PolicyID"].Value);
                InfoSec.GlobalSelectedPolicyID = rowid.ToString();
                if (customerLogic.CheckForAccountAccessRestrictions() == true)
                {
                    searchPolID_txt.Focus();
                    return;
                }
                CustomerOverViewV1 customerOverViewV1 = new CustomerOverViewV1();
                customerOverViewV1.ShowDialog();

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(this, ex.Message, "Failed to open Customer Account", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return;
            }
        }

        private void searchPolID_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchPolID_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

