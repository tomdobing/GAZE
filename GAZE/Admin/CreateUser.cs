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

namespace GAZE.Admin
{
    public partial class CreateUser : Form
    {
        UserManagement userNamanegement = new UserManagement();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void addusr_txt_Click(object sender, EventArgs e)
        {
            userNamanegement.CreateNewUser(FName_txt, sName_txt, username_txt, password_txt, admin_chk);
        }
    }
}
