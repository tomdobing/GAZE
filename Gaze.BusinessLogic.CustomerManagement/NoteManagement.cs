using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.CustomerManagement
{
    public class NoteManagement
    {

        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        #endregion



        #region Methods
        public void GetCustomerNameForNotes(KryptonTextBox CustomerName, KryptonTextBox CustomerID, KryptonTextBox PolicyID)
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[SELECT_CUSTOMER_DETAILS_FOR_NEW_NOTE_SP]", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    CustomerName.Text = sqlDataReader[0].ToString();
                    PolicyID.Text = sqlDataReader[1].ToString();
                    CustomerID.Text = sqlDataReader[2].ToString();

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Name Variable", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;

            }
            finally
            {
                scon.Close();
            }
        }

        public void PopulateNoteTable(KryptonDataGridView NoteDataGrid)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_NOTES_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        NoteDataGrid.DataSource = customers;
                    }
                    NoteDataGrid.ReadOnly = true;
                    NoteDataGrid.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in NoteDataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    NoteDataGrid.AllowUserToOrderColumns = false;
                    NoteDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void InsertNewNote(KryptonComboBox NoteDescription, KryptonTextBox NoteDetails, [Optional] KryptonForm Form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_NOTE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                sqlCommand.Parameters.AddWithValue("@NoteDescription", NoteDescription.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@NoteDetails", NoteDetails.Text);
                sqlCommand.Parameters.AddWithValue("@CreatedBy", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                MessageBox.Show("Note Inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert note \n\n" + ex.Message, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
