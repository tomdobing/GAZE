using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Startup;
using System;
using System.Windows.Forms;
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
            //metroProgressSpinner1.Hide();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (PreLoginChecks.CheckSQLServerIsOnline() == true)
            {
                password_txt.UseSystemPasswordChar = true;
                //password_txt.PasswordChar = '*';
                metroLabel2.Text = Application.ProductVersion;

            }
            else if (PreLoginChecks.CheckSQLServerIsOnline() == false)
            {
                Application.Exit();
            }


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

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                metroButton1.PerformClick();
            }
        }

    }
}

