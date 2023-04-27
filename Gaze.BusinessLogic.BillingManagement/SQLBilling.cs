using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using Gaze.BusinessLogic.Security;
namespace Gaze.BusinessLogic.BillingManagement
{
    public class SQLBilling
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        public readonly Banking Banking = new Banking();
        // public SqlConnection scon = new SqlConnection(SQLConnectionString);
        #endregion

        #region Methods
        /// <summary>
        /// Method that will return a customers billing overview
        /// </summary>
        /// <param name="BillingID"></param>
        /// <param name="BillReference"></param>
        /// <param name="BillingType"></param>
        /// <param name="Frequency"></param>
        /// <param name="YearlyTotal"></param>
        /// <param name="MonthlyTotal"></param>
        /// <param name="BillingStatus"></param>
        /// <param name="AccountNumber"></param>
        /// <param name="SortCode"></param>
        /// <param name="NextBillingDate"></param>
        public void GetOverviewBillingDetails(KryptonTextBox BillingID, KryptonTextBox BillReference, KryptonTextBox BillingType, KryptonTextBox Frequency,
                                              KryptonTextBox YearlyTotal, KryptonTextBox MonthlyTotal,KryptonTextBox BillingStatus, 
                                              KryptonTextBox AccountNumber, KryptonTextBox SortCode, KryptonTextBox NextBillingDate)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_BILLING_DETAILS_OVERVIEW_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                //sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    BillingID.Text = sqlDataReader[0].ToString();
                    BillReference.Text = sqlDataReader[1].ToString();
                    BillingType.Text = sqlDataReader[2].ToString();
                    Frequency.Text = sqlDataReader[3].ToString();
                    YearlyTotal.Text = sqlDataReader[4].ToString();
                    MonthlyTotal.Text = sqlDataReader[5].ToString();
                    BillingStatus.Text = sqlDataReader[6].ToString();
                    AccountNumber.Text = sqlDataReader[7].ToString();
                    SortCode.Text = sqlDataReader[8].ToString();
                   

                    date = sqlDataReader.GetDateTime(9);
                    NextBillingDate.Text = date.ToShortDateString();



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
        /// Method will cancel a customers billing and cancel any associated policies - See Stored Procedure for intimate detaisl
        /// </summary>
        public void CancelCustomerBilling()
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_BILLING_TO_CANCELLED_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Customer Billing has been cancelled", "Billing Cancelled!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("The cancellation of Customer Billing Failed. Please check and try again", "Whoops!!!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);


            }
            finally
            {
                scon.Close();
            }

        }


        /// <summary>
        /// Method used to retrieve Customers Account Number & Sort Code
        /// </summary>
        /// <param name="AccoutnNumber"></param>
        /// <param name="SortCode"></param>
        public void GetCurrentBillingDetails(KryptonTextBox AccoutnNumber, KryptonTextBox SortCode)
        {
        SqlConnection scon = new SqlConnection( SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_ACCOUNTNUMBER_AND_SORTCODE_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    AccoutnNumber.Text = sqlDataReader.GetString(0);
                    SortCode.Text = sqlDataReader.GetString(1);
                 }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Whoops!!!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);


            }
            finally
            {
                scon.Close();
            }


        }

        /// <summary>
        /// Method to call a SP which will update the customers Account Number & Sort-Code
        /// </summary>
        public void UpdateBankingDetails()
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_ACCOUNTNUMBER_AND_SORTCODE_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@AccountNumber", Banking.accnum );
                sqlCommand.Parameters.AddWithValue("@SortCode", Banking.sortcode);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Customers Banking Details successfully updated!", "Updated", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Whoops!!!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);


            }
            finally
            {
                scon.Close();
            }



            


        }



        #endregion
    }
}
