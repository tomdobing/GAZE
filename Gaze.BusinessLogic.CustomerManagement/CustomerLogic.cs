using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.CustomerManagement
{
    /// <summary>
    /// Class used to store all Logic relating to Customers
    /// </summary>
    public class CustomerLogic
    {///
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        #endregion

        #region Methods
        /// <summary>
        /// Method used to retrieve the customer History
        /// </summary>
        /// <param name="CustomerName"></param>
        /// <param name="CustomerID"></param>
        /// <param name="PolicyCount"></param>
        /// <exception cref="SqlException"?>SQLException caught</exception>
        public void GetCustomerHistoryDetails(KryptonTextBox CustomerName, KryptonTextBox CustomerID, KryptonTextBox PolicyCount)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_HISTORY_DETAILS_FOR_FORM_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    CustomerName.Text = sqlDataReader[0].ToString();
                    CustomerID.Text = sqlDataReader[1].ToString();
                    PolicyCount.Text = sqlDataReader[2].ToString();

                }
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message + "\n\n" + SQLException.InnerException, "A SQL Exception Occurred", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Details", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;

            }
            finally
            {
                scon.Close();
            }
        }
        /// <summary>
        /// Method used to Check if any restrictions are in place preventing access to the Customer Account
        /// </summary>
        /// <param name="FormToManage">[optional] used to manage the form calling the method</param>
        /// <returns></returns>
        public bool CheckForAccountAccessRestrictions([Optional] KryptonForm FormToManage)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("sec.SELECT_CUSTOMER_RESTRICTIONS_ACCESS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    MessageBox.Show(sqlDataReader[0].ToString(), "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //FormToManage.Dispose();
                    return true;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to check for restrictions", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return true;

            }
            finally
            {

                scon.Close();

            }
            return false;

        }

        public void RestrictCustomerAccount(KryptonForm FormtoClose)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("sec.UPDATE_CUSTOMER_RESTRICT_ACCESS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Account with CustomerID:" + InfoSec.GlobalCustomerID + " has now been restricted!", "Account Restricted", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                FormtoClose.Close();
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "Failure to Set Restrictions", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to Set restrictions", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);


            }
            finally
            {
                scon.Close();

            }


        }



        #endregion

    }
}
