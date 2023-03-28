using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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
                                              KryptonTextBox BillingAmount, KryptonTextBox YearlyTotal, KryptonTextBox AccountNumber, KryptonTextBox SortCode,
                                              KryptonTextBox BillingDay, KryptonTextBox NextBillingDate)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_OVERVIEW_BILLING_DETAILS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    BillingID.Text = sqlDataReader[0].ToString();
                    BillReference.Text = sqlDataReader[1].ToString();
                    BillingType.Text = sqlDataReader[2].ToString();
                    Frequency.Text = sqlDataReader[3].ToString();
                    BillingAmount.Text = sqlDataReader[4].ToString();
                    YearlyTotal.Text = sqlDataReader[5].ToString();
                    AccountNumber.Text = sqlDataReader[6].ToString();
                    SortCode.Text = sqlDataReader[7].ToString();
                    BillingDay.Text = sqlDataReader[8].ToString();

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



        #endregion
    }
}
