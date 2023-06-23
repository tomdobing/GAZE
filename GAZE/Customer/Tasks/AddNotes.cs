using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZE.Customer.Tasks
{
    public partial class AddNotes : KryptonForm
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
        readonly TaskControlAdmin taskControlAdmin = new TaskControlAdmin();
        #endregion
        public AddNotes()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Task Overview - TaskID:" + InfoSec.GlobalTaskID);
            //FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
        }

        private void AddNotes_Load(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DataLayer.UpdateTaskStatusToPending(this, kryptonRichTextBoxExtended1);
        }
    }
}
