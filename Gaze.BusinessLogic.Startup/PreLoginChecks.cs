using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Gaze.BusinessLogic.Exceptions;

namespace Gaze.BusinessLogic.Startup
{
    public class PreLoginChecks
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        #endregion



        #region Methods
        /// <summary>
        /// check if the Configured SQL Server is online
        /// </summary>
        /// <returns>True - Server online | False - Server Offline</returns>
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
                exceptionThrown.ThrowNewStackException(ex, "SQL Server Offline");
                //string message = "Unable to connect to the selected SQL Server!" +
                //" Please check the SQL Server Connection and try again" + Environment.NewLine + Environment.NewLine + ex.Message;
                //string caption = "SQL Server Offline";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons,
                //MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                ErrorMessage.Text = "SQL Server Offline!";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
               
               // ErrorMessage.Show();
                return false;    
                
            }
            catch (Exception ex)
            {
                exceptionThrown.ThrowNewStackException(ex, "SQL Server Offline");
                //string message = "An unknown error has occurred. Please try again later" + Environment.NewLine + Environment.NewLine + ex.Message;
                //string caption = "Unknown Error Occurred";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons,
                //MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
