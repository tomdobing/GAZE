using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.Exceptions;

namespace Gaze.BusinessLogic.SQLManagement
{
    public class ConfigAdmin
    {

        #region Declaration
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        private ExceptionThrown exception = new ExceptionThrown();
        #endregion

        #region Methods
        /// <summary>
        /// Selects users in the configured SQL Server Database and returns username only into ListBox
        /// </summary>
        /// <param name="listBox">Listbox to post results to</param>
        public void SelectAllConfigs(ListBox listBox)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_ALL_ADMIN_CONFIG_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    listBox.Items.Add(sqlDataReader[1].ToString());
                }
            }
            catch (Exception ex)
            {
                exception.ThrowNewStackException(ex, "SQL Exception");
                ///BUG 45 - TBI
                throw;
            }
            finally
            {
                scon.Close();
            }

        }
        /// <summary>
        /// Used to return the highlighted config 
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="ID"></param>
        /// <param name="ConfigName"></param>
        /// <param name="ConfigValue"></param>
        /// <param name="IsChangeable"></param>
        /// <param name="AddedBy"></param>
        public void SelectedConfig(ListBox listBox, MetroTextBox ID, MetroTextBox ConfigName, MetroTextBox ConfigValue, MetroCheckBox IsChangeable, MetroTextBox AddedBy)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_SINGLE_CONFIG_SP", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ConfigName", listBox.SelectedItem.ToString());
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ID.Text = sqlDataReader[0].ToString();
                    ConfigName.Text = sqlDataReader[1].ToString();
                    ConfigValue.Text = sqlDataReader[2].ToString();
                    AddedBy.Text = sqlDataReader[4].ToString();
                    if (sqlDataReader[3].ToString().Length == 1)
                    {
                        IsChangeable.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        IsChangeable.CheckState = CheckState.Unchecked;
                    }


                }
            }
            catch (Exception ex)
            {
                exception.ThrowNewStackException(ex, "SQL Exception");
            }
            finally
            {
                scon.Close();
            }
           
        }
        /// <summary>
        /// Used to get the config value
        /// </summary>
        /// <param name="ConfigtoGet"></param>
        /// <returns></returns>
        public string GetConfigValue(string ConfigtoGet)
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_SINGLE_CONFIG_VALUE_SP", scon)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ConfigName", ConfigtoGet);
                string ConfigValue = sqlCommand.ExecuteScalar().ToString();
                return ConfigValue;
            }
            catch (Exception ex)
            {
                exception.ThrowNewStackException(ex, "SQL Exception");
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
