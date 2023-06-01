using Krypton.Toolkit;
using MetroFramework.Forms;
using System.Runtime.InteropServices;

namespace Gaze.BusinessLogic.Security
{
    public class LoginFormSettings
    {
        /// <summary>
        /// Method called to set the default form values
        /// </summary>
        /// <param name="LoginScreen"></param>
        public void SetFormValue([Optional] MetroForm LoginScreen, [Optional] KryptonForm LoginScreen1)
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
