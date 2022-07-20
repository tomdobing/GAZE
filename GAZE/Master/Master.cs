using System;
using System.Windows.Forms;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Security;

namespace GAZE
{
    public partial class Master : Form
    {
        FormSettings GetFormSettings = new FormSettings();
        LoginSecurity loginSecurity = new LoginSecurity();

        public Master()
        {
            InitializeComponent();
            GetFormSettings.SetFormSettings(this);
            GetFormSettings.ChangeableFormSettings(this, this.Name);
        }

        private void Master_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:MM:ss");
            StartTimer();
            toolStripLabel2.Text = "Build:" + Application.ProductVersion.ToString();
            loginSecurity.GetLoggedinUserName(toolStripLabel3);
        }

        System.Windows.Forms.Timer t = null;
        public void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        public void t_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:MM:ss");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.AboutUs aboutBox1 = new Help.AboutUs();
            aboutBox1.ShowDialog();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you wish to exit? Any open work will not be saved!";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void hideTimeDateToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "An uknown error occured when checking for updates. Please try again later!";
            string caption = "Something went wrong";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}
