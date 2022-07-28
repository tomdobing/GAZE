using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Windows.Forms;
namespace GAZE.Admin
{
    public partial class UserMgr : Form
    {
        FormSettings FormSettings = new FormSettings();
        UserManagement UserManagement = new UserManagement();
        public UserMgr()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Edit Users");
        }

        private void UserMgr_Load(object sender, EventArgs e)
        {
            UserManagement.SelectAllUsers(listBox1);
            id_txt.Enabled = false;
            fstname_txt.ReadOnly = true;
            surname_txt.ReadOnly = true;
            usrname_txt.ReadOnly = true;
            psswrd_txt.ReadOnly = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserManagement.SelectedUser(listBox1, id_txt, fstname_txt, surname_txt, usrname_txt, psswrd_txt, metroCheckBox1);
        }
    }
}
