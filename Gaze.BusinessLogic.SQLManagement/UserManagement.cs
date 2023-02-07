using Gaze.BusinessLogic.Exceptions;
using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class UserManagement
    {

        #region Declarations

        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        ExceptionThrown ExceptionThrown = new ExceptionThrown();
        MessageHandler MessageHandler = new MessageHandler();
        #endregion

        #region Methods
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
                    SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_USER_SP", scon)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("Firstname", Firstname.Text);
                    sqlCommand.Parameters.AddWithValue("Surname", Surname.Text);
                    sqlCommand.Parameters.AddWithValue("username", Username.Text);
                    sqlCommand.Parameters.AddWithValue("password", Password.Text);
                    if (IsAdmin.CheckState == CheckState.Checked)
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
                finally
                {
                    scon.Close();
                }
            }


        }

        /// <summary>
        /// Resets a user password
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        public void ResetUserPassword(MetroTextBox Username, MetroTextBox Password)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            if (Password.Text.Length >= 7)
            {
                try
                {
                    scon.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_USER_PASSWORD_SP", scon)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("Username", Username.Text);
                    sqlCommand.Parameters.AddWithValue("Password", Password.Text);
                    sqlCommand.Parameters.AddWithValue("UpdatedBy", InfoSec.GlobalUsername);
                    sqlCommand.ExecuteReader();
                    string message = "User: " + Username.Text + "'s password has been reset Succesfully.";
                    string caption = "User Password Reset";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }
                catch (Exception ex)
                {
                    ExceptionThrown.ThrowNewStackException(ex, "Exception Thrown");
                }
                finally
                {
                    scon.Close();
                }
            }
            else
            {
                string message = "The password must be greater than 7 Characters.";
                string caption = "User Password Failure";
                MessageHandler.ShowMessage(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }





        }

        /// <summary>
        /// used to check if the user exists before creating a new user
        /// </summary>
        /// <param name="Username">Username to be created</param>
        /// <returns></returns>
        public bool CheckIfUserExists(MetroTextBox Username)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_USER_EXISTS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("Username", Username.Text);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {

                    return true;


                }
                else
                {
                    string message = "User: " + Username.Text + " does not exist in the database. Please check the username and try again.";
                    string caption = "Validation Failure";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }


            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                scon.Close();
            }


        }
        /// <summary>
        /// Selects users in the configured SQL Server Database and returns username only into ListBox
        /// </summary>
        /// <param name="listBox">Listbox to post results to</param>
        public void SelectAllUsers(ListBox listBox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_ALL_USERS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    listBox.Items.Add(sqlDataReader[3].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }

        }
        /// <summary>
        /// Selects highlighted user from the Database
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="ID"></param>
        /// <param name="firstname"></param>
        /// <param name="surname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="isadmin"></param>
        public void SelectedUser(ListBox listBox, MetroTextBox ID, MetroTextBox firstname, MetroTextBox surname, MetroTextBox username, MetroTextBox password, MetroCheckBox isadmin)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_SINGLE_USER_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Username", listBox.SelectedItem.ToString());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ID.Text = sqlDataReader[0].ToString();
                    firstname.Text = sqlDataReader[1].ToString();
                    surname.Text = sqlDataReader[2].ToString();
                    username.Text = sqlDataReader[3].ToString();
                    password.Text = sqlDataReader[4].ToString();
                    if (sqlDataReader[5].ToString().Length == 1)
                    {
                        isadmin.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        isadmin.CheckState = CheckState.Unchecked;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }

        }
        /// <summary>
        /// Function to update user information, Limited to Firstname, surname and Username
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="Username"></param>
        /// <param name="FirstName"></param>
        /// <param name="Surname"></param>
        public void UpdateUser(MetroTextBox UserID, MetroTextBox Username, MetroTextBox FirstName, MetroTextBox Surname)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_USER_DETAILS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("userid", UserID.Text);
                sqlCommand.Parameters.AddWithValue("username", Username.Text);
                sqlCommand.Parameters.AddWithValue("FirstName", FirstName.Text);
                sqlCommand.Parameters.AddWithValue("Surname", Surname.Text);
                sqlCommand.Parameters.AddWithValue("UpdatedBy", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                string message = "User: " + Username.Text + " has been updated";
                string caption = "User Updated";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException SQLException)
            {
                string message = "SQL Exception occured during the update process" + Environment.NewLine + Environment.NewLine + SQLException.Message;
                string caption = "SQL Exception Occured";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {

                string message = "An Error Occured during the Updated Process" + Environment.NewLine + Environment.NewLine + ex.Message;
                string caption = "Exception Occured";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                scon.Close();
            }

        }
    }
    #endregion
}
