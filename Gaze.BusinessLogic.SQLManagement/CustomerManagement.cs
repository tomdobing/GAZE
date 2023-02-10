using Gaze.BusinessLogic.Exceptions;
using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class CustomerManagement
    {

        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
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
        public void CreateNewCustomer(MetroComboBox Title, MetroTextBox Firstname, MetroTextBox surname, MetroDateTime DOB, MetroTextBox Contact, MetroTextBox Email, MetroTextBox Address, [Optional] MetroCheckBox Vuln)
        {
            if (Title.SelectedIndex.ToString() == "" | Firstname.Text == "" | surname.Text == "" | DOB.Value.ToShortDateString() == "" | Contact.Text == "" | Email.Text == "" | Address.Text == "")
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
                    GB.Show();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetCustomerNotesForDataGrid(DataGridView DGV)
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
        #endregion
    }
}
