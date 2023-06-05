using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using System;
using System.Threading;

namespace GAZE.Customer.Tasks
{
    public partial class OpenTask : KryptonForm
    {
        #region Declarations
        readonly FormSettings FormSettings = new FormSettings();
        readonly InfoSec InfoSec = new InfoSec();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly SQLManagement PolicySQLManagement = new SQLManagement();
        readonly HomePage HomePage = new HomePage();
        readonly SQLBilling SQLBilling = new SQLBilling();
        readonly ControlManagement ControlManagement = new ControlManagement();
        readonly NoteManagement NoteManagement = new NoteManagement();
        readonly DataLayer DataLayer = new DataLayer();
        readonly NoteDataLayer noteDataLayer = new NoteDataLayer();
        #endregion

        public OpenTask()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Task Overview - TaskID:" + InfoSec.GlobalTaskID);
            FormSettings.SetFormSettings(this);
            DataLayer.GetCustomerOpenTaskCount(OpnTskCnt_txt);
            DataLayer.GetCustomerIDAndTaskDescriptionForOverview(custid_txt, tskdesc_txt);
            noteDataLayer.PopulateTaskOpenTaskNoteDataGrid(kryptonDataGridView1);
        }

        private void OpenTask_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            noteDataLayer.PopulateControlsFromSelectedNOte(noteDesc_txt, noteDet_txt, creatdte_lbl, creatby_lbl);
        }
    }
}
