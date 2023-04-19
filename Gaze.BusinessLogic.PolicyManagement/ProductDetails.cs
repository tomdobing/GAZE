using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.PolicyManagement
{
    public class ProductDetails
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        private readonly MessageHandler messageHandler = new MessageHandler();
        InfoSec InfoSec = new InfoSec();
        #endregion

        #region Methods

        public void GetProductDetailsFromCombo(KryptonComboBox ProductName, KryptonTextBox ProductID, KryptonTextBox ProductName1, KryptonTextBox ProdDescr,
                                                KryptonTextBox ProductStatus, KryptonTextBox ProductPrice, KryptonTextBox ProductEffStart,
                                                KryptonTextBox ProductEffEnd)
        {
            DateTime date = new DateTime();
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_PRODUCT_DETAILS_FOR_NEW_POLICIES_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ProductName", ProductName.SelectedItem);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ProductID.Text = sqlDataReader[0].ToString();
                    ProductName1.Text = sqlDataReader.GetString(1);
                    ProdDescr.Text = sqlDataReader.GetString(2);
                    ProductStatus.Text = sqlDataReader.GetString(3);
                    ProductPrice.Text = sqlDataReader.GetString(4);

                    date = sqlDataReader.GetDateTime(5);
                    ProductEffStart.Text = date.ToShortDateString();

                    date = sqlDataReader.GetDateTime(6);
                    ProductEffEnd.Text = date.ToShortDateString();
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

        #endregion


    }
}
