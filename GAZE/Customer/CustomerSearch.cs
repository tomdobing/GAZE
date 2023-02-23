using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerSearch : Form
    {
        readonly InfoSec infoSec = new InfoSec();
        readonly FormSettings FormSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly MessageHandler messageHandler = new MessageHandler();
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

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchNum_txt.Text) && SearchNum_txt.Text.Length <= 10)
            {
                InfoBox.InformationBox.Show("Invalid search Criteria \n\n Please check and try again", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Exclamation, InfoBox.InformationBoxStyle.Modern, InfoBox.InformationBoxBehavior.Modal);
                
                return;
            }
            if (CustomerManagement.CustomerSearchIfExists(SearchNum_txt.Text) == false)
            {
                InfoBox.InformationBox.Show("Customer Not Found!!\n\n\nPlease check and try again. This customer may not be registered", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Exclamation, InfoBox.InformationBoxStyle.Modern);
                
                return;
            }
            CustomerManagement.GetCustomerDataByContactNumber(SearchNum_txt.Text, metroGrid1);

        }

        private void metroGrid2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedRow = metroGrid1.Rows[selectedRowIndex];
                int rowID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
                InfoSec.GlobalCustomerID = rowID.ToString();
                metroLabel2.Text = "CustomerID: " + InfoSec.GlobalCustomerID;
                Thread.Sleep(3000);
                CustomerOverview customerOverview = new CustomerOverview();
                customerOverview.ShowDialog();
            }
            catch (Exception ex)
            {
                messageHandler.ReturnInfoBox(ex.Message, InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Hand);
                return;
            }
   

        }

        private void CustomerSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    metroButton2.PerformClick();
            //}
        }
    }
}

