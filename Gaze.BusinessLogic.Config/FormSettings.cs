using Gaze.BusinessLogic.SQLManagement;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Config
{
    public class FormSettings
    {
        InfoSec infoSec = new InfoSec();

        /// <summary>
        /// Sets the default form settings.
        /// </summary>
        public void SetFormSettings(Form defaultForm)
        {
            defaultForm.MaximizeBox = false;
            defaultForm.MinimizeBox = false;
            defaultForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            defaultForm.StartPosition = FormStartPosition.CenterScreen;
            defaultForm.MaximizeBox = false;
            defaultForm.MinimizeBox = false;

        }

        /// <summary>
        /// Changeable form settings that can be changed via the app.config.exe.
        /// Also contains some static settings 
        /// </summary>
        /// <param name="defaultForm"></param>
        /// <param name="additionInfo"></param>
        public void ChangeableFormSettings(Form defaultForm, [Optional] string additionInfo)
        {

            defaultForm.Text = ConfigurationSettings.AppSettings["CompanyName"] + " - " + Application.ProductVersion + " - " + additionInfo;
        }
    }
}
