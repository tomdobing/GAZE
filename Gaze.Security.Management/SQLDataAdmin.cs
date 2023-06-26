using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.Security.Management
{
    public class SQLDataAdmin
    {
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        readonly InfoSec infoSec = new InfoSec();
        public List<string> DisabledControls = new List<string>();

        public bool HasControlAccess(string controlName, string roleName)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                using (SqlCommand SQLCommand = new SqlCommand("sec.SELECT_IF_CONTROL_IS_AVAILABLE", scon))
                {
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@ControlName", controlName);
                    SQLCommand.Parameters.AddWithValue("@RoleName", roleName);
                    int count = (int)SQLCommand.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<string> GetAllDisabledControls()
        {

            SqlConnection scon = new SqlConnection(SQLConnectionString);

            try
            {
                scon.Open();
                using (SqlCommand SQLCommand = new SqlCommand("sec.SELECT_ALL_DISABLED_CONTROLS_SP", scon))
                {
                    SQLCommand.CommandType = CommandType.StoredProcedure;
                    SQLCommand.Parameters.AddWithValue("@Username", InfoSec.GlobalUsername);

                    using (SqlDataReader reader = SQLCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string controlValue = reader.GetString(0);
                            DisabledControls.Add(controlValue);
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return DisabledControls;
        }

       

    }

}

