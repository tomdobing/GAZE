using Gaze.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krypton.Toolkit;
using Gaze.BusinessLogic.SQLManagement;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.CustomerManagement
{
    public class CustomerHistory
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        #endregion


        public void GetCustomerAddressHistory(KryptonDataGridView DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_HISTORY_ADDRESS_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CUstomerID", InfoSec.GlobalCustomerID);
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

        public void GetCustomerPolicyHistory(KryptonDataGridView DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_HISTORY_POLICIES_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
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

        public void GetCustomerContactHistory(KryptonDataGridView DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_HISTORY_CONTACT_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
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

        public void GetCustomerBillingHistory(KryptonDataGridView DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_HISTORY_BILLING_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
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
    }
}
