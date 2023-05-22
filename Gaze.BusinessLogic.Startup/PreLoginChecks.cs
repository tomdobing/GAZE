using Gaze.BusinessLogic.Exceptions;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                ErrorMessage.Text = "SQL Server Offline!";
                ErrorMessage.ForeColor = System.Drawing.Color.Red;

                // ErrorMessage.Show();
                return false;

            }
            catch (Exception ex)
            {
                exceptionThrown.ThrowNewStackException(ex, "SQL Server Offline");
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
