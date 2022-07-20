using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Gaze.BusinessLogic.Security;

namespace GAZE.Admin
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        LoginFormSettings formSettings = new LoginFormSettings();
        public LoginForm()
        {
            InitializeComponent();
            formSettings.SetFormValue(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
