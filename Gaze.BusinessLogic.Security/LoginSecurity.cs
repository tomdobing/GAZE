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

        /// <summary>
        /// Gets the username of the current user
        /// </summary>
        /// <param name="username">ToolstripLabel for value</param>
        public void GetLoggedinUserName(ToolStripLabel username)
        {
            username.Text = Environment.UserName;
        }
      

    }
}
