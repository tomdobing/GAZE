using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using GAZE.Customer;
using GAZE.Customer.Tasks;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;
using System;
using System.Configuration;
using System.Windows.Forms;
using Gaze.Security.Management;
using System.Linq;
using System.Diagnostics;
using GAZE.Customer.NewCustomer;
using GAZE.Admin;

namespace GAZE
{
    public partial class HomePage : KryptonForm
    {
        #region Declarations
        readonly FormSettings GetFormSettings = new FormSettings();
        readonly LoginSecurity loginSecurity = new LoginSecurity();
        readonly InfoSec infoSec = new InfoSec();
        readonly ConfigAdmin configAdmin = new ConfigAdmin();
        ExceptionThrown ExceptionThrown = new ExceptionThrown();
        readonly MessageHandler messageHandler = new MessageHandler();
        readonly RoleManagement roleManagement = new RoleManagement();
        SQLDataAdmin SQLDataAdmin = new SQLDataAdmin();
        #endregion

        #region Methods
        public HomePage()
        {
            InitializeComponent();
            GetFormSettings.SetFormSettings(this);
            GetFormSettings.ChangeableFormSettings(this, this.Name);
            KryptonForm form = this;
            

            ControlAccessHelper controlAccessHelper = new ControlAccessHelper();
            controlAccessHelper.ExecuteControlManagement(this, menuStrip1);
            /// controlAccessHelper.DisableItemsMenuItems(menuStrip1);
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            
            toolStripLabel1.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString(configAdmin.GetConfigValue("Time Format"));
            StartTimer();
            toolStripLabel2.Text = "Build:" + Application.ProductVersion.ToString();
            loginSecurity.GetLoggedinUserName(toolStripLabel3);
            if (roleManagement.DisableNonAdminControls() == false)
            {
                adminToolStripMenuItem.Enabled = false;

            }
            toolStripLabel4.ForeColor = System.Drawing.Color.Green;
            toolStripLabel4.Text = "Database: Connected";


        }

        Timer t = null;
        public void StartTimer()
        {
            t = new System.Windows.Forms.Timer
            {
                Interval = 500
            };
            t.Tick += new EventHandler(Tick);
            t.Enabled = true;
        }

        public void Tick(object sender, EventArgs e)
        {

            toolStripLabel1.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString(ConfigurationManager.AppSettings["DateFormat"]);

        }

        private void NewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Customer.NewCustomer newCustomer = new Customer.NewCustomer();
            // newCustomer.ShowDialog();
            Customer.NewCustomer.NewCustomerImproved NewCust = new Customer.NewCustomer.NewCustomerImproved();
            NewCust.ShowDialog();
        }


        private void newCustomerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Customer.NewCustomer.NewCustomerImproved NewCust = new Customer.NewCustomer.NewCustomerImproved();
            NewCust.ShowDialog();
        }

        private void searchToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CustomerSearch customerSearch = new CustomerSearch();
            customerSearch.ShowDialog();
        }



        private void createNewUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admin.CreateUser createUser = new Admin.CreateUser();
            createUser.ShowDialog();

        }

        private void exitApplicationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            string message = "Are you sure you wish to exit? Any open work will not be saved!";
            string caption = "Are you sure?";
            DialogResult result;

            result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Help.AboutUs aboutBox1 = new Help.AboutUs();
            aboutBox1.ShowDialog();
        }

        private void sQLServerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            string message = ConfigurationManager.AppSettings["SQLConnection"] + Environment.NewLine + Environment.NewLine + "Database: Gaze_DB: True";
            KryptonMessageBox.Show(message, "Whoops!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);



        }

        private void checkForUpdatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetFormSettings.GetHeaders("https://InvalidURLCheckforupdates.com");
        }

        private void hideTimeDateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (toolStrip1.Visible == true)
            {
                toolStrip1.Visible = false;
            }
            else
            {
                toolStrip1.Visible = true;
            }
        }

        private void editDeleteUsersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admin.UserMgr user = new Admin.UserMgr();
            user.ShowDialog();

        }

        private void resetUserPasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admin.ResetUserPassword resetUserPassword = new Admin.ResetUserPassword();
            resetUserPassword.ShowDialog();
        }

        private void configSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admin.AdminConfig adminconfig = new Admin.AdminConfig();
            adminconfig.ShowDialog();

        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admin.LoginForm LoginForm = new Admin.LoginForm();
            LoginForm.Show();
            this.Close();
        }

        private void HomePage_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void HomePage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                searchToolStripMenuItem.PerformClick();
            }
        }

        private void improvedCustomerOverViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerOverViewV1 customeroverview = new CustomerOverViewV1();
            customeroverview.Show();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Customer.Tasks._currentWindow createNewTask = new Customer.Tasks._currentWindow();
            createNewTask.Show();

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.Show();
        }
    }
}
