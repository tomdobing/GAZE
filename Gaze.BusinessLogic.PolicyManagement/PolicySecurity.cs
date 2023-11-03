using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gaze.BusinessLogic.PolicyManagement
{
    /// <summary>
    /// Policy Security Class used for any policy related security requests
    /// </summary>
    public class PolicySecurity
    {
        #region Declarations
        private readonly string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        #endregion

        #region Methods


        public void InsertPolicyReDirect(KryptonCheckBox YesBox, KryptonCheckBox NoBox, string PolicyID,
                                        KryptonComboBox Department, string Message, KryptonForm ReDirectForm)
        {
            if (YesBox.CheckState == CheckState.Checked)
            {
                if (ReDirectExists() == true)
                {
                    KryptonMessageBox.Show("A ReDirect already exists for this customer. You cannot set another!", "Policy ReDirect", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                SqlConnection scon = new SqlConnection(SQLConnectionString);
                try
                {
                    scon.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.INSERT_NEW_POLICY_REDIRECT_SP", scon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                    sqlCommand.Parameters.AddWithValue("@Department", Department.SelectedItem);
                    sqlCommand.Parameters.AddWithValue("@Message", Message);
                    sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                    sqlCommand.ExecuteReader();
                    KryptonMessageBox.Show("Policy ReDirect created", "Policy ReDirect", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
                    ReDirectForm.Close();
                }
                catch (SqlException SQLException)
                {
                    KryptonMessageBox.Show("An Error Occurred while setting the new Policy ReDirect.\n\nSQL Exception: " + SQLException.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show("An Error Occurred while setting the new Policy ReDirect.\n\nException: " + ex.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    scon.Close();
                }
            }
            if (NoBox.CheckState == CheckState.Checked)
            {
                if (ReDirectExists() == false)
                {
                    ReDirectForm.Close();
                }
                RemovePolicyReDirect(ReDirectForm);
            }

        }

        public bool ReDirectExists()
        {
            using (SqlConnection connection = new SqlConnection(SQLConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("dbo.SELECT_REDIRECT_EXISTS_SP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
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
                catch (SqlException SQLException)
                {
                    KryptonMessageBox.Show("An Error Occurred while checking for a Policy ReDirect.\n\nSQL Exception: " + SQLException.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show("An Error Occurred while checking for a Policy ReDirect.\n\nException: " + ex.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    connection.Close();
                }

            }


        }

        private void RemovePolicyReDirect(KryptonForm policyReDirectfrm)
        {
            string message = "You are about to remove this Policy ReDirect. Are you sure you wish to continue?";
            string caption = "Policy ReDirect Removal";
            DialogResult result;

            result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {
                SqlConnection scon = new SqlConnection(SQLConnectionString);
                try
                {
                    scon.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.UPDATE_REMOVE_POLICY_REDIRECT_SP", scon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                    sqlCommand.Parameters.AddWithValue("@Agent", InfoSec.GlobalUsername);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    KryptonMessageBox.Show("Policy ReDirect removed Successfully.", "Policy ReDirect!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
                    policyReDirectfrm.Close();
                }
                catch (SqlException SQLException)
                {
                    KryptonMessageBox.Show("An Error Occurred while removing the Policy ReDirect.\n\nSQL Exception: " + SQLException.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show("An Error Occurred while removing the Policy ReDirect.\n\nException: " + ex.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    scon.Close();
                }
            }
        }


        public void GetPolicyReDirectDetails(KryptonComboBox Department, KryptonTextBox MessageDetails,
                                            KryptonCheckBox YesBox, KryptonCheckBox NoBox, KryptonForm ReDirectForm)
        {
            if (ReDirectExists() == true)
            {
                SqlConnection scon = new SqlConnection(SQLConnectionString);
                try
                {
                    scon.Open();
                    SqlCommand sqlCommand = new SqlCommand("dbo.SELECT_POLICY_REDIRECT_DETAILS_SP", scon)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Department.SelectedItem = sqlDataReader[0].ToString();
                        MessageDetails.Text = sqlDataReader[1].ToString();
                        if (sqlDataReader[2].ToString() == "1")
                        {
                            YesBox.CheckState = CheckState.Checked;
                        }
                    }
                }
                catch (SqlException SQLException)
                {
                    KryptonMessageBox.Show("An Error Occurred while retrieving policy ReDirect Data.\n\nSQL Exception: " + SQLException.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show("An Error Occurred while retrieving policy ReDirect Data.\n\nException: " + ex.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                    return;
                }
                finally 
                {
                    scon.Close(); 
                }

            }


        }
        public string MessageDetails;
        public string GetPolicyReDirectMessage()
        {
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[SELECT_POLICY_REDIRECT_MESSAGE_SP]", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    MessageDetails = sqlDataReader[0].ToString();
                }
                return MessageDetails;
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("An Error Occurred while retrieving policy ReDirect ExtraText.\n\nSQL Exception: " + SQLException.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("An Error Occurred while retrieving policy ReDirect ExtraText.\n\nException: " + ex.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return null;
            }
            finally
            {
                scon.Close();
            }
        }

        public string dept;
        public string GetPolicyRedirectDepartment()
        {
            
            SqlConnection scon = new SqlConnection(SQLConnectionString);
            try
            {
                
                scon.Open();
                SqlCommand sqlCommand = new SqlCommand("[dbo].[SELECT_POLICY_REDIRECT_DEPARTMENT_SP]", scon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@PolicyID", InfoSec.GlobalSelectedPolicyID);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    dept = sqlDataReader[0].ToString();
                   
                }
                return dept;
            }
            catch (SqlException SQLException)
            {
                KryptonMessageBox.Show("An Error Occurred while retrieving policy ReDirect Department.\n\nSQL Exception: " + SQLException.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("An Error Occurred while retrieving policy ReDirect Department.\n\nException: " + ex.Message, "Policy ReDirect Exception", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                return null;
            }
            finally
            {
                scon.Close();
            }


        }
        #endregion

    }
}
