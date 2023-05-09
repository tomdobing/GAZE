using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.CustomerManagement
{
    public class SecureConfig
    {

        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private DateTime date = new DateTime();
        #endregion


        #region Methods
        public void AdminPopulateNotesFootPrints(KryptonDataGridView NoteDataGrid)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("sec.SELECT_AUDIT_FOOTPRINT_SP", scon))
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
        #endregion
    }
}
