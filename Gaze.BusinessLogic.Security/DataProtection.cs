using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Security
{
    /// <summary>
    /// Data Protection Class used for DPA relating to customer security
    /// </summary>

    public class DataProtection
    {

        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];

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
            catch (Exception)
            {

                throw;
            }

        }

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

    }
}

