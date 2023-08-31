using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using Krypton.Toolkit;
using System.Windows.Forms;
using Gaze.BusinessLogic.SQLManagement;
using System.Drawing;

namespace Gaze.BusinessLogic.Security
{
    public class DataProtection
    {

        private string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];

        public SqlDataReader ExecuteReader(string SPNAME, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();
                return SqlHelper.ExecuteReader(sqlConnection, SPNAME, commandParameters);

            }
            catch (SqlException sqlException)
            {

                    KryptonMessageBox.Show(sqlException.Message, "Failure!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
            return reader;
            }
            finally
            {
                sqlConnection.Close();
            }
            
        }

        public void GetCustomersPassword(KryptonTextBox PasswordField)
        {
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_CUSTOMERS_DPA_PASSWORD_SP", sqlConnection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@CustomerID", InfoSec.GlobalCustomerID);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    PasswordField.Text = sqlDataReader[0].ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }

    }
    }

