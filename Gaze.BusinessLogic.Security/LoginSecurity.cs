using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.SQLManagement;
namespace Gaze.BusinessLogic.Security
{
    public class LoginSecurity
    {
        InfoSec infoSec = new InfoSec();
        /// <summary>
        /// Gets the username of the current user
        /// </summary>
        /// <param name="username">ToolstripLabel for value</param>
        public void GetLoggedinUserName(ToolStripLabel username)
        {
            username.Text = "Logged in as: " + InfoSec.GlobalUsername.ToUpper();
        }
      

    }
}
