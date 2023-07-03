using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;
using System;

namespace GAZE.Customer.Tasks
{
    public partial class NewTaskNote : KryptonForm
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

        public NewTaskNote()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Add Task Note - TaskID:" + InfoSec.GlobalTaskID);
            FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
           noteDetails_rtb.MaxLength = 500;
        }

        private void NewTaskNote_Load(object sender, EventArgs e)
        {


        }

        private void kryptonRichTextBoxExtended1_TextChanged(object sender, EventArgs e)
        {
            int maxCharCount = 500;
            int remainingChar = maxCharCount - noteDetails_rtb.Text.Length;
            remChar_lbl.Text = "Remaining Characters:" + remainingChar;
        }

        private void ResetControls()
        {
            noteDes_txt.Clear();
            noteDetails_rtb.Clear();

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(noteDes_txt.Text))
            {
                KryptonMessageBox.Show("You must enter a value for the short description", "Validation Failure", System.Windows.Forms.MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(noteDetails_rtb.Text))
            {
                KryptonMessageBox.Show("You must enter a value for the note details", "Validation Failure", System.Windows.Forms.MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            noteDataLayer.InsertNewTaskNote(noteDes_txt.Text, noteDetails_rtb.Text, this);
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
