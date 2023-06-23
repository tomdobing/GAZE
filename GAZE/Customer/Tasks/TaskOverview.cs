using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using System;
using System.Windows.Forms;

namespace GAZE.Customer.Tasks
{
    public partial class TaskOverview : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        ControlManagement ControlManagement = new ControlManagement();
        NoteManagement NoteManagement = new NoteManagement();
        DataLayer DataLayer = new DataLayer();
       
        #endregion

        public TaskOverview()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Task Overview - CustomerID:" + InfoSec.GlobalCustomerID);
            FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            DataLayer.PopulateActiveTasksForCustomer(TaskActiveDGV);
            DataLayer.PopulateClosedTasksForCustomer(TaskClosedDGV);
            DataLayer.PopulateCancelledTasksForCustomer(TaskCancDGV);
            
        }

        private void TaskOverview_Load(object sender, EventArgs e)
        {
            kryptonLabel1.Text = "Double Click on the record you wish to open!";
            kryptonLabel1.LabelStyle = LabelStyle.BoldControl;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {


        }

        private void CreateTsk_btn_Click(object sender, EventArgs e)
        {
            _currentWindow _CurrentWindow = new _currentWindow();
            _CurrentWindow.ShowDialog();
        }

        private void kryptonTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (kryptonTabControl1.SelectedTab == tabPage1)
            //{
            //    kryptonButton1.Enabled = true;
            //}
            //else
            //{
            //    kryptonButton1.Enabled = false;
            //}
        }




        private void TaskActiveDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectedRowIndex = e.RowIndex;
                DataGridViewRow selectedRow = TaskActiveDGV.Rows[selectedRowIndex];

                int rowID = Convert.ToInt32(selectedRow.Cells["CustomerTaskID"].Value);
                InfoSec.GlobalTaskID = rowID.ToString();
                OpenTask OpenTask = new OpenTask();
                OpenTask.ShowDialog();
                //MessageBox.Show(InfoSec.GlobalTaskID);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(this, ex.Message, "Failed to open Task Record", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                throw;
            }

        
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
