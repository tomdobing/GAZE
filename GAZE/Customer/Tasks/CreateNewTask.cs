using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GAZE.Customer.Tasks
{
    public partial class _currentWindow : KryptonFormExtended
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
        TaskControlAdmin taskControlAdmin = new TaskControlAdmin();
        DataLayer DataLayer = new DataLayer();
        #endregion

        public _currentWindow()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Create New Task For CustomerID:" + InfoSec.GlobalCustomerID);
            FormSettings.SetFormSettings(this);
            Palette = HomePage.kryptonManager1.GlobalPalette;
            taskControlAdmin.PopulateTaskTypeCombobox(tsktye_cmb);
            taskControlAdmin.PopulatePriorities(tskPrio_cmb);
            kryptonDateTimePicker1.Format = DateTimePickerFormat.Custom;
            kryptonDateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            kryptonDateTimePicker1.AutoShift = true;
            custid_txt.Text = InfoSec.GlobalCustomerID;
            tskdesc_txt.MaxLength = 150;
            tskdtls_txt.MaxLength = 1000;
            charCount_lbl.Text = "Remaining Characters:1000";
        }

        private void CreateNewTask_Load(object sender, EventArgs e)
        {
            foreach (KryptonLabel control in this.Controls.OfType<KryptonLabel>())
            {

                control.LabelStyle = LabelStyle.BoldPanel;
            }
        }

        private void kryptonRichTextBoxExtended1_TextChanged(object sender, EventArgs e)
        {
            int maxCharacterCount = 1000;
            int remainingCharacters = maxCharacterCount - tskdtls_txt.Text.Length;
            charCount_lbl.Text = "Remaining Characters:" + remainingCharacters.ToString();
        }

        private void tskdesc_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsktye_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            taskControlAdmin.PopulatePriorityFromTaskType(tskPrio_cmb, tsktye_cmb);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            taskControlAdmin.ResetCreateCustomerTaskForm(tsktye_cmb, tskPrio_cmb, tskdesc_txt, tskdtls_txt, kryptonDateTimePicker1);
        }

        private void CrtTsk_btn_Click(object sender, EventArgs e)
        {
            DataLayer.CreateNewCustomerTask(tsktye_cmb, tskPrio_cmb, tskdesc_txt, tskdtls_txt, kryptonDateTimePicker1);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
