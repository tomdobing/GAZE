using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class UserManagement
    {

        private string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];

        public void CreateNewUser(MetroTextBox Firstname, MetroTextBox Surname, MetroTextBox Username, MetroTextBox Password, MetroCheckBox IsAdmin)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_USER_SP", scon);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("Firstname", Firstname.Text);
                sqlCommand.Parameters.AddWithValue("Surname", Surname.Text);
                sqlCommand.Parameters.AddWithValue("username", Username.Text);
                sqlCommand.Parameters.AddWithValue("password", Password.Text);
                if (IsAdmin.CheckState == System.Windows.Forms.CheckState.Checked)
                {
                    sqlCommand.Parameters.AddWithValue("ISAdmin", 1);
                    
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("ISAdmin", null);
                }
                sqlCommand.Parameters.AddWithValue("@createdBY", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();

                string message = "User:" + Username.Text + " has been created.";
                string caption = "User Created";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {

                string message = "An uknown error occured when creating user: " + Username.Text;
                string caption = "Something went wrong";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }
    }
}
