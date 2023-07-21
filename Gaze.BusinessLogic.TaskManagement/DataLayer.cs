using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Controls;
using Krypton.Toolkit.Suite.Extended.Messagebox;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Gaze.BusinessLogic.TaskManagement
{
    public class DataLayer
    {
        #region Declarations
        private readonly static string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private readonly InfoSec InfoSec = new InfoSec();
        private readonly SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
        private readonly TaskControlAdmin taskControlAdmin = new TaskControlAdmin();
        private readonly NoteDataLayer noteDataLayer = new NoteDataLayer();
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
                using (SqlCommand SQLCommand = new SqlCommand("dbo.SELECT_TASKS_ACTIVE_TASK_FOR_CUSTOMER_SP", SQLConnection))
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
                using (SqlCommand SQLCommand = new SqlCommand("dbo.SELECT_TASKS_CLOSED_TASK_FOR_CUSTOMER_SP", SQLConnection))
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
                using (SqlCommand SQLCommand = new SqlCommand("dbo.SELECT_TASKS_CANCELLED_TASK_FOR_CUSTOMER_SP", SQLConnection))
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
        /// Method used to create a new CustomerTask
        /// </summary>
        /// <param name="TaskType"></param>
        /// <param name="TaskPriority"></param>
        /// <param name="TaskDescription"></param>
        /// <param name="TaskDetails"></param>
        /// <param name="TaskDueDate"></param>
        /// <exception cref="SqlException"></exception>
        public void CreateNewCustomerTask(KryptonComboBox TaskType, KryptonComboBox TaskPriority, KryptonTextBox TaskDescription,
            KryptonRichTextBoxExtended TaskDetails, KryptonDateTimePicker TaskDueDate, [Optional] KryptonForm FormtoClose)
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
            if (TaskDueDate.Value <= DateTime.Now)
            {
                KryptonMessageBox.Show("You cannot create a task with a due date in the past. Please check and try again",
                    "Validation Failure",
                    MessageBoxButtons.OK,
                    KryptonMessageBoxIcon.Error,
                    0, 0, false, false, false, false, null);
                return;
            }
            try
            {
                SQLConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_TASK_NEW_CUSTOM_CUSTOMER_TASK_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
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
                if (FormtoClose == null)
                {

                }
                else
                {
                    FormtoClose.Close();
                }

            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception Ex)
            {
                KryptonMessageBox.Show(Ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();

            }
        }
        /// <summary>
        /// Method used to get a count of selected customers Open Tasks
        /// </summary>
        /// <param name="CountTextBox">Control to display the Count</param>
        public void GetCustomerOpenTaskCount(KryptonTextBox CountTextBox)
        {
            try
            {
                SQLConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_TASKS_COUNT_OF_OPEN_CUSTOMER_TASKS_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int valie = sqlDataReader.GetInt32(0);
                    CountTextBox.Text = valie.ToString();

                }
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception Ex)
            {
                KryptonMessageBox.Show(Ex.Message + "\n\nFailed to get customer Task Count", "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();

            }
        }
        /// <summary>
        /// Method to retrieve the CustomerID and Task Descrption for the task Overview
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="TaskDescription"></param>
        public void GetCustomerIDAndTaskDescriptionForOverview(KryptonTextBox CustomerID, KryptonTextBox TaskDescription)
        {
            try
            {
                SQLConnection.Open();
                SqlCommand sqlcommand = new SqlCommand("dbo.SELECT_TASKS_CUSTOMER_ID_TASK_DESC_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlcommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlcommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    int value = sqlDataReader.GetInt32(0);
                    CustomerID.Text = value.ToString();
                    TaskDescription.Text = sqlDataReader[1].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        public void GetOpenedTaskDetailsForOverview(KryptonTextBox TaskDescription, KryptonComboBox TaskType, KryptonRichTextBoxExtended TaskDetails,
                                                    KryptonComboBox TaskPriority, KryptonDateTimePicker TaskDueDate, KryptonTextBox TaskAttempts,
                                                    KryptonComboBox TaskStatusName, KryptonCheckBox ActiveFlag, KryptonComboBox AssignedTo)
        {

            try
            {
                SQLConnection.Open();
                SqlCommand sqlcommand = new SqlCommand("dbo.SELECT_TASK_DETAILS_OVERVIEW_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlcommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlcommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    TaskDescription.Text = sqlDataReader[0].ToString();
                    TaskType.SelectedItem = sqlDataReader[1].ToString();
                    TaskDetails.Text = sqlDataReader[2].ToString();
                    TaskPriority.Text = sqlDataReader[3].ToString();
                    DateTime date = DateTime.Parse(sqlDataReader[4].ToString());
                    TaskDueDate.Value = date;

                    TaskAttempts.Text = sqlDataReader[5].ToString();
                    TaskStatusName.SelectedItem = sqlDataReader[6].ToString();
                    if (sqlDataReader[7].ToString() == "1")
                    {
                        ActiveFlag.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        ActiveFlag.CheckState = CheckState.Unchecked;
                    }
                    AssignedTo.SelectedItem = sqlDataReader[8].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                SQLConnection.Close();
            }
        }
        /// <summary>
        /// Method used to record a task attempt
        /// </summary>
        /// <exception cref="SqlException"></exception>
        /// <exception cref="Exception"></exception>
        public void UpdateTaskAttempts(string ExtraDetails)
        {
            try
            {
                SQLConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_TASKS_UPDATE_TASK_ATTEMPT_COUNT_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@NoteDetailsExtra", ExtraDetails);
                sqlCommand.ExecuteReader();
                string Message = "Task Attempt has been recorded";
                string Title = "Task Attempted";
                KryptonMessageBox.Show(Message, Title, MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);

            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("SQL Exception Caught \n\n" + SQLException.Message, "SQL Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show("Exception Thrown \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        public void UpdateTaskStatusToCompleted([Optional] KryptonForm FormName)
        {
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_TASKS_SET_TASK_STATUS_COMPLETED_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                string Message = "Task marked as completed. This Window Will Now Close!";
                string Title = "Task Updated";
                KryptonMessageBox.Show(Message, Title, MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                FormName.Close();
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("SQL Exception Caught \n\n" + SQLException.Message, "SQL Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Exception Thrown \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }

        }

        public void UpdateTaskStatusToPending([Optional] KryptonForm FormName, KryptonRichTextBoxExtended ReasonForPending)
        {
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_TASKS_SET_TASK_STATUS_PENDING_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@ReasonForPending",ReasonForPending.Text);
                sqlCommand.ExecuteReader();
                string Message = "Task marked as pending. This Window Will Now Close!";
                string Title = "Task Updated";
                KryptonMessageBox.Show(Message, Title, MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                FormName.Close();
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("SQL Exception Caught \n\n" + SQLException.Message, "SQL Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Exception Thrown \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }

        }

        public void UpdateTaskStatusToCancelled([Optional] KryptonForm FormName)
        {

            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_TASKS_SET_TASK_STATUS_CANCELLED_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                
                string NoteDetails = KryptonInputBox.Show("Please enter a brief reason for cancelling this task", "Reason for cancelling?", default, "Brief Details", default, default, default);
                noteDataLayer.InsertNewTaskNote("TSKUPDATE", NoteDetails);

                string Message = "Task marked as cancelled. This Window Will Now Close!";
                string Title = "Task Updated";
                KryptonMessageBox.Show(Message, Title, MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                FormName.Close();
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("SQL Exception Caught \n\n" + SQLException.Message, "SQL Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Exception Thrown \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }

        }

        public void UpdateTaskStatusToActive([Optional] KryptonForm FormName)
        {

            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_TASKS_SET_TASK_STATUS_ACTIVE_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();

                string NoteDetails = "Task Status Changed: Status Active";
                noteDataLayer.InsertNewTaskNote("TSKUPDATE", NoteDetails);

                string Message = "Task marked as Active. This Window Will Now Close!";
                string Title = "Task Updated";
                KryptonMessageBox.Show(Message, Title, MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                FormName.Close();
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("SQL Exception Caught \n\n" + SQLException.Message, "SQL Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Exception Thrown \n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }

        }

        public void UpdateTaskDetails(KryptonComboBox Agent, KryptonRichTextBoxExtended TaskDetails, 
                                      KryptonDateTimePicker DueDate, [Optional] KryptonForm FormToClose)
        {
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_TASKS_UPDATE_TASK_DETAILS_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                sqlCommand.Parameters.AddWithValue("@Agent", Agent.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@TaskDetails", TaskDetails.Text);
                sqlCommand.Parameters.AddWithValue("@DueDate", DueDate.Value);
                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Great - This task has now been updated. \n\n Form will now close", "Success!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
                Thread.Sleep(725);
                FormToClose.Close();


            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("Task Failed To Update\n\n" + SQLException.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show("Task Failed To Update\n\n" + e.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }
        }

    }
    #endregion
}

