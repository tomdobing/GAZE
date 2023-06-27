using Gaze.BusinessLogic.Exceptions;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        public void PopulateCountried(KryptonComboBox Combobox)
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
        #endregion
    }
}
