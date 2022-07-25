using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
namespace Gaze.BusinessLogic.SQLManagement
{

    public class InfoSec
    {

        private string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        public static string GlobalUsername { get; set; }

        public bool UserLogin(MetroTextBox username, MetroTextBox password)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_USER_FOR_LOGIN", scon);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("username", username.Text);
                sqlCommand.Parameters.AddWithValue("password", password.Text);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    GlobalUsername = username.Text;
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
             
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }


    }
}
