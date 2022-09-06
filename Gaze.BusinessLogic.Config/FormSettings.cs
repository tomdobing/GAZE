using Gaze.BusinessLogic.SQLManagement;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaze.BusinessLogic.Config
{
    public class FormSettings
    {

        ConfigAdmin ConfigAdmin = new ConfigAdmin();
        //readonly InfoSec infoSec = new InfoSec();
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
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

            defaultForm.Text = ConfigurationManager.AppSettings["CompanyName"] + " - " + Application.ProductVersion + " - " + additionInfo;
        }

        public HttpStatusCode GetHeaders(string url)
        {
            HttpStatusCode result = default(HttpStatusCode);

            try
            {
                var request = HttpWebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        result = response.StatusCode;
                        response.Close();
                    }
                }
                string message = "URL Valid";
                string caption = "Valid";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
            catch (System.Exception)
            {
                string message = "An unknown error occured when checking for updates. Please try again later or contact your system administrator!";
                string caption = "Something went wrong";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return result;
            }

        }

    }
}
