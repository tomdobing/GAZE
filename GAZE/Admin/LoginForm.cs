using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Startup;
using Krypton.Toolkit;
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
        readonly Encryption encryption = new Encryption();
        #endregion

        #region Methods
        [Obsolete]
        public LoginForm()
        {
            InitializeComponent();
            formSettings.SetFormValue(this);


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SQLError_lbl.Text = "";
            Pass_txt.UseSystemPasswordChar = true;
            metroLabel2.Text = Application.ProductVersion;
        }


        private void MetroButton1_Click(object sender, EventArgs e)
        {




        }


        #endregion

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (PreLoginChecks.CheckSQLServerIsOnline(SQLError_lbl) == true)
            {
                if (infoSec.UserLogin(username_txt, encryption.EncryptTextBoxValue(Pass_txt, Pass_txt.Text)) == true)
                {
                    HomePage master = new HomePage();
                    master.Show();
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(this, "Incorrect username/Password entered\n\nPlease check and try again",
                                            "Login Failed", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);


                }
            }
            else if (PreLoginChecks.CheckSQLServerIsOnline(SQLError_lbl) == false)
            {

            }

        }
    }
}

