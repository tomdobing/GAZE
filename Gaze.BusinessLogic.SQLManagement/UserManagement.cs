using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class UserManagement
    {

        private string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        /// <summary>
        /// Method used for creating new System Users
        /// </summary>
        /// <param name="Firstname">First Name/param>
        /// <param name="Surname">Surname</param>
        /// <param name="Username">Username Auto Populated</param>
        /// <param name="Password">Password to be created</param>
        /// <param name="IsAdmin">Bool check box is admin</param>
        /// <param name="form">Current form</param>
        public void CreateNewUser(MetroTextBox Firstname, MetroTextBox Surname, MetroTextBox Username, MetroTextBox Password, MetroCheckBox IsAdmin, Form form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            if (Firstname.Text == "" | Surname.Text == "" | Username.Text == "" | Password.Text == "")
            {
                MessageBox.Show("You must complete all fields", "Data Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
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
                    form.Close();
                }
                catch (Exception)
                {

                    string message = "An unknown error occured when creating user: " + Username.Text;
                    string caption = "Something went wrong";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }


        }
    }
}
