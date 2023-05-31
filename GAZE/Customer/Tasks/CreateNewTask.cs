using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.TaskManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Dialogs;
using Krypton.Toolkit.Suite.Extended.Forms;
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
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            taskControlAdmin.PopulateTaskTypeCombobox(tsktye_cmb);
            taskControlAdmin.PopulatePriorities(tskPrio_cmb);
            kryptonDateTimePicker1.Format = DateTimePickerFormat.Custom;
            kryptonDateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
            kryptonDateTimePicker1.AutoShift = true;
            custid_txt.Text = InfoSec.GlobalCustomerID;

            
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
            if (true)
            {

            }
            DataLayer.CreateNewCustomerTask(tsktye_cmb, tskPrio_cmb, tskdesc_txt,tskdtls_txt, kryptonDateTimePicker1);
        }
    }
}
