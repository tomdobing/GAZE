using Gaze.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaze.BusinessLogic.SQLManagement;
using System.Windows.Forms;
using Krypton.Toolkit;
using System.Data.SqlClient;

namespace Gaze.BusinessLogic.CustomerManagement
{
    public class CustomerLogic
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        #endregion

        #region Methods

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

        

        #endregion

    }
}
