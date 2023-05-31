using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Controls;
using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.TaskManagement
{
    public class TaskControlAdmin
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        ExceptionHandler ExceptionHandler
        {
        get; set; }
        
        #endregion

        #region Methods
        /// <summary>
        /// Method to populate the ComboBox for Customer Task Type. The values are fed from the database
        /// </summary>
        /// <param name="TaskTypeCombobox">KryptonCombobox</param>
        /// <exception cref="SqlException">Thrown when a SQL Error occurs.</exception>
        public void PopulateTaskTypeCombobox(KryptonComboBox TaskTypeCombobox)
        {
            
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                TaskTypeCombobox.Items.Add("");
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CONTROL_VALUES_TASK_TYPE_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    TaskTypeCombobox.Items.Add(sqlDataReader[0].ToString());
                }
            }
            catch (SqlException SQLException)
            {
                
                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message + "\n\nFailed to populate TaskTypeCombobox", "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        public void PopulatePriorityFromTaskType(KryptonComboBox TaskPriority, KryptonComboBox TaskNameToGetPriority)
        {

            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CONTROL_VALUES_TASK_TYPE_PRIORITY_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@TypeName", TaskNameToGetPriority.SelectedItem);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    TaskPriority.Text = sqlDataReader[0].ToString();
                }
                
            }
            catch (SqlException SQLException)
            {

                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message + "\n\nFailed to populate TaskTypeCombobox", "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        public void PopulatePriorities(KryptonComboBox TaskPriority)
        {

            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {

                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CONTROL_VALUES_TASK_TYPE_ALL_PRIORITIES_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                TaskPriority.Items.Add("");
                while (sqlDataReader.Read())
                {
                    TaskPriority.Items.Add(sqlDataReader[0].ToString());
                }

            }
            catch (SqlException SQLException)
            {

                KryptonMessageBox.Show(SQLException.Message, "SQL Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message + "\n\nFailed to populate TaskTypeCombobox", "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            finally
            {
                SQLConnection.Close();
            }
        }
        /// <summary>
        /// Used to reset the form after successfully creating a task
        /// </summary>
        /// <param name="TaskType"></param>
        /// <param name="TaskPriority"></param>
        /// <param name="TaskDescription"></param>
        /// <param name="TaskDetails"></param>
        /// <param name="TaskDueDate"></param>
        public void ResetCreateCustomerTaskForm(KryptonComboBox TaskType, KryptonComboBox TaskPriority, KryptonTextBox TaskDescription,
            KryptonRichTextBoxExtended TaskDetails, KryptonDateTimePicker TaskDueDate)
        {

            try
            {
                TaskType.SelectedIndex = 0;
                TaskPriority.SelectedIndex = 0;
                TaskDescription.Text = null;
                TaskDetails.Text = null;
                TaskDueDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("We encountered an error when resetting the form\n\n" + ex.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
        
        }
        #endregion
    }
}
