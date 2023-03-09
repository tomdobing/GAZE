using MetroFramework.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;


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

        public void GetPolicyDataViaPolicyID(System.Windows.Forms.TextBox CustomerFullName, MetroTextBox Title, MetroTextBox Firstname, MetroTextBox Surname, MetroTextBox DOB, MetroTextBox ContactNumber, MetroTextBox Altercontact,
                                         MetroTextBox EmailAddress, MetroTextBox AddressLine1, MetroTextBox AddressLine2, MetroTextBox Town, MetroTextBox Postalcode, MetroTextBox Country, System.Windows.Forms.TextBox PolicyID,
                                         Label PolicyStatus,MetroTextBox Deactivation, MetroTextBox PEffStart, MetroTextBox PEffEnd,MetroTextBox ProductName, MetroTextBox ProductDesc, MetroTextBox ProductPrice, 
                                         MetroTextBox EffStart, System.Windows.Forms.TextBox CustomerID, MetroTextBox ProductEffEnd, [Optional] MetroTextBox PolicyID1,[Optional] MetroTextBox StatusID1)
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
                sqlCommand.Parameters.AddWithValue("@CustomerID", 5);
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
                    ProductPrice.Text = "£" + sqlDataReader[20].ToString();

                    date = sqlDataReader.GetDateTime(21);
                    EffStart.Text = date.ToShortDateString();
                    
                    CustomerID.Text = sqlDataReader[22].ToString();

                    date = sqlDataReader.GetDateTime(23);
                    ProductEffEnd.Text = date.ToShortDateString();
                    
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



        #endregion

    }
}
