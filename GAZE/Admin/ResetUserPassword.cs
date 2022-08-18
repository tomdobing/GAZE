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
    public partial class ResetUserPassword : Form
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        UserManagement UserManagement = new UserManagement();
        #endregion


        public ResetUserPassword()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Change Password");
            password_txt.UseSystemPasswordChar = true;
            confirm_txt.UseSystemPasswordChar= true;
            
        }

        private void ResetUserPassword_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (usrname_txt.Text == "" | password_txt.Text == "" | confirm_txt.Text == "")
            {
                string message = "You must complete all data fields";
                string caption = "Data Validation Failure";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            else
            {
                if (UserManagement.CheckIfUserExists(usrname_txt) == true)
                {
                    if (password_txt.Text == confirm_txt.Text)
                    {
                        UserManagement.ResetUserPassword(usrname_txt, confirm_txt);
                        this.Close();
                    }
                    else
                    {
                        string message = "The password you have entered does not match - Please try again!";
                        string caption = "Data Validation Failure";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    }
                    
                }
                else
                {
                    
                }
                
            }
        }
    }
}
