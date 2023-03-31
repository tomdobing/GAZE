using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
namespace Gaze.BusinessLogic.BillingManagement
{
    public class SQLBilling
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        // public SqlConnection scon = new SqlConnection(SQLConnectionString);
        #endregion

        #region Methods

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



        #endregion
    }
}
