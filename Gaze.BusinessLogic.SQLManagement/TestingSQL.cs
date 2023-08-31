using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class TestingSQL
    {
      public string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        public object executedata()
        {
           
            object result = SqlHelper.ExecuteReader(SQLConnectionString, "dbo.TEST_SP");

            return result;
        }

        public SqlDataReader asd()
        {

        return SqlHelper.ExecuteReader(SQLConnectionString, "dbo.TEST_SP");

        }

        public SqlDataReader ExecuteReader(CommandType commandType, string SPNAME, params SqlParameter[] commandParameters)
        {
            SqlConnection sqlConnection = new SqlConnection(SQLConnectionString);
            
            try
            {
                sqlConnection.Open();
                return SqlHelper.ExecuteReader(sqlConnection,SPNAME, commandParameters);

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
