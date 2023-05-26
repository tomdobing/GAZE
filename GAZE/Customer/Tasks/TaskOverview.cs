using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using System;

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

        }

        private void TaskOverview_Load(object sender, EventArgs e)
        {

        }
    }
}
