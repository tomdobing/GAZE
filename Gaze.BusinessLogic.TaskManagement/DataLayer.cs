using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.TaskManagement
{
    public class DataLayer
    {
        #region Declarations
        private readonly static string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        InfoSec InfoSec = new InfoSec();
        private readonly SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
        private readonly TaskControlAdmin taskControlAdmin = new TaskControlAdmin();
        #endregion


        #region Methods
        /// <summary>
        /// Populate Active Tasks for the Selected Customer
        /// </summary>
        /// <param name="DataGrid">DataGridView to be populated</param>
        /// <exception cref="SqlException"><see cref=""/></exception>
        public void PopulateActiveTasksForCustomer(KryptonDataGridView DataGrid)
        {
            ///SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
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
                ///SQLConnection.Open();
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

        /// <summary>
        /// Populate Cancelled Tasks for the Selected Customer
        /// </summary>
        /// <param name="DataGrid">DataGridView to be populated</param>
        /// <exception cref="SqlException"><see cref=""/></exception>
        public void PopulateCancelledTasksForCustomer(KryptonDataGridView DataGrid)
        {
            //SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                using (SqlCommand SQLCommand = new SqlCommand("dbo.SELECT_CANCELLED_TASK_FOR_CUSTOMER_SP", SQLConnection))
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

        public void CreateNewCustomerTask(KryptonComboBox TaskType, KryptonComboBox TaskPriority, KryptonTextBox TaskDescription,
            KryptonRichTextBoxExtended TaskDetails, KryptonDateTimePicker TaskDueDate)
        {
            if (string.IsNullOrEmpty(TaskType.SelectedIndex.ToString()) ||
                string.IsNullOrEmpty(TaskPriority.SelectedIndex.ToString()) ||
                string.IsNullOrEmpty(TaskDescription.Text) ||
                string.IsNullOrEmpty(TaskDetails.Text) ||
                string.IsNullOrEmpty(TaskDueDate.Value.ToString()))
            {
                KryptonMessageBox.Show("You did not complete all required fields. Please check and try again, or contact your System Administrator",
                    "Validation Failure",
                    MessageBoxButtons.OK,
                    KryptonMessageBoxIcon.Error,
                    0, 0, false, false, false, false, null);
                return;
            }
            try
            {
                SQLConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_CUSTOM_CUSTOMER_TASK_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", 1);
                sqlCommand.Parameters.AddWithValue("@TaskType", TaskType.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@TaskPriority", TaskPriority.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@TaskDescription", TaskDescription.Text);
                sqlCommand.Parameters.AddWithValue("@TaskDetails", TaskDetails.Text);
                sqlCommand.Parameters.AddWithValue("@TaskDueDate", TaskDueDate.Value);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                string Message = "Task has been created with a due date of: " + TaskDueDate.Value + "\n\nTask Created";
                string Title = "Task Created";
                KryptonMessageBox.Show(Message, Title, MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                taskControlAdmin.ResetCreateCustomerTaskForm(TaskType, TaskPriority, TaskDescription, TaskDetails, TaskDueDate);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
