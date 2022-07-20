using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Security
{
    public class LoginSecurity
    {


        public void GetLoggedinUserName(Label username)
        {
            username.Text = Environment.UserName;
        }
      

    }
}
