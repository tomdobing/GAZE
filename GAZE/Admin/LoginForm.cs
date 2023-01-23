using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Startup;
using Gaze.BusinessLogic.Exceptions;
using System;
using System.Windows.Forms;

namespace GAZE.Admin
{

    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        #region Declarations
        readonly PreLoginChecks PreLoginChecks = new PreLoginChecks();
        readonly InfoSec infoSec = new InfoSec();
        readonly LoginFormSettings formSettings = new LoginFormSettings();
        readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        #endregion

        #region Methods
        public LoginForm()
        {
            InitializeComponent();
            formSettings.SetFormValue(this);
            //metroProgressSpinner1.Hide();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SQLError_lbl.Text = "";
            password_txt.UseSystemPasswordChar = true;
            //password_txt.PasswordChar = '*';
            metroLabel2.Text = Application.ProductVersion;
        }


        private void MetroButton1_Click(object sender, EventArgs e)
        {


            if (PreLoginChecks.CheckSQLServerIsOnline(SQLError_lbl) == true)
            {
                if (infoSec.UserLogin(username_txt, password_txt) == true)
                {
                    HomePage master = new HomePage();
                    master.Show();
                    Close();
                }
                else
                {
                    //exceptionThrown.ThrowNewException("Unknown username/password. Please try again", "Invalid Login Details!", "Login Failed");
                    string message = "Incorrect username/password. Please try again";
                    string caption = "Invalid Login Details!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    password_txt.Clear();
                    password_txt.Focus();
                }
            }
            else if (PreLoginChecks.CheckSQLServerIsOnline(SQLError_lbl) == false)
            {
                //Application.Exit();
            }



        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                metroButton1.PerformClick();
            }
        }
        #endregion

    }
}

