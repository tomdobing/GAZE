using Gaze.BusinessLogic.Exceptions;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class ControlManagement
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        #endregion

        #region Methods
        /// <summary>
        /// Used to populate the Title ComboBox on the New Customer form
        /// </summary>
        /// <param name="Combobox">The control holding the title data</param>
        public void PopulateCountries(KryptonComboBox Combobox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_COUNTRIES_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Combobox.Items.Add(sqlDataReader[0].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }
        }

        public void PopulateStatus(MetroComboBox Combobox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_STATUS_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Combobox.Items.Add(sqlDataReader[0].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }
        }

        /// <summary>
        /// Used to populate the Title ComboBox on the New Customer form
        /// </summary>
        /// <param name="Combobox">The control holding the title data</param>
        public void PopulateTitle(KryptonComboBox Combobox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_TITLE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Combobox.Items.Add(sqlDataReader[0].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }
        }

        public void PopulateNoteCategory(KryptonComboBox NoteCatergory)
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_NOTE_CATEGORIES_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    NoteCatergory.Items.Add(sqlDataReader[0].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }
        }

        public void PopulateProductName(KryptonComboBox ProductName)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CONTROL_VALUES_PRODUCT_NAME_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ProductName.Items.Add(sqlDataReader[0].ToString());
                }


            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// Control Method used to populate the Policy Status ComboBox
        /// </summary>
        /// <param name="Combobox"></param>
        /// <exception cref="SqlException">SQL Exception returned upon error</exception>
        public void PopulatePolicyStatus(KryptonComboBox Combobox)
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CONTROL_VALUES_POLICY_STATUS_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Combobox.Items.Add(sqlDataReader[0].ToString());
                }


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to Populate " + Combobox.Name, MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                throw;
            }
        }


        public void SetNoteCategoryToDisabled(string NoteCategoryName)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CONTROL_DISABLE_NOTE_CATEGORY_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@NoteCategoryName", NoteCategoryName);
                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Control Value Disabled", "Disabled", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, KryptonMessageBoxDefaultButton.Button3);
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("Failed to Create Customer:- \n\n" + SQLException.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Failed to Create Customer:- \n\n" + ex.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }

        }
        
        public void CreateNewNoteCategory(string NewCategoryName, string newCategoryDescription, string categoryType)
        {
            SqlConnection SQLConnection = new SqlConnection(SQLConnectionString);
            try
            {
                SQLConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_NOTE_CATEGORY_SP", SQLConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@NewCategoryName", NewCategoryName);
                sqlCommand.Parameters.AddWithValue("@NewCategoryDescription", newCategoryDescription);
                sqlCommand.Parameters.AddWithValue("@CategoryType", categoryType);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                Thread.Sleep(1000);
                KryptonMessageBox.Show("Category Created! Details are as follows: \n\n" + 
                    "Category Name: " + NewCategoryName + "\nCategory Description: " + newCategoryDescription + "\n" +
                    "Category Type: " + categoryType, "Disabled", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, KryptonMessageBoxDefaultButton.Button3);
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("We Encountered an Error While Creating your new Category:- \n\n" + SQLException.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("We Encountered an Error While Creating your new Category:- \n\n" + ex.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            {
                SQLConnection.Close();
            }

        }

        public void PopulateNoteCategoryType(KryptonComboBox CategoryComboBox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CONTROL_VALUE_NOTE_CATEGORY_TYPE", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CategoryComboBox.Items.Add(sqlDataReader[0].ToString());
                }


            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("We Encountered an Error While Creating your new Category:- \n\n" + SQLException.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to Populate " + CategoryComboBox.Name, MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                throw;
            }
            finally
            {
                scon.Close();
            }

        }

        public void PopulateDepartment(KryptonComboBox DepartmentComboBox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_DEPARTMENTS_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    DepartmentComboBox.Items.Add(sqlDataReader[0].ToString());
                }


            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("An exception was thrown while populating Departments:- \n\n CODE: SQL Exception: " + SQLException.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("An exception was thrown while populating Departments: - \n\n CODE: SQL Exception: " + ex.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
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
