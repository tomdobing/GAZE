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
        /// Used to populate the Title ComboBox on the New Customer form
        /// </summary>
        /// <param name="Combobox">The control holding the title data</param>
        public void PopulateTitle(MetroComboBox Combobox)
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
        public void PopulateCountried(MetroComboBox Combobox)
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
                exceptionThrown.ThrowNewException("Data Validation Failed", "You have not completed all required fields. Please check and try again!", "Data Failure");
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
                    string message = "Customer with the Contact Number " + CustomerNumber + " already exists and registered. \n\nPlease search for the customer via customer search";
                    string caption = "Whoops";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


        }

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
                                //string message = "Customer with the Contact Number " + CustomerNumber + " is not a registered customer. \n\nPlease ask the customer if they wish to register";
                                //string caption = "Whoops";
                                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                                //MessageBox.Show(message, caption, buttons,
                                //MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
        public void InsertNewCustomerNote(string NoteDescription, string NoteDetails,bool ShowNoteConfirmation, [Optional] Form form)
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
                sqlCommand.Parameters.AddWithValue("@CreatedBy", InfoSec.GlobalUsername);
                sqlCommand.ExecuteReader();
                if (ShowNoteConfirmation == true)
                {
                    MessageBox.Show("Note Created!", "Note Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //string ConfigValue = sqlDataReader["ConfigValue"].ToString();
                    //int ConvertedValue = Convert.ToInt32(ConfigValue);

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
                //MessageBox.Show("Customer Status has been set to " + NewStatus.SelectedItem, "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InsertNewCustomerNote("Customer Status Changed", "Customer Status set to " + NewStatus.SelectedItem + "\n\n " + NoteText, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed update customer status \n\n" + ex.Message, "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                scon.Close();
            }

        }
        #endregion
    }
}
