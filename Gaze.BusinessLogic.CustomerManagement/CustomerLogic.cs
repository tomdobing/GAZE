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
using System.Runtime.InteropServices;

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

        public bool CheckForRestrictions([Optional] KryptonForm FormToManage)
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
                
                //if (sqlDataReader.Read)
                //{
                //    MessageBox.Show(sqlDataReader[0].ToString(), "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    FormToManage.Close();
                //    return;
                    
                //}
                //else
                //{
                //    return;
                //}
                
                
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

        

        #endregion

    }
}
