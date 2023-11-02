using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerSearch : KryptonForm
    {
        private readonly InfoSec infoSec = new InfoSec();
        private readonly FormSettings FormSettings = new FormSettings();
        private readonly CustomerManagement CustomerManagement = new CustomerManagement();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private readonly SQLManagement SQLManagement = new SQLManagement();
        private readonly CustomerLogic customerLogic = new CustomerLogic();
        private readonly HomePage HomePage = new HomePage();
        public CustomerSearch()
        {
            InitializeComponent();
            polID_chkbx.CheckedChanged += HandleCheckboxCheck;
            custID_chk.CheckedChanged += HandleCheckboxCheck;
            ExecuteFormLoad();
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
            ActiveControl = searchPolID_txt;


        }

        private void HandleCheckboxCheck(object sender, EventArgs e)
        {
            KryptonCheckBox currcheckbox = (KryptonCheckBox)sender;
            if (currcheckbox.Checked)
            {
                if (currcheckbox == polID_chkbx)
                {
                    custID_chk.Checked = false;
                }
                else if (currcheckbox == custID_chk)
                {
                    polID_chkbx.Checked = false;
                }
            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (SQLManagement.CheckIfPolicyIDExists(searchPolID_txt.Text, custIDSrch_txt.Text) == true)
            {
                if (polID_chkbx.CheckState == CheckState.Checked)
                {

                    CustomerManagement.GetCustomerPoliciesByPolicyID(searchPolID_txt.Text, kryptonDataGridView1);
                }
                else if (custID_chk.CheckState == CheckState.Checked)
                {
                    CustomerManagement.GetCustomerPoliciesByCustomerID(custIDSrch_txt.Text, kryptonDataGridView1);

                }
                else
                {
                    KryptonMessageBox.Show(this, "Search Error: \n\nNo Search criteria has been specified. Please check and try again",
                                                 "Not Found", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                }

                Cursor = Cursors.Default;

            }
            else
            {
                KryptonMessageBox.Show(this, "Search Error: \n\nPolicy Not Found. Please check the policy number and search again.",
                                          "Search Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Cursor = Cursors.WaitCursor;
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
                Cursor = Cursors.Default;
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

        private void ExecuteFormLoad()
        {
            foreach (KryptonCheckBox CheckBoxes in groupBox1.Controls.OfType<KryptonCheckBox>())
            {
                CheckBoxes.CheckState = CheckState.Unchecked;

            }
            foreach (KryptonTextBox TextBoxes in groupBox1.Controls.OfType<KryptonTextBox>())
            {
                TextBoxes.Enabled = false;
            }
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "G.A.Z.E - Customer Search");
            Palette = HomePage.kryptonManager1.GlobalPalette;


        }

        private void polID_chkbx_CheckStateChanged(object sender, EventArgs e)
        {
            if (polID_chkbx.CheckState == CheckState.Checked)
            {
                searchPolID_txt.Enabled = true;
            }
            else
            {
                searchPolID_txt.Enabled = false;
                searchPolID_txt.Clear();
            }
        }

        private void custID_chk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void custID_chk_CheckStateChanged(object sender, EventArgs e)
        {
            if (custID_chk.CheckState == CheckState.Checked)
            {
                custIDSrch_txt.Enabled = true;
            }
            else
            {
                custIDSrch_txt.Enabled = false;
                custIDSrch_txt.Clear();
            }
        }

        private void custIDSrch_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void polID_chkbx_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

