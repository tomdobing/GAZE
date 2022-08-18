using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Gaze.BusinessLogic.Startup
{
    public class PreLoginChecks
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        #endregion

        #region Methods
        /// <summary>
        /// Method checks if the Configured SQL Server is online
        /// </summary>
        /// <returns>True - Server online False - Server Offline</returns>
        public bool CheckSQLServerIsOnline(Label ErrorMessage)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                return true;
            }
            catch (SqlException ex)
            {

                string message = "Unable to connect to the selected SQL Server!" +
                " Please check the SQL Server Connection and try again" + Environment.NewLine + Environment.NewLine + ex.Message;
                string caption = "SQL Server Offline";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                ErrorMessage.Text = "SQL Server Offline!";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                
               // ErrorMessage.Show();
                return false;    
            }
            catch (Exception ex)
            {
                string message = "An unknown error has occured. Please try again later" + Environment.NewLine + Environment.NewLine + ex.Message;
                string caption = "Unknown Error Occured";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                ErrorMessage.Text = "SQL Server Offline!";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Show();
                return false;
            }
            finally
            {
                scon.Close();
            }

        }
        #endregion

    }
}
