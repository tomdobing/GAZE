using Gaze.BusinessLogic.Config;
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
        HomePage HomePage = new HomePage();
        public CustomerSearch()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, Name);

        }




        private void CustomerSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoSec.GlobalCustomerID = null;
        }


        private void metroButton4_Click(object sender, EventArgs e)
        {
            CustomerOverview customerOverview = new CustomerOverview();
            customerOverview.ShowDialog();
        }

        private void CustomerSearch_Load_1(object sender, EventArgs e)
        {
            searchPolID_txt.Focus();

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
                CustomerOverViewV1 customerOverViewV1 = new CustomerOverViewV1();
                customerOverViewV1.ShowDialog();

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(this, ex.Message, "Login Failed", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return;
            }
        }
    }
}

