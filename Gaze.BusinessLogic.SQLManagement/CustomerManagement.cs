using Gaze.BusinessLogic.Exceptions;
using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.SQLManagement
{/// <summary>
/// Class used for Customer Management, Notes, Searching, New Customers etc
/// </summary>
    public class CustomerManagement
    {

        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();

        #endregion

        #region Methods




        /// <summary>
        /// Function to create a new customer. Also contains Data Validation Methods.
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Firstname"></param>
        /// <param name="surname"></param>
        /// <param name="DOB"></param>
        /// <param name="Contact"></param>
        /// <param name="Email"></param>
        /// <param name="Address"></param>
        /// <param name="Vuln"></param>
        public void CreateNewCustomer(MetroComboBox Title, MetroTextBox Firstname, MetroTextBox surname, MetroDateTime DOB, MetroTextBox Contact, MetroTextBox Email, MetroTextBox AddressLine1, MetroTextBox AddressLine2, MetroTextBox Town, MetroTextBox PostalCode, MetroComboBox Country, [Optional] MetroCheckBox Vuln)
        {
            if (string.IsNullOrEmpty(Title.SelectedIndex.ToString()) ||
                string.IsNullOrEmpty(Firstname.Text) ||
                string.IsNullOrEmpty(surname.Text) ||
                string.IsNullOrEmpty(DOB.Value.ToShortDateString()) ||
                string.IsNullOrEmpty(Contact.Text) ||
                string.IsNullOrEmpty(Email.Text) ||
                string.IsNullOrEmpty(AddressLine1.Text) ||
                string.IsNullOrEmpty(AddressLine2.Text) ||
                string.IsNullOrEmpty(Town.Text) ||
                string.IsNullOrEmpty(PostalCode.Text) ||
                string.IsNullOrEmpty(Country.SelectedValue.ToString()))
            {
                messageHandler.ReturnInfoBox("Data Validation Failure! \n\nYou have not completed all required fields. Please check and try again!", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Error);

            }
            else
            {
                exceptionThrown.ThrowNewException("This is a message", "this is a stack trace", "Text");
            }
        }


        /// <summary>
        /// Gets customer data via their contact number
        /// </summary>
        /// <param name="ContactNumber">Contact number to search for</param>
        /// <param name="DGV">DatagridView to return the data into</param>
        public void GetCustomerDataByContactNumber(string ContactNumber, DataGridView DGV, [Optional] GroupBox GB)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("SELECT_CUSTOMER_TITLE_BY_CONTACT_NUMBER_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DGV.DataSource = customers;
                    }
                    DGV.ReadOnly = true;
                    DGV.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DGV.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    //DGV.AllowUserToOrderColumns = false;
                    //GB.Show();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetCustomerNotesForDataGrid(MetroGrid DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("SELECT_NOTE_BY_CUSTOMER_ID", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CUstomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DGV.DataSource = customers;
                    }
                    DGV.ReadOnly = true;
                    DGV.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DGV.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    DGV.AllowUserToOrderColumns = false;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetCustomerNotes(string ID, DataGridView DGV, string CustomerName, string NoteDetails, string CreatedBy, string CreatedDate)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_NOTE_BY_CUSTOMER_ID", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    //string ConfigValue = sqlDataReader["ConfigValue"].ToString();
                    //int ConvertedValue = Convert.ToInt32(ConfigValue);

                    ID = sqlDataReader[0].ToString();
                    CustomerName = sqlDataReader[1].ToString();
                    NoteDetails = sqlDataReader[2].ToString();
                    CreatedBy = sqlDataReader[3].ToString();
                    CreatedDate = sqlDataReader[4].ToString();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }


        }

        public bool CheckIfCustomerExists(string CustomerNumber)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_EXISTS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ContactNumber", CustomerNumber);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    return true;


                }
                else
                {
                    messageHandler.ReturnInfoBox("Customer with the Contact Number " + CustomerNumber + " already exists and registered. \n\nPlease search for the customer via customer search", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Hand);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }

        /// <summary>
        /// Method to check if the customer exists within the search function
        /// </summary>
        /// <param name="CustomerNumber"></param>
        /// <returns>True/False</returns>
        public bool CustomerSearchIfExists(string CustomerNumber)
        {

            using (SqlConnection connection = new SqlConnection(SQLConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT_CUSTOMER_EXISTS_SP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ContactNumber", CustomerNumber);
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
                catch (Exception)
                {

                    return false;
                }

            }

        }

        /// <summary>
        /// Method used when loading up the customer overview
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Firstname"></param>
        /// <param name="Surname"></param>
        /// <param name="DOB"></param>
        /// <param name="ContactNumber"></param>
        /// <param name="AltContact"></param>
        /// <param name="EmailAddr"></param>
        /// <param name="Vuln"></param>
        /// <param name="AddrLine1"></param>
        /// <param name="AddrLine2"></param>
        /// <param name="Town"></param>
        /// <param name="PostalCode"></param>
        /// <param name="Counrty"></param>
        /// <param name="Status"></param>
        /// <remarks>This is a readonly Method and is used to return ALL customer datat</remarks>
        /// <exception cref="SqlException"></exception>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="UnhandledExceptionEventArgs"></exception>
        public void GetCustomerOverview(MetroTextBox Title, MetroTextBox Firstname, MetroTextBox Surname, MetroTextBox DOB, MetroTextBox ContactNumber,
                                        MetroTextBox AltContact, MetroTextBox EmailAddr, MetroCheckBox Vuln, MetroTextBox AddrLine1, MetroTextBox AddrLine2, MetroTextBox Town,
                                        MetroTextBox PostalCode, MetroTextBox Counrty, ToolStripLabel Status)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_OVERVIEW_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Title.Text = sqlDataReader[0].ToString();
                    Firstname.Text = sqlDataReader[1].ToString();
                    Surname.Text = sqlDataReader[2].ToString();
                    DOB.Text = sqlDataReader[3].ToString();
                    ContactNumber.Text = sqlDataReader[4].ToString();
                    AltContact.Text = sqlDataReader[5].ToString();
                    EmailAddr.Text = sqlDataReader[6].ToString();
                    if (sqlDataReader[7].ToString() == "1")
                    {
                        Vuln.CheckState = CheckState.Checked;
                    }
                    else { Vuln.CheckState = CheckState.Unchecked; };
                    AddrLine1.Text = sqlDataReader[8].ToString();
                    AddrLine2.Text = sqlDataReader[9].ToString();
                    Town.Text = sqlDataReader[10].ToString();
                    PostalCode.Text = sqlDataReader[11].ToString();
                    Counrty.Text = sqlDataReader[12].ToString();
                    switch (sqlDataReader[13].ToString())
                    {
                        case "Active":
                            Status.Text = "Active";
                            Status.ForeColor = System.Drawing.Color.Green;
                            break;
                        case "On Hold":
                            Status.Text = "On Hold";
                            Status.ForeColor = System.Drawing.Color.Orange;
                            break;
                        case "Cancelled":
                            Status.Text = "Cancelled";
                            Status.ForeColor = System.Drawing.Color.DarkRed;
                            break;
                        case "Rejected":
                            Status.Text = "Rejected";
                            Status.ForeColor = System.Drawing.Color.DarkRed;
                            break;
                        case "Pending":
                            Status.Text = "Pending";
                            Status.ForeColor = System.Drawing.Color.Orange;
                            break;
                        case "Deactivated":
                            Status.Text = "Deactivated";
                            Status.ForeColor = System.Drawing.Color.Red;
                            break;
                        case "Suspended":
                            Status.Text = "Suspended";
                            Status.ForeColor = System.Drawing.Color.Red;
                            break;
                        default:
                            Status.Text = "UNKNOWN STATUS";
                            Status.ForeColor = System.Drawing.Color.Black;
                            break;
                    }


                    // Status.Text = sqlDataReader[13].ToString();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                scon.Close();
            }


        }

        /// <summary>
        /// Method used to insert a new Customer Note
        /// </summary>
        /// <param name="NoteDescription"></param>
        /// <param name="NoteDetails"></param>
        /// <param name="ShowNoteConfirmation"></param>
        /// <param name="form">Optional</param>
        /// <param name="NoteCategory"></param>
        /// <exception cref="SqlException">Handled SQL Exception</exception>
        public void InsertNewCustomerNote(string NoteDescription, string NoteDetails, bool ShowNoteConfirmation, [Optional] Form form, [Optional] string NoteCategory)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_CUSTOMER_NOTE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@NoteDescription", NoteDescription);
                sqlCommand.Parameters.AddWithValue("@NoteDetails", NoteDetails);
                if (NoteCategory == null)
                {
                    sqlCommand.Parameters.AddWithValue("@NoteCategory", "Status Change");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@NoteCategory", NoteCategory);
                }



                sqlCommand.Parameters.AddWithValue("@CreatedBy", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                if (ShowNoteConfirmation == true)
                {
                    messageHandler.ReturnInfoBox("Note has been created", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Information);

                }
                else { };



            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert note \n\n" + ex.Message, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                scon.Close();
            }
        }

        /// <summary>
        /// Method used to return Current Customer Status
        /// </summary>
        /// <param name="status"></param>
        public void GetCustomerStatus(MetroTextBox status)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_STATUS_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {


                    status.Text = sqlDataReader[0].ToString();


                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                scon.Close();
            }

        }
        /// <summary>
        /// Method used to update the customer Account status
        /// </summary>
        /// <param name="NewStatus"></param>
        /// <param name="NoteText"></param>
        public void SetCustomerStatus(MetroComboBox NewStatus, string NoteText)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_STATUS_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@StatusName", NewStatus.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", InfoSec.GlobalUsername);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                messageHandler.ReturnInfoBox("Customer Status has been set to " + NewStatus.SelectedItem, InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Information);
                InsertNewCustomerNote("Customer Status Changed", "Customer Status set to " + NewStatus.SelectedItem + "\n\n " + NoteText, false);
            }
            catch (Exception ex)
            {
                messageHandler.ReturnInfoBox("Failed update customer status \n\n" + ex.Message, InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Error);


            }
            finally
            {
                scon.Close();
            }

        }


        /// <summary>
        /// Method to return Customer Data for the Update Customer form
        /// </summary>
        /// <param name="Title">Customers Title</param>
        /// <param name="Firstname"></param>
        /// <param name="Surname"></param>
        /// <param name="DOB"></param>
        /// <param name="ContactNumber"></param>
        /// <param name="AlterContact"></param>
        /// <param name="EmailAddress"></param>
        /// <exception cref="SqlException">When SQL Exception Occurs</exception>

        public void GetCustomerForUpdates(MetroComboBox Title, MetroTextBox Firstname, MetroTextBox Surname, MetroDateTime DOB, MetroTextBox ContactNumber, MetroTextBox AlterContact, MetroTextBox EmailAddress)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_FOR_UPDATES", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Title.SelectedItem = sqlDataReader[0].ToString();
                    Firstname.Text = sqlDataReader[1].ToString();
                    Surname.Text = sqlDataReader[2].ToString();
                    DateTime DT = DateTime.Parse(sqlDataReader[3].ToString());
                    DOB.Format = DateTimePickerFormat.Short;
                    DOB.Value = DT;
                    //DOB.Value = DT.ToString("dd/MM/yyy") ;
                    //DOB.Text = sqlDataReader[3].ToString();
                    ContactNumber.Text = sqlDataReader[4].ToString();
                    AlterContact.Text = sqlDataReader[5].ToString();
                    EmailAddress.Text = sqlDataReader[6].ToString();

                }
            }
            catch (Exception ex)
            {

                messageHandler.ReturnInfoBox("Failed update customer details \n\n" + ex.Message, InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Error);

            }
            finally
            {

                scon.Close();

            }

        }

        /// <summary>
        /// Method used to Update Customer Details - Upon success will close the form
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="FirstName"></param>
        /// <param name="Surname"></param>
        /// <param name="DOB"></param>
        /// <param name="ContactNumber"></param>
        /// <param name="AltContactNumber"></param>
        /// <param name="EmailAddress"></param>
        /// <param name="form"></param>
        /// <exception cref="SqlException">Handled SQL Exception</exception>
        /// <exception cref="NullReferenceException">Nul Exception</exception>
        public void UpdateCustomerDetails(MetroComboBox Title, MetroTextBox FirstName, MetroTextBox Surname, MetroDateTime DOB, MetroTextBox ContactNumber, MetroTextBox AltContactNumber, MetroTextBox EmailAddress, Form form)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_CUSTOMER_DETAILS_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                sqlCommand.Parameters.AddWithValue("@Title", Title.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@Firstname", FirstName.Text);
                sqlCommand.Parameters.AddWithValue("@Surname", Surname.Text);
                sqlCommand.Parameters.AddWithValue("@DOB", DOB.Value);
                sqlCommand.Parameters.AddWithValue("@ContactNumber", ContactNumber.Text);
                sqlCommand.Parameters.AddWithValue("@AltContact", AltContactNumber.Text);
                sqlCommand.Parameters.AddWithValue("@EmailAddress", EmailAddress.Text);
                sqlCommand.Parameters.AddWithValue("@CreatedBy", InfoSec.GlobalUsername);
                sqlCommand.Parameters.AddWithValue("@UpdatedBy", InfoSec.GlobalUsername);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                messageHandler.ReturnInfoBox("Customer Details have been updated", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Success);
                form.Close();
            }
            catch (Exception ex)
            {
                messageHandler.ReturnInfoBox("Failed update customer status \n\n" + ex.Message, InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Error);


            }
            finally
            {
                scon.Close();
            }

        }
        public void GetCustomerHistory(MetroGrid DataGridView) 
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("SELECT_CUSTOMER_HISTORY_SP", scon)) {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd)) {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DataGridView.DataSource = customers;
                    }
                    DataGridView.ReadOnly = true;
                    DataGridView.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DataGridView.Columns) {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    //DGV.AllowUserToOrderColumns = false;
                    //GB.Show();

                }
            }
            catch (Exception) {

                throw;
            }


        }
        #endregion
    }
}
