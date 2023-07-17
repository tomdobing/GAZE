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
using Krypton.Toolkit;
using Gaze.BusinessLogic.Security;

namespace GAZE.Admin
{
    public partial class CreateUser : KryptonForm
    {
        #region Declarations
        readonly FormSettings FormSettings = new FormSettings();
        readonly UserManagement userNamanegement = new UserManagement();
        readonly Encryption encryption = new Encryption();
        #endregion

        #region Methods
        public CreateUser()
        {
            
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Create New User");
            InitializeComponent();
        }

        private void Addusr_txt_Click(object sender, EventArgs e)
        {
            string pass = encryption.EncryptTextBoxValue(password_txt, password_txt.Text);
            
            //userNamanegement.CreateNewUser(FName_txt, sName_txt, username_txt, pass, admin_chk, this);
            
            

        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void Username_txt_Click(object sender, EventArgs e)
        {

        }

        private void Username_txt_Enter(object sender, EventArgs e)
        {
            username_txt.Text = FName_txt.Text + "." + sName_txt.Text;
        }
        #endregion
    }
}
