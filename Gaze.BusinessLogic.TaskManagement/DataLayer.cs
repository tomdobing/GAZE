using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.TaskManagement
{
    public class DataLayer
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        InfoSec InfoSec = new InfoSec();
        #endregion


        #region Methods
        /// <summary>
        /// Populate Active Tasks for the Selected Customer
        /// </summary>
        /// <param name="DataGrid">DataGridView to be populated</param>
        /// <exception cref="SqlException"><see cref=""/></exception>
        public void PopulateActiveTasksForCustomer(KryptonDataGridView DataGrid)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                using (SqlCommand SQLCommand = new SqlCommand("dbo.SELECT_ACTIVE_TASK_FOR_CUSTOMER_SP", SQLConnection))
                {
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SQLCommand))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DataGrid.DataSource = customers;
                    }
                    DataGrid.ReadOnly = true;
                    DataGrid.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    DataGrid.AllowUserToOrderColumns = false;
                    DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                }
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            finally
            {
                SQLConnection.Close();
            }

        }

        /// <summary>
        /// Populate Closed Tasks for the Selected Customer
        /// </summary>
        /// <param name="DataGrid">DataGridView to be populated</param>
        /// <exception cref="SqlException"><see cref=""/></exception>
        public void PopulateClosedTasksForCustomer(KryptonDataGridView DataGrid)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                using (SqlCommand SQLCommand = new SqlCommand("dbo.SELECT_CLOSED_TASK_FOR_CUSTOMER_SP", SQLConnection))
                {
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(SQLCommand))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DataGrid.DataSource = customers;
                    }
                    DataGrid.ReadOnly = true;
                    DataGrid.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    DataGrid.AllowUserToOrderColumns = false;
                    DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                }
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            finally
            {
                SQLConnection.Close();
            }

        }
        #endregion
    }
}
