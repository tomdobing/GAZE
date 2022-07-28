using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Startup;
namespace GAZE.Admin
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        PreLoginChecks PreLoginChecks = new PreLoginChecks();
        readonly InfoSec infoSec = new InfoSec();
       readonly LoginFormSettings formSettings = new LoginFormSettings();
        public LoginForm()
        {
            InitializeComponent();
            formSettings.SetFormValue(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (PreLoginChecks.CheckSQLServerIsOnline() == true)
            {
                //password_txt.UseSystemPasswordChar = true;
                password_txt.PasswordChar = '*';
                metroLabel2.Text = Application.ProductVersion;

            }
            else if (PreLoginChecks.CheckSQLServerIsOnline() == false)
            {
                Application.Exit();
            }
            

        }

        private void Password_txt_Click(object sender, EventArgs e)
        {
          
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (infoSec.UserLogin(username_txt, password_txt) == true)
            {
                SwitchBoard master = new SwitchBoard();
                master.Show();
                this.Close();
            }
            else
            {
                string message = "Unknown username/password. Please try again";
                string caption = "Invalid Login Details!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                password_txt.Clear();
                password_txt.Focus();
            }

        }
    }
}
