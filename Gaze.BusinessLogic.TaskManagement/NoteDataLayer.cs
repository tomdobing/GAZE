using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.TaskManagement
{


    public class NoteDataLayer
    {

        #region Declarations
        private readonly static string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private readonly InfoSec InfoSec = new InfoSec();
        //private readonly SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
        private readonly TaskControlAdmin taskControlAdmin = new TaskControlAdmin();
        #endregion

        #region Methods
        /// <summary>
        /// Method to populate note datagridview
        /// </summary>
        /// <param name="NoteDataGrid">KryptonDataGridView Control</param>
        /// <exception cref="SqlException"></exception>
        /// <exception cref="Exception"></exception>
        public void PopulateTaskOpenTaskNoteDataGrid(KryptonDataGridView NoteDataGrid)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_TASK_NOTES_FOR_TASK_SP", SQLConnection))
                {
                    
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    scmd.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        NoteDataGrid.DataSource = customers;
                    }
                    SQLConnection.Close();
                    NoteDataGrid.ReadOnly = true;
                    NoteDataGrid.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in NoteDataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    NoteDataGrid.AllowUserToOrderColumns = false;
                    NoteDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    NoteDataGrid.ScrollBars = ScrollBars.Both;
                }
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "Failure to populate Customer Notes", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to populate Customer Notes", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        public void PopulateControlsFromSelectedNOte(KryptonTextBox NoteDetails, KryptonTextBox NoteDescription, KryptonLabel CreatedDate, KryptonLabel CreatedBy)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_TASK_NOTES_FOR_TASK_SP", SQLConnection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@TaskID", InfoSec.GlobalTaskID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    //string ConfigValue = sqlDataReader["ConfigValue"].ToString();
                    //int ConvertedValue = Convert.ToInt32(ConfigValue);

                    NoteDescription.Text = sqlDataReader[1].ToString();
                    NoteDetails.Text = sqlDataReader[2].ToString();
                    CreatedBy.Text = sqlDataReader[3].ToString();
                    CreatedDate.Text = sqlDataReader[4].ToString();


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


    }


    #endregion
}

