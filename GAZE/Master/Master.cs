using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.Config;

namespace GAZE
{
    public partial class Master : Form
    {
        FormSettings GetFormSettings = new FormSettings();

        public Master()
        {
            InitializeComponent();
            GetFormSettings.SetFormSettings(this);
        }

        private void Master_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:MM:ss");
            StartTimer();
            toolStripLabel2.Text = Application.ProductVersion.ToString();
            toolStripLabel3.Text = "Logged in as: " + Environment.UserName;
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
    }
}
