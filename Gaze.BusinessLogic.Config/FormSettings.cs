using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Gaze.BusinessLogic.Config
{
    public class FormSettings
    {
       
        ConfigAdmin ConfigAdmin = new ConfigAdmin();
        MessageHandler MessageHandler = new MessageHandler();
        //readonly InfoSec infoSec = new InfoSec();
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];


        /// <summary>
        /// Sets the default form settings.
        /// </summary>
        public void SetFormSettings(KryptonForm defaultForm)
        {
            defaultForm.MaximizeBox = false;
            defaultForm.MinimizeBox = false;
            defaultForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            defaultForm.StartPosition = FormStartPosition.CenterScreen;
            defaultForm.MaximizeBox = false;
            defaultForm.MinimizeBox = false;
            defaultForm.BackColor = SystemColors.ActiveCaption;
            

        }

        /// <summary>
        /// Changeable form settings that can be changed via the app.config.exe.
        /// Also contains some static settings 
        /// </summary>
        /// <param name="defaultForm">The form to apply </param>
        /// <param name="additionInfo">Form text to be displayed</param>
        
        public void ChangeableFormSettings(KryptonForm defaultForm, [Optional] string additionInfo)
        {

            defaultForm.Text = ConfigAdmin.GetConfigValue("Company Name") + " - " + Application.ProductVersion + " - " + additionInfo;
            defaultForm.FormTitleAlign = PaletteRelativeAlign.Center;
            //defaultForm.Text = ConfigurationManager.AppSettings["CompanyName"] + " - " + Application.ProductVersion + " - " + additionInfo;
        }
        /// <summary>
        /// this function is used to return whether the URL is valid and reachable. Typically used for Check For Updates
        /// </summary>
        /// <param name="url">The Updates Server URL</param>
        /// <returns>Returns HTTP Status Code</returns>
        public HttpStatusCode GetHeaders(string url)
        {
            HttpStatusCode result = default(HttpStatusCode);

            try
            {
                var request = WebRequest.Create(url);
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
                MessageHandler.ReturnInfoBox("Oh Oh! It would appear we are unable to check for updates right now. \n\nPlease try again later or contact your systems administrator",
                    InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Error);
                //string message = "An unknown error occurred when checking for updates. Please try again later or contact your system administrator!";
                //string caption = "Something went wrong";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons,
                //MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return result;
            }

        }

    }
}
