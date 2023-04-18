using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gaze.BusinessLogic.CustomerManagement
{
    public class CustCallBack
    {


        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        #endregion

        #region Methods

        public void GetCustNameForCallBack(KryptonTextBox CustomerName)
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_NAME_FOR_CALLBACK_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CustomerName.Text = sqlDataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Details - ERR:CALLBCK", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;

            }
            finally
            {
                scon.Close();
            }

        }


        public void NewCallBackRequest(KryptonDateTimePicker CallbackDate, KryptonTextBox CallBackDetails, KryptonForm form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_CUSTOMER_CALLBACK_REQUEST_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@CallbackDate", CallbackDate.Value);
                sqlCommand.Parameters.AddWithValue("@CallBackDetails", CallBackDetails.Text);
                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Callback requested successfully!", "Callback Requested", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                form.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failed To Create Callback Request", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
             
            }
        }
        
        public bool CheckCustomerActiveCallBacks()
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_CALLBACKS_ALREADY_ACTIVE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Details - ERR:CALLBCK", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return false;

            }
            finally
            {
                scon.Close();
            }


        }

        public void GetCurrentCallBackForUpdate(KryptonDateTimePicker CurrDate)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_CALLBACK_DATE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CurrDate.Value = sqlDataReader.GetDateTime(0);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Callback Date - ERR:CALLBCK", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;

            }
            finally
            {
                scon.Close();
            }

        }

        public void UpdateCallBackDate(KryptonDateTimePicker NewCallbackDate, KryptonForm form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_CALLBACK_DATE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@NewCallBackDate", NewCallbackDate.Value);

                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Callback Updated successfully!", "Callback Updated", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                form.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failed To Update Callback Request", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
        }

        public void CancelCustomerCallBack()
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_CALLBACK_TO_CANCELLED_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);

                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Callback Cancelled!", "Callback Cancelled", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failed To Cancel Callback Request", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
        }

        public void GetCustomerCallbacksViaAgent(KryptonDataGridView DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_CALLBACKS_VIA_AGENT_SP ", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DGV.DataSource = customers;
                    }
                    DGV.ReadOnly = true;
                    DGV.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DGV.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    DGV.AllowUserToOrderColumns = false;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        #endregion

    }
}
