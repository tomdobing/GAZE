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
            metroCheckBox1.Enabled = false;
            update_btn.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserManagement.SelectedUser(listBox1, id_txt, fstname_txt, surname_txt, usrname_txt, psswrd_txt, metroCheckBox1);
            metroCheckBox2.CheckState = CheckState.Unchecked;

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.CheckState == CheckState.Checked)
            {
                fstname_txt.ReadOnly = false;
                surname_txt.ReadOnly = false;
                usrname_txt.ReadOnly = false;
                psswrd_txt.ReadOnly = false;
                update_btn.Enabled = true;
            }
            else if (metroCheckBox2.CheckState == CheckState.Unchecked)
            {
                fstname_txt.ReadOnly = true;
                surname_txt.ReadOnly = true;
                usrname_txt.ReadOnly = true;
                psswrd_txt.ReadOnly = true;
                update_btn.Enabled = false;
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            UserManagement.UpdateUser(id_txt, usrname_txt, fstname_txt, surname_txt);
        }
    }
}
