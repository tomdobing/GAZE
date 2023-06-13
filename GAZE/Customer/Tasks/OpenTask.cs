using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Memory.Box;
using System;
using System.Drawing;
using System.Windows.Forms;

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
        readonly TaskControlAdmin taskControlAdmin = new TaskControlAdmin();
        #endregion

        public OpenTask()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Task Overview - TaskID:" + InfoSec.GlobalTaskID);
            FormSettings.SetFormSettings(this);
            Palette = HomePage.kryptonManager1.GlobalPalette;
            DataLayer.GetCustomerOpenTaskCount(OpnTskCnt_txt);
            DataLayer.GetCustomerIDAndTaskDescriptionForOverview(custid_txt, tskdesc_txt);
            noteDataLayer.PopulateTaskOpenTaskNoteDataGrid(kryptonDataGridView1);
            taskControlAdmin.PopulateTaskTypeCombobox(taskType_cmb);
            taskControlAdmin.PopulateUsernamesForAssignedTo(agent_cmb);
            taskControlAdmin.PopulatePriorities(taskPriority_cmb);
            taskDueDate_dtp.Format = DateTimePickerFormat.Custom;
            taskDueDate_dtp.CustomFormat = "dd/MM/yyyy HH:mm";
            taskDueDate_dtp.AutoShift = true;
            WarnLabel1.Hide();
            WarnLabel2.Hide();
            WarnLabel3.Hide();
            WarnLabel4.Hide();
            taskControlAdmin.PopulateTaskStatusCombobox(taskStatus_cmb);
            DataLayer.GetOpenedTaskDetailsForOverview(taskDescription_txt, taskType_cmb, taskDetails_rtxt, taskPriority_cmb, taskDueDate_dtp,
                                                        taskAttempts_txt, taskStatus_cmb, taskActive_chk, agent_cmb);
            
        }

        private void OpenTask_Load(object sender, EventArgs e)
        {
            if (taskActive_chk.CheckState == CheckState.Unchecked)
            {
                taskDetails_grp.Enabled = false;
                taskNotes_grp.Enabled = false;
                kryptonButton2.Enabled = false;
            }
            if (taskAttempts_txt.Text == "3" && taskActive_chk.CheckState == CheckState.Checked )
            {
                ShowWarnLabel1(WarnLabel1);
            }
            if (taskDueDate_dtp.Value <= DateTime.Now)
            {
                ShowWarnLabel2(WarnLabel2);
            }
            if (agent_cmb.SelectedIndex != 1)
            {
                ShowWarnLabel3(WarnLabel3);
            }
        }

        private void kryptonDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.SelectedCells.Count > 0)
            {

                //Thread.Sleep(2500);
                int rownum = kryptonDataGridView1.SelectedCells[0].RowIndex;
                noteDesc_txt.Text = kryptonDataGridView1.Rows[rownum].Cells[2].Value.ToString();
                noteDet_txt.Text = kryptonDataGridView1.Rows[rownum].Cells[3].Value.ToString();
                creatby_lbl.Text = "Created By: " + kryptonDataGridView1.Rows[rownum].Cells[4].Value.ToString();
                creatdte_lbl.Text = "Created Date: " + kryptonDataGridView1.Rows[rownum].Cells[5].Value.ToString();
                //Thread.Sleep(2000);
                //
            }
            
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = KryptonMessageBox.Show("Are you sure you wish to update the Attempted Tasks", "Contiue?",
                                        MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, 0, 0,
                                        false, false, false, false, null);
            if (dialogResult == DialogResult.Yes)
            {
                DataLayer.UpdateTaskAttempts();

            }
            else
            {
                return;
            }
        }

        private void updateStatus_btn_Click(object sender, EventArgs e)
        {
            AddNotes addNotes = new AddNotes();
            if (taskStatus_cmb.SelectedItem.ToString() == "Completed")
            {
                DataLayer.UpdateTaskStatusToCompleted(this);
            }
            if (taskStatus_cmb.SelectedItem.ToString() == "Cancelled")
            {
                
            }
            if (taskStatus_cmb.SelectedItem.ToString() == "Pending")
            {
                addNotes.ShowDialog();
                Close();
            }
            if (taskStatus_cmb.SelectedItem.ToString() == "Active")
            {

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Tasks.NewTaskNote newTaskNote = new Tasks.NewTaskNote();
            newTaskNote.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            
        }
        private void ShowWarnLabel1(Label Wanrlabel1)
        {
                Wanrlabel1.Show();
                Wanrlabel1.Text = "WARNING CALL - Task Attempted 3 Times";
                Wanrlabel1.ForeColor = Color.Orange;
               // Wanrlabel1.Font = new Font(Wanrlabel1.Font, FontStyle.Bold);
        }
        private void ShowWarnLabel2(Label Wanrlabel2)
        {
            Wanrlabel2.Show();
            Wanrlabel2.Text = "CRITICAL CALL - The Due Date Has Expired. Take Immediate Action";
            Wanrlabel2.ForeColor = Color.Red;
            //Wanrlabel2.Font = new Font(Wanrlabel2.Font, FontStyle.Bold);
        }
        private void ShowWarnLabel3(Label Wanrlabel3)
        {
            Wanrlabel3.Show();
            Wanrlabel3.Text = "WARNING CALL - Task Unassigned";
            Wanrlabel3.ForeColor = Color.Orange;
           // Wanrlabel3.Font = new Font(Wanrlabel3.Font, FontStyle.Bold);
           
        }

    }
}
