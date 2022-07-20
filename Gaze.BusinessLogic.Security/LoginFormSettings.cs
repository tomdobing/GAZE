using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;

namespace Gaze.BusinessLogic.Security
{
    public class LoginFormSettings
    {

        public void SetFormValue(MetroForm LoginScreen)
        {
            LoginScreen.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //LoginScreen.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            LoginScreen.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            LoginScreen.Resizable = false;
            LoginScreen.MaximizeBox = false;
            LoginScreen.MinimizeBox = false;
        }


    }
}
