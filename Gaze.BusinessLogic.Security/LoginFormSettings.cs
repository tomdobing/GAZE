using MetroFramework.Forms;
namespace Gaze.BusinessLogic.Security
{
    public class LoginFormSettings
    {
        /// <summary>
        /// Method called to set the default form values
        /// </summary>
        /// <param name="LoginScreen"></param>
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
