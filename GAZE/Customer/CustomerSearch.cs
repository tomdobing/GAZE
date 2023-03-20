using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.Threading;
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
                InfoBox.InformationBox.Show("Policy Not Found!!\n\n\nPlease check and try again.", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Exclamation, InfoBox.InformationBoxStyle.Modern);
                return;
            }

            CustomerManagement.GetCustomerPoliciesByPolicyID(searchPolID_txt.Text, kryptonDataGridView1);
            //if (!string.IsNullOrEmpty(SearchNum_txt.Text) && SearchNum_txt.Text.Length <= 10)
            //{
            //    InfoBox.InformationBox.Show("Invalid search Criteria \n\n Please check and try again", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Exclamation, InfoBox.InformationBoxStyle.Modern, InfoBox.InformationBoxBehavior.Modal);

            //    return;
            //}
            //if (CustomerManagement.CustomerSearchIfExists(SearchNum_txt.Text) == false)
            //{
            //    InfoBox.InformationBox.Show("Customer Not Found!!\n\n\nPlease check and try again. This customer may not be registered", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Exclamation, InfoBox.InformationBoxStyle.Modern);

            //    return;
            //}


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

