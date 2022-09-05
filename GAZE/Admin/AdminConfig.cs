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
using Gaze.BusinessLogic.SQLManagement;

namespace GAZE.Admin
{
    public partial class AdminConfig : Form
    {
        ConfigAdmin ConfigAdmin = new ConfigAdmin();
        FormSettings FormSettings = new FormSettings();
        public AdminConfig()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Admin Configuration");
        }

        private void AdminConfig_Load(object sender, EventArgs e)
        {
            ConfigAdmin.SelectAllConfigs(listBox1);
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigAdmin.SelectedConfig(listBox1, metroTextBox1, metroTextBox2, metroTextBox3, metroCheckBox1, metroTextBox4);
            //metroCheckBox1.CheckState = CheckState.Unchecked;
        }
    }
}
