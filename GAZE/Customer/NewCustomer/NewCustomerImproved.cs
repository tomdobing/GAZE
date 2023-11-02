using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Validations = Gaze.BusinessLogic.Config.Validations;

namespace GAZE.Customer.NewCustomer
{
    public partial class NewCustomerImproved : KryptonForm
    {
        #region Declarations
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly ConfigAdmin ConfigAdmin = new ConfigAdmin();
        readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        readonly MessageHandler messageHandler = new MessageHandler();
        readonly ControlManagement controlManagement = new ControlManagement();
        readonly Validations validations = new Validations();
        readonly Gaze.BusinessLogic.BillingManagement.Validations BankingValidations = new Gaze.BusinessLogic.BillingManagement.Validations();
        #endregion

        public NewCustomerImproved()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer Improved");
            controlManagement.PopulateTitle(ctTitle_cmbIm);
            controlManagement.PopulateCountries(country_cmbIM);
            dobDtpIM.Format = DateTimePickerFormat.Custom;
            dobDtpIM.CustomFormat = ConfigAdmin.GetConfigValue("DateFormat");
            cntNumber_txtIm.MaxLength = 14;
        }

        private void NewCustomerImproved_Load(object sender, EventArgs e)
        {
            sortCode_txt.MaxLength = 6;
            bankNumber_txt.MaxLength = 8;
            cntNumberAlt_txtIM.MaxLength = 14;
            cntNumber_txtIm.MaxLength = 14;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

            ResetForms();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you wish cancel the creation of this customer?" +
                             "\n\n None of your progress will be saved!";
            string caption = "Are you sure?";
            DialogResult result;

            result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (validations.IsValidPhone(cntNumber_txtIm.Text) == false)
            {
                KryptonMessageBox.Show("You must enter a valid Contact Number", "Validation Error!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                return;
            }
            if(validations.IsValidEmail(emailAddr_txt.Text) == false)
            {
                KryptonMessageBox.Show("You must enter a valid Email Address", "Validation Error!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                return;
            }
            if (BankingValidations.ValidateBankAccountNumber(bankNumber_txt) == false)
            {
                KryptonMessageBox.Show("The Bank Account Number You Have Entered Is Not Valid", "Validation Error!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                return;
            }
            if (BankingValidations.ValidateSortCodeNumber(sortCode_txt) == false)
            {
                KryptonMessageBox.Show("The Sort Code You Have Entered Is Not Valid", "Validation Error!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                return;
            }
            CustomerManagement.CreateNewCustomer(ctTitle_cmbIm, ctFirstName_txtIM, ctSurName_txtIM, 
                dobDtpIM, cntNumber_txtIm, cntNumberAlt_txtIM, emailAddr_txt, addrLine1_txt, addrLine2_txt,
                town_txt, postalCode_txt, country_cmbIM, bankNumber_txt, sortCode_txt);
            ResetForms();
        }

        private void ResetForms()
        {
            foreach (KryptonTextBox item in this.Controls.OfType<KryptonTextBox>())
            {
                item.Clear();
            }
            ctTitle_cmbIm.SelectedIndex = 0;
            dobDtpIM.Value = DateTime.Now;
            country_cmbIM.SelectedIndex = 0;
        }

        private void sortCode_txt_Leave(object sender, EventArgs e)
        {
            string text = sortCode_txt.Text.Replace("-", ""); // remove existing dashes

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
                sortCode_txt.Text = formatted.ToString();
                sortCode_txt.SelectionStart = formatted.Length;
            }
        }

        private void sortCode_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void bankNumber_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
