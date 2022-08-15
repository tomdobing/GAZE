using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Config;

namespace GAZE.Admin
{
    public partial class CreateUser : Form
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        UserManagement userNamanegement = new UserManagement();
        #endregion

        #region Methods
        public CreateUser()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Create New User");
        }

        private void addusr_txt_Click(object sender, EventArgs e)
        {
            userNamanegement.CreateNewUser(FName_txt, sName_txt, username_txt, password_txt, admin_chk, this);
            

        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void username_txt_Click(object sender, EventArgs e)
        {

        }

        private void username_txt_Enter(object sender, EventArgs e)
        {
            username_txt.Text = FName_txt.Text + "." + sName_txt.Text;
        }
        #endregion
    }
}
