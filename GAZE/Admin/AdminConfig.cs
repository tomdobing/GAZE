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
using Gaze.BusinessLogic.Security;

namespace GAZE.Admin
{
    public partial class AdminConfig : Form
    {
        ConfigAdmin ConfigAdmin = new ConfigAdmin();
        FormSettings FormSettings = new FormSettings();
        LoginSecurity SecLogin = new LoginSecurity();
        public AdminConfig()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Admin Configuration");
        }

        private void AdminConfig_Load(object sender, EventArgs e)
        {
            ConfigAdmin.SelectAllConfigs(listBox1);
            listBox1.SelectedIndex = 0;
            listBox1.Focus();
            DisableInput();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeBit_cmb.Checked)
            {
                EnableInput();
            }
            ConfigAdmin.SelectedConfig(listBox1, ConfigID_txt, ConfigName_txt, ConfigValue_txt, ChangeBit_cmb, AddedBy_txt);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DisableInput()
        {
            ConfigName_txt.ReadOnly = true;
            ConfigValue_txt.ReadOnly = true;
            AddedBy_txt.ReadOnly = true;
            ConfigID_txt.ReadOnly = true;
            ChangeBit_cmb.Enabled = false;
        }

        private void EnableInput()
        {
            ConfigValue_txt.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigAdmin.UpdateConfigValue(ConfigID_txt.Text, ConfigValue_txt.Text, InfoSec.GlobalUsername);
        }
    }
}
