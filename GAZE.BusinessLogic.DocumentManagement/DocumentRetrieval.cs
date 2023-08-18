using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace GAZE.BusinessLogic.DocumentManagement
{
    public class DocumentRetrieval
    {

        #region Declarations
        private readonly static string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        public static string FilePathToOpen;
        private readonly DocumentConfiguration DocumentConfiguration = new DocumentConfiguration();
        public List<string> AcceptedFileTypes = new List<string>();
        #endregion

        #region Methods
        public void PopulateAcceptedFileTypes()
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("sec.SELECT_ACCEPTED_FILE_TYPES_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    string FileType = sqlDataReader.GetString(0);
                    AcceptedFileTypes.Add(FileType);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
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
            GetFilePathForValidation(DocumentID);

            string FilePath = GetFilePathForValidation(DocumentID);
            try
            {
                //Check if the file path is NULL
                if (string.IsNullOrEmpty(FilePath))
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path is empty", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }

                ///Check if the FilePath exists
                if (!File.Exists(FilePath))
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path does not exist\n\n" + FilePath, "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }
                ///Check if the FileName contains invalid Characters
                string fileName = Path.GetFileName(FilePath);
                if (string.IsNullOrEmpty(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path does not contain a valid name\n\n" + FilePath, "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }
                ///Check if the FilePath contains invalid Characters
                string directoryName = Path.GetDirectoryName(FilePath);
                if (string.IsNullOrEmpty(directoryName) || directoryName.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    KryptonMessageBox.Show("Failed to retrieve document\n\nThe file path provided does not is not a valid directory\n\n" + FilePath + "\n\n$\"Invalid directory path: '{directoryName}'.\";", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                    return false;
                }

                //All Checks Passed, the file and file path are valid
                //MessageBox.Show("File is Valid");
                FilePathToOpen = FilePath;
                return true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);

                return false;
            }
        }

        public void OpenCustomerDocument(string customerDocument, int DocumentID)
        {
            if (ValidateFilePath(DocumentID) == true)
            {
                try
                {
                    Process.Start(FilePathToOpen);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Error: File path is null.");
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    KryptonMessageBox.Show("Error: File not found or cannot be opened.", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);

                }
                catch (ObjectDisposedException)
                {
                    KryptonMessageBox.Show("Error: Process has already exited.", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);

                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show($"An error occurred while opening the document: {ex.Message}", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);

                }
            }
            else
            {
                KryptonMessageBox.Show("An unknown error has occurred. Please contact your system Administrator", "Document Retrieval Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
            }



        }

        //THIS NEEDS TO BE FIXED
        private bool CheckDocumentSize(string filesize)
        {
            try
            {
                long maxFileSize = 2 * 1024 * 1024;

                FileInfo fileInfo = new FileInfo(filesize);
                long fileSizeInBytes = fileInfo.Length;
                long filesizeupdated = fileSizeInBytes * 1024 * 1024;
                if (filesizeupdated > maxFileSize)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Document Size Check Exception: " + Environment.NewLine + ex.Message, "Document Upload Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return false;

            }

        }

        public void UploadCustomerDocument(string DocumentType, string DocumentName, string DocumentLocation, string DocumentSize, string OldFilePath)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            if (CheckForDuplicateDocuments(DocumentName) == true)
            {
                return;
            }
            if (!AcceptedFileTypes.Contains(DocumentType))
            {
                KryptonMessageBox.Show($"Error: {DocumentType} is not supported\n\n Please upload a supported File Type or contact your System Administrator", "Document Upload Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                return;
            }
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_CUSTOMER_DOCUMENT_SP", SQLConnection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@DocumentType", DocumentType);
                sqlCommand.Parameters.AddWithValue("@DocumentName", DocumentName);
                sqlCommand.Parameters.AddWithValue("@DocumentLocation", DocumentLocation);
                sqlCommand.Parameters.AddWithValue("@DocumentSize", DocumentSize);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                File.Copy(OldFilePath, DocumentLocation);
                KryptonMessageBox.Show("Document Successfully Uploaded! \n\nDocument:" + DocumentName + " has been uploaded", "Document Uploaded", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
            }
            catch (Exception)
            {
                KryptonMessageBox.Show("Error: Unable to upload document", "Document Upload Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, KryptonMessageBoxDefaultButton.Button3, 0, false, false);
                //throw;
            }
            finally
            {
                SQLConnection.Close();
            }
        }

        public bool CheckForDuplicateDocuments(string DocumentName)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_DUPLICATE_CUSTOMER_DOCUMENTS_SP", SQLConnection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@DocumentName", DocumentName);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    KryptonMessageBox.Show("A Document with the name " + DocumentName + " already exists. \n\nPlease either rename the document" +
                        " or contact your System Administrator", "Document Upload Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                    return true;


                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }

            finally
            {
                SQLConnection.Close();
            }
        }

        public void GetAcceptableFileTypesForHelpPage(KryptonDataGridView HelpDataGrid)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);

            try
            {
                SQLConnection.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_HELP_PAGE_ACCEPTABLE_FILE_TYPES_SP", SQLConnection))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        HelpDataGrid.DataSource = customers;
                    }
                    HelpDataGrid.ReadOnly = true;
                    HelpDataGrid.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in HelpDataGrid.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    HelpDataGrid.AllowUserToOrderColumns = false;
                    HelpDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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

