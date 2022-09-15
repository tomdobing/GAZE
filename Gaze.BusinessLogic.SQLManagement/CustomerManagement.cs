using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using Gaze.BusinessLogic.Exceptions;
using System.Runtime.InteropServices;

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
            if (Title.SelectedIndex.ToString() == "" | Firstname.Text == "" | surname.Text == "" | DOB.Value.ToShortDateString() == "" | Contact.Text == "" | Email.Text == "" | Address.Text == "" )
            {
                exceptionThrown.ThrowNewException("Data Validation Failed", "You have not completed all required fields. Please check and try again!", "Data Failure");
            }
            else
            {
                exceptionThrown.ThrowNewException("This is a message", "this is a stack trace", "Text");
            }
        }
        #endregion
    }
}
