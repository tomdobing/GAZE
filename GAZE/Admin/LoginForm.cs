using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Startup;
using InfoBox;
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
        readonly MessageHandler MessageHandler = new MessageHandler();
        #endregion

        #region Methods
        public LoginForm()
        {
            InitializeComponent();
            formSettings.SetFormValue(this);


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SQLError_lbl.Text = "";
            password_txt.UseSystemPasswordChar = true;
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
                        InformationBox.Show("Incorrect username/Password entered \n\nPlease check and try again",
                        InformationBoxIcon.Exclamation,
                        InformationBoxButtons.OK,
                        InformationBoxStyle.Modern,
                        InformationBoxOrder.TopMost);


                    //password_txt.Clear();
                    //password_txt.Focus();
                }
            }
            else if (PreLoginChecks.CheckSQLServerIsOnline(SQLError_lbl) == false)
            {

            }



        }


        #endregion

    }
}

