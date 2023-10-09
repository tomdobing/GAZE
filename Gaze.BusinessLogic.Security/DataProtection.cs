using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Security
{
    /// <summary>
    /// Data Protection Class used for DPA relating to customer security
    /// </summary>

    public class DataProtection
    {
        /// <summary>
        /// SQL Connection string used for communication between the front end app and Database
        /// </summary>
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];

        /// <summary>
        /// Base Method used for executing Stored Procedure
        /// </summary>
        /// <param name="SPNAME">The Stored Procedure Name</param>
        /// <param name="commandParameters">Parameters used for the SP</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string SPNAME, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                return SqlHelper.ExecuteReader(sqlConnection, SPNAME, commandParameters);

            }
            catch (SqlException sqlException)
            {

                KryptonMessageBox.Show(sqlException.Message, "Failure!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return reader;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        /// <summary>
        /// Method used for returning the Customers DPA Password
        /// </summary>
        /// <param name="PasswordField">Control name for displaying the Password</param>
        public void GetCustomersPassword(KryptonTextBox PasswordField)
        {
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_DPA_PASSWORD_SP", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    PasswordField.Text = sqlDataReader[0].ToString();

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Failed to retrieve customer's DPA Password: \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally 
            { 
                sqlConnection.Close();
            }
         
        }

        /// <summary>
        /// Method is called to create a new DPA password.
        /// </summary>
        /// <param name="Password">Password to be created</param>
        /// <seealso cref="KryptonTextBox"href=""></seealso>
        public void CreateNewCustomerDPAPassword(string Password)
        {
            if (string.IsNullOrEmpty(Password))
            {
                KryptonMessageBox.Show("Password: NULL is not a valid password \n\nDPA Password must not be blank. Please enter a valid password", "Password Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            try
            {

                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_DPA_CUSTOMER_PASSWORD_SP", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Password", Password);
                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("New Password created", "Success!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Failed to set new password: \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Method called to update a customers DPA password
        /// </summary>
        /// <param name="Password">New Password value</param>
        public void UpdateCustomersDPAPassword(string Password)
        {
            if (string.IsNullOrEmpty(Password))
            {
                KryptonMessageBox.Show("Password: NULL is not a valid password \n\nDPA Password must not be blank. Please enter a valid password", "Password Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            if (Password == " ")
            {
                KryptonMessageBox.Show("Password: 'EMPTY SPACE' is not a valid password \n\nDPA Password must not be blank. Please enter a valid password", "Password Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            if (IsPasswordValid(Password) == false)
            {
                KryptonMessageBox.Show("Password: "+ Password+ " Is not valid and/or acceptable. Please try again" , "Password Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_DPA_PASSWORD_SP", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@NewCustomerPassword", Password);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Customer ID:" + InfoSec.GlobalCustomerID + "\n\n The referenced Customer's DPA Password has been successfully updated", "Success", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("SQL Exception Raised: \n\n" + SQLException.Message, "Password Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Failed to update password: \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private static bool IsPasswordValid(string password)
        {

            if (string.IsNullOrEmpty(password) || password.Trim() == ".")
            {
                return false;
            }
            string specialChars = @"!@#$%^&*()_+[]{}|;':,.<>?";
            return !Regex.IsMatch(password, "[" + Regex.Escape(specialChars) + "]");
        
        }

    }
}

