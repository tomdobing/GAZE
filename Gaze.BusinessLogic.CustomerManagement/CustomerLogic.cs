using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.CustomerManagement
{
    /// <summary>
    /// Class used to store all Logic relating to Customers
    /// </summary>
    public class CustomerLogic
    {///
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        private readonly DateTime date = new DateTime();
        private readonly FormSettings formSettings = new FormSettings();
        #endregion

        #region Methods
        /// <summary>
        /// Method used to retrieve the customer History
        /// </summary>
        /// <param name="CustomerName"></param>
        /// <param name="CustomerID"></param>
        /// <param name="PolicyCount"></param>
        /// <exception cref="SqlException"?>SQLException caught</exception>
        public void GetCustomerHistoryDetails(KryptonTextBox CustomerName, KryptonTextBox CustomerID, KryptonTextBox PolicyCount)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_HISTORY_DETAILS_FOR_FORM_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CustomerName.Text = sqlDataReader[0].ToString();
                    CustomerID.Text = sqlDataReader[1].ToString();
                    PolicyCount.Text = sqlDataReader[2].ToString();
                }
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message + "\n\n" + SQLException.InnerException, "A SQL Exception Occurred", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Details", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (scon != null)
                {
                    scon.Close();
                }
            }
        }
        /// <summary>
        /// Method used to Check if any restrictions are in place preventing access to the Customer Account
        /// </summary>
        /// <param name="FormToManage">[optional] used to manage the form calling the method</param>
        /// <returns></returns>
        public bool CheckForAccountAccessRestrictions([Optional] KryptonForm FormToManage)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("sec.SELECT_CUSTOMER_RESTRICTIONS_ACCESS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    MessageBox.Show(sqlDataReader[0].ToString(), "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //FormToManage.Dispose();
                    return true;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to check for restrictions", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return true;

            }
            finally
            {
                if (scon != null)
                {
                    scon.Close();
                }

            }
            return false;

        }

        /// <summary>
        /// Method to restrict customers account
        /// </summary>
        /// <param name="FormtoClose">Form to close after account restriction</param>
        public void RestrictCustomerAccount(KryptonForm FormtoClose)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("sec.UPDATE_CUSTOMER_RESTRICT_ACCESS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Account with CustomerID:" + InfoSec.GlobalCustomerID + " has now been restricted!", "Account Restricted", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
                FormtoClose.Close();
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show(SQLException.Message, "Failure to Set Restrictions", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to Set restrictions", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);


            }
            finally
            {
                if (scon != null)
                {
                    scon.Close();
                }

            }


        }

        /// <summary>
        /// Method called to retrieve Customer Name .
        /// </summary>
        /// <param name="CustomerName">Label of where to display the customers name</param>
        public void GetCustomerNameForUpdateAddress(KryptonLabel CustomerName)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[SELECT_CUSTOMER_NAME_FOR_ADDRESS_UPDATES_SP]", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    CustomerName.Text = "Address update for " + sqlDataReader[0].ToString();

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve Customer Name variable", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (scon != null)
                {
                    scon.Close();
                }
            }


        }

        /// <summary>
        /// Method used to Get Customer address history 
        /// </summary>
        /// <param name="AddressLine1"></param>
        /// <param name="AddressLine2"></param>
        /// <param name="Town"></param>
        /// <param name="postalCode"></param>
        /// <param name="Country"></param>
        public void GetCustomerAddressForUpdateAddress(KryptonTextBox AddressLine1, KryptonTextBox AddressLine2, KryptonTextBox Town,
                                                        KryptonTextBox postalCode, KryptonComboBox Country)
        {
            if (InfoSec.GlobalCustomerID == null)
            {
                return;
            }
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[SELECT_CUSTOMER_ADDRESS_SP]", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    AddressLine1.Text = sqlDataReader[0].ToString();
                    AddressLine2.Text = sqlDataReader[1].ToString();
                    Town.Text = sqlDataReader[2].ToString();
                    postalCode.Text = sqlDataReader[3].ToString();
                    Country.SelectedText = sqlDataReader[4].ToString();

                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve customers address details", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (scon != null)
                {
                    scon.Close();
                }
            }



        }

        /// <summary>
        /// Method used to update customers address, Form will close upon submit                                                                                          
        /// </summary>
        /// <param name="AddressLine1"></param>
        /// <param name="AddressLine2"></param>
        /// <param name="Town"></param>
        /// <param name="PostalCode"></param>
        /// <param name="Country"></param>
        public void UpdateCustomerAddressDetails(string AddressLine1, string AddressLine2, string Town,
                                                 string PostalCode, KryptonComboBox Country)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {

                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_ADDRESS_DETAILS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@AddressLine1", AddressLine1);
                sqlCommand.Parameters.AddWithValue("@AddressLine2", AddressLine2);
                sqlCommand.Parameters.AddWithValue("@Town", Town);
                sqlCommand.Parameters.AddWithValue("@PostalCode", PostalCode);
                sqlCommand.Parameters.AddWithValue("@Country", Country.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", InfoSec.GlobalUsername);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                KryptonMessageBox.Show("Address Updated \n\nCustomer Account Will Now Close!", "Address Updated", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
                formSettings.CloseOpenForms("UpdateAddressDetails");
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failed to update customer address details", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return;
            }
            finally
            { 
                if (scon != null)
                {
                    scon.Close();
                }
            
            }
        }

        #endregion

    }
}