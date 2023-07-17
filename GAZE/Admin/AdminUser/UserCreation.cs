using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZE.Admin.AdminUser
{
    public partial class UserCreation : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        ControlManagement ControlManagement = new ControlManagement();
        ProductDetails ProductDetails = new ProductDetails();
        readonly Gaze.BusinessLogic.Config.Validations validations = new Gaze.BusinessLogic.Config.Validations();
        readonly UserManagement userManegement = new UserManagement();
        readonly Encryption encryption = new Encryption();
        #endregion

        public UserCreation()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "User Creation - ADMIN");
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            userManegement.PopulateRolesForNewUserCreation(role_cmb);
            passreqs_lbl.Hide();
        }

        private void UserCreation_Load(object sender, EventArgs e)
        {

        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_txt_Enter(object sender, EventArgs e)
        {
            username_txt.Text = forname_txt.Text + "." + surname_txt.Text;
        }

        private void create_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(forname_txt.Text))
            {
                KryptonMessageBox.Show("Forename cannot be null", "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(surname_txt.Text))
            {
                KryptonMessageBox.Show("Surname cannot be null", "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            if (CheckPasswordsMatch(password1_txt.Text, password2_txt.Text) == false)
            {
                KryptonMessageBox.Show("The password you have entered does not match. Please try again", "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            if (validations.IsPasswordValid(password1_txt.Text) == false)
            {
                KryptonMessageBox.Show("The Password entered does not meet the complexity requirements. Please try again", "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                passreqs_lbl.Show();
                return;
            }
            if (role_cmb.SelectedIndex == -1)
            {
                KryptonMessageBox.Show("You must select a role for this user. Please try again", "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            string pass = encryption.EncryptTextBoxValue(password1_txt, password2_txt.Text);
            userManegement.CreateNewUser(forname_txt, surname_txt, username_txt, pass,role_cmb, this);
        }

        private bool CheckPasswordsMatch(string password1, string password2)
        {
            if (password1 == password2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
