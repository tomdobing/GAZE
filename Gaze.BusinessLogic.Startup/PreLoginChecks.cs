using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Startup
{
    public class PreLoginChecks
    {
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];

        public bool CheckSQLServerIsOnline()
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
                " Please check the SQL Server Connection and try again";
                string caption = "SQL Server Offline";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;    
            }
            catch (Exception ex)
            {
                string message = "An unknown error has occured. Please try again later";
                string caption = "Unknown Error Occured";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return false;
            }

        }

    }
}
