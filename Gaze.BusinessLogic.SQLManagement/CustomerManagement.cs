using Gaze.BusinessLogic.Exceptions;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private DateTime date = new DateTime();
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
                KryptonMessageBox.Show("Data Validation Failure! \n\nYou have not completed all required fields. Please check and try again!", "Failure!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                

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
        /// <param name="DGV">Data grid view to return the data into</param>
        public void GetCustomerDataByContactNumber(string ContactNumber, DataGridView DGV, [Optional] GroupBox GB)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_TITLE_BY_CONTACT_NUMBER_SP", scon))
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
                    DGV.AllowUserToOrderColumns = false;
                    DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
            catch (Exception)
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
                    KryptonMessageBox.Show("Customer with the Contact Number " + CustomerNumber + " already exists and registered. \n\nPlease search for the customer via customer search","Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                    
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
        /// <remarks>This is a readonly Method and is used to return ALL customer data</remarks>
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
                    KryptonMessageBox.Show("Note has been created", "Note Saved!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                    

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
            catch (Exception)
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
                
                KryptonMessageBox.Show("Customer Status has been set to " + NewStatus.SelectedItem, "Failure!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                InsertNewCustomerNote("Customer Status Changed", "Customer Status set to " + NewStatus.SelectedItem + "\n\n " + NoteText, false);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Failed update customer status \n\n" + ex.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);


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

                KryptonMessageBox.Show("Failed update customer details \n\n" + ex.Message, "Whoops!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);

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
                KryptonMessageBox.Show("Customer Details have been updated", "Note Saved!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);
                form.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Failed update Customer Details \n\n" + ex.Message, "Whoops", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);


            }
            finally
            {
                scon.Close();
            }

        }
        public void GetCustomerHistory(MetroGrid DataGridView)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("SELECT_CUSTOMER_HISTORY_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DataGridView.DataSource = customers;
                    }
                    DataGridView.ReadOnly = true;
                    DataGridView.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DataGridView.Columns)
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

        public void GetCustomerOverViewV1(System.Windows.Forms.TextBox CustomerFullName, KryptonTextBox Title, KryptonTextBox Firstname, KryptonTextBox Surname, KryptonMaskedTextBox DOB, KryptonTextBox ContactNumber, KryptonTextBox Altercontact,
                                         KryptonTextBox EmailAddress, KryptonTextBox AddressLine1, KryptonTextBox AddressLine2, KryptonTextBox Town, KryptonTextBox Postalcode, KryptonTextBox Country, System.Windows.Forms.TextBox PolicyID,
                                         Label PolicyStatus, KryptonTextBox Deactivation, KryptonMaskedTextBox PEffStart, KryptonMaskedTextBox PEffEnd,KryptonTextBox Discount, KryptonTextBox ProductName, KryptonTextBox ProductDesc,
                                         KryptonMaskedTextBox EffStart, System.Windows.Forms.TextBox CustomerID, KryptonMaskedTextBox ProductEffEnd, [Optional] KryptonTextBox PolicyID1, [Optional] KryptonTextBox StatusID1)
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
                    

                    date = sqlDataReader.GetDateTime(20);
                    EffStart.Text = date.ToShortDateString();

                    CustomerID.Text = sqlDataReader[21].ToString();



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

        public void GetCustomerPoliciesForOverview(MetroGrid DataGridView)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("pol.SELECT_CUSTOMER_POLICIES_FOR_OVERVIEW", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(scmd))
                    {
                        DataTable customers = new DataTable();
                        adapter.Fill(customers);
                        DataGridView.DataSource = customers;
                    }
                    DataGridView.ReadOnly = true;
                    DataGridView.AllowUserToAddRows = false;
                    foreach (DataGridViewColumn column in DataGridView.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    DataGridView.AllowUserToOrderColumns = false;
                    DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void GetCustomerPoliciesByPolicyID(string PolicyID, DataGridView DGV)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                using (SqlCommand scmd = new SqlCommand("dbo.SELECT_CUSTOMER_POLICIES_VIA_POLICYID_SP", scon))
                {
                    scmd.CommandType = CommandType.StoredProcedure;
                    scmd.Parameters.AddWithValue("@PolicyID", PolicyID);
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
                    DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                }
            }
            catch (Exception)
            {
                ///ERROR HANDLING REQUIRED HERE
                throw;
            }
        }

        public void GetCustomerOverviewNote(KryptonTextBox NoteOverviwe)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMER_NOTE_OVERVIEW_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    NoteOverviwe.Text = sqlDataReader[0].ToString();

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure to retrieve note", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;

            }
            finally
            {
                scon.Close();
            }

                }

        public void RemoveOverviewNote()
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.REMOVE_CUSTOMER_OVERVIEW_NOTE_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                KryptonMessageBox.Show("Customer Overview Note removed successfully" ,"Success!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, 0, 0, false, false, false, false, null);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Failure!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
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
