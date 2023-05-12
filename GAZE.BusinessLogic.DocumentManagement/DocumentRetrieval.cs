using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace GAZE.BusinessLogic.DocumentManagement
{
    public class DocumentRetrieval
    {

        #region Declarations
        private readonly static string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        #endregion

        #region Methods

        public void GetCustomerDocuments(KryptonDataGridView DocumentDataGrid)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);

            try
            {
                SQLConnection.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_DOCUMENTS_SP", SQLConnection))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DocumentDataGrid.DataSource = customers;
                    }
                    DocumentDataGrid.ReadOnly = true;
                    DocumentDataGrid.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DocumentDataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    DocumentDataGrid.AllowUserToOrderColumns = false;
                    DocumentDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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



        private static string GetFilePathForValidation(int DocumentID)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            //FilePath = string.Empty;
            try
            {
                
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_DOCUMENT_FILE_PATH_SP", SQLConnection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@DocumentID", DocumentID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    //string ConfigValue = sqlDataReader["ConfigValue"].ToString();
                    //int ConvertedValue = Convert.ToInt32(ConfigValue);
                    return (string)sqlDataReader.GetValue(0);
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
            return null;
        }

        public static bool ValidateFilePath(int DocumentID)
        {
           string filepath = DocumentRetrieval.GetFilePathForValidation(DocumentID);
            try
            {
                if (string.IsNullOrEmpty(filepath))
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path is empty", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }

                if (!File.Exists(filepath))
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path does not exist\n\n" + filepath, "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }

                string fileName = Path.GetFileName(filepath);
                if (string.IsNullOrEmpty(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path does not contain a valid name\n\n" + filepath, "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }

                string directoryName = Path.GetDirectoryName(filepath);
                if (string.IsNullOrEmpty(directoryName) || directoryName.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path provided does not is not a valid directory\n\n" + filepath + "\n\n$\"Invalid directory path: '{directoryName}'.\";", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }

                //All Checks Passed, the file and file path are valid
                MessageBox.Show("File is Valid");
                return true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);

                return false;
            }
        }
    }
    #endregion



}

