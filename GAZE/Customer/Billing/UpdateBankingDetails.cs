using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Security;
using GAZE.Properties;
using Krypton.Toolkit;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Messaging;

namespace GAZE.Customer.Billing
{

    public partial class UpdateBankingDetails : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        Banking Banking = new Banking();
        Gaze.BusinessLogic.BillingManagement.Validations Validations = new Gaze.BusinessLogic.BillingManagement.Validations();
        
        #endregion

        public UpdateBankingDetails()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Update Banking Details - CustomerID:" + InfoSec.GlobalCustomerID);
            SQLBilling.GetCurrentBillingDetails(CurrAccountNumber_txt, CurrSortCode_txt);
        }

        private void UpdateBankingDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void NewSortcode_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewSortcode_txt_Leave(object sender, EventArgs e)
        {
            string text = NewSortcode_txt.Text.Replace("-", ""); // remove existing dashes

            if (text.Length > 0)
            {
                StringBuilder formatted = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    formatted.Append(text[i]);
                    if ((i + 1) % 2 == 0 && i < text.Length - 1)
                    {
                        formatted.Append("-");
                    }
                }
                NewSortcode_txt.Text = formatted.ToString();
                NewSortcode_txt.SelectionStart = formatted.Length;
            }

        }

        private void NewAccountNumber_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void NewSortcode_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            Banking.accnum = NewAccountNumber_txt.Text;
            Banking.sortcode = NewSortcode_txt.Text;
            Billing.BillingAgreement billingAgreement = new BillingAgreement();
            if (Validations.ValidateBankAccountNumber(NewAccountNumber_txt) == false) 
            {
                KryptonMessageBox.Show("Invalid Bank Account Number", "Invalid-Data!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            if (Validations.ValidateSortCodeNumber(NewSortcode_txt) == false)
            {
                KryptonMessageBox.Show("Invalid Sort Code Entered", "Invalid-Data!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return; 
            }
            billingAgreement.ShowDialog();
        }
    }
}
