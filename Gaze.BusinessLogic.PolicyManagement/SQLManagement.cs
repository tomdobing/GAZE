using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Gaze.BusinessLogic.PolicyManagement
{
    /// <summary>
    /// This Class is used for everything related to Policy Management via SQL
    /// </summary>
    public class SQLManagement
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        InfoSec InfoSec = new InfoSec();
        #endregion


        #region Methods

        public void GetPolicyDataViaPolicyID(System.Windows.Forms.TextBox CustomerFullName, KryptonTextBox Title, KryptonTextBox Firstname, KryptonTextBox Surname, KryptonMaskedTextBox DOB, KryptonTextBox ContactNumber, KryptonTextBox Altercontact,
                                         KryptonTextBox EmailAddress, KryptonTextBox AddressLine1, KryptonTextBox AddressLine2, KryptonTextBox Town, KryptonTextBox Postalcode, KryptonTextBox Country, System.Windows.Forms.TextBox PolicyID,
                                         Label PolicyStatus, KryptonTextBox Deactivation, KryptonMaskedTextBox PEffStart, KryptonMaskedTextBox PEffEnd, KryptonTextBox ProductName, KryptonTextBox ProductDesc, KryptonTextBox ProductPrice,
                                         KryptonMaskedTextBox EffStart, System.Windows.Forms.TextBox CustomerID, KryptonMaskedTextBox ProductEffEnd, [Optional] KryptonTextBox PolicyID1, [Optional] KryptonTextBox StatusID1)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            DateTime date = new DateTime();
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_POLICIES_FOR_DETAILS_POPULATION", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CustomerFullName.Text = sqlDataReader[0].ToString();
                    Title.Text = sqlDataReader[1].ToString();
                    Firstname.Text = sqlDataReader[2].ToString();
                    Surname.Text = sqlDataReader[3].ToString();
                    date = sqlDataReader.GetDateTime(4);
                    DOB.Text = date.ToShortDateString();
                    //DateTime DOBText = sqlDataReader.GetDateTime(4);
                    //DOB.Text = DOBText.ToShortDateString();
                    ContactNumber.Text = sqlDataReader[5].ToString();
                    Altercontact.Text = sqlDataReader[6].ToString();
                    EmailAddress.Text = sqlDataReader[7].ToString();
                    AddressLine1.Text = sqlDataReader[8].ToString();
                    AddressLine2.Text = sqlDataReader[9].ToString();
                    Town.Text = sqlDataReader[10].ToString();
                    Postalcode.Text = sqlDataReader[11].ToString();
                    Country.Text = sqlDataReader[12].ToString();
                    PolicyID.Text = sqlDataReader[13].ToString();
                    PolicyID1.Text = sqlDataReader[13].ToString();
                    switch (sqlDataReader[14].ToString())
                    {
                        case "Active":
                            PolicyStatus.Text = "Active";
                            PolicyStatus.ForeColor = System.Drawing.Color.Green;
                            StatusID1.Text = "Active";
                            break;
                        case "Cancelled":
                            PolicyStatus.Text = "Cancelled";
                            PolicyStatus.ForeColor = System.Drawing.Color.Red;
                            StatusID1.Text = "Cancelled";
                            break;
                        case "Pending":
                            PolicyStatus.Text = "Pending";
                            PolicyStatus.ForeColor = System.Drawing.Color.Orange;
                            StatusID1.Text = "Pending";
                            break;
                        case "Removed":
                            PolicyStatus.Text = "Removed";
                            PolicyStatus.ForeColor = System.Drawing.Color.DarkRed;
                            StatusID1.Text = "Removed";
                            break;
                        case "Review":
                            PolicyStatus.Text = "Review";
                            PolicyStatus.ForeColor = System.Drawing.Color.Orange;
                            StatusID1.Text = "Review";
                            break;
                        case "Expired":
                            PolicyStatus.Text = "Expired";
                            PolicyStatus.ForeColor = System.Drawing.Color.Red;
                            StatusID1.Text = "Expired";
                            break;
                        case "OnHoldPayee":
                            PolicyStatus.Text = "OnHoldPayee";
                            PolicyStatus.ForeColor = System.Drawing.Color.Orange;
                            StatusID1.Text = "OnHoldPayee";
                            break;
                        default:
                            PolicyStatus.Text = "UNKNOWN STATUS";
                            PolicyStatus.ForeColor = System.Drawing.Color.Black;
                            StatusID1.Text = "UNKNOWN - CONTACT I.T";
                            break;
                    }
                    Deactivation.Text = sqlDataReader[15].ToString();

                    date = sqlDataReader.GetDateTime(16);
                    PEffStart.Text = date.ToShortDateString();

                    date = sqlDataReader.GetDateTime(17);
                    PEffEnd.Text = date.ToShortDateString();

                    ProductName.Text = sqlDataReader[18].ToString();
                    ProductDesc.Text = sqlDataReader[19].ToString();
                    ProductPrice.Text = sqlDataReader[20].ToString();

                    date = sqlDataReader.GetDateTime(21);
                    EffStart.Text = date.ToShortDateString();

                    CustomerID.Text = sqlDataReader[22].ToString();

                    date = sqlDataReader.GetDateTime(23);
                    ProductEffEnd.Text = date.ToShortDateString();

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }

            finally
            {
                scon.Close();
            }

        }

        public bool CheckIfPolicyIDExists(string PolicyID)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT_CUSTOMER_EXISTS_SP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PolicyID", PolicyID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {

                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                    return false;
                }
                finally
                {

                    connection.Close();

                }

            }


        }


        public void InsertPolicyOverrideNote(KryptonTextBox OldPrice, KryptonTextBox NewPrice)
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
                sqlCommand.Parameters.AddWithValue("@NoteDescription", "PolicyPriceOverride");
                sqlCommand.Parameters.AddWithValue("@NoteDetails", "Price Override from " + OldPrice.Text + " to " + NewPrice.Text);
                sqlCommand.Parameters.AddWithValue("@CreatedBy", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Note Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            finally
            {
                scon.Close();
            }


        }


        public bool CheckCustomerAlreadyActiveProduct(KryptonTextBox ProductName)
        {

            using (SqlConnection connection = new SqlConnection(SQLConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.SELECT_CUSTOMER_ACTIVE_PRODUCT_CHECK_SP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                        command.Parameters.AddWithValue("@ProductName", ProductName.Text);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {

                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                    return false;
                }
                finally
                {

                    connection.Close();

                }

            }


        }

        public void CreateNewCustomerPolicy(KryptonTextBox ProductName, KryptonDateTimePicker StartDate, KryptonForm form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_CUSTOMER_POLICY_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@ProductName", ProductName.Text);
                sqlCommand.Parameters.AddWithValue("@StartDate", StartDate.Value);
                sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Policy Created Successfully", "Policy Created", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                form.Close();
                foreach (KryptonForm item in Application.OpenForms)
                {
                    if (item.Name == "CustomerOverViewV1")
                    {
                        item.Close();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Policy Creation Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

            }
            finally
            {
                scon.Close();
            }



        }

        /// <summary>
        /// Returns the current policy Status
        /// </summary>
        /// <param name="CurrentPolicyStatus"></param>
        public void GetCurrentPolicyStatus(KryptonTextBox CurrentPolicyStatus)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_POLICY_STATUS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CurrentPolicyStatus.Text = sqlDataReader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }

            finally
            {
                scon.Close();
            }


        }

        public void UpdateCustomerPolicyStatus(KryptonComboBox CustomerPolicyStatus, KryptonForm form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_POLICY_STATUS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                sqlCommand.Parameters.AddWithValue("@PolicyStatus", CustomerPolicyStatus.SelectedItem);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Policy Status has been updated to " + CustomerPolicyStatus.SelectedItem, "Policy Status Updated", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                form.Close();
                foreach (KryptonForm item in Application.OpenForms)
                {
                    if (item.Name == "CustomerOverViewV1")
                    {
                        item.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("There was an error trying to update the Policy Status\n\n" + ex.Message, "Policy Status Update Failure", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                throw;
                
            }
            finally 
            {
                scon.Close(); 
            }


        }

        #endregion

    }
}
