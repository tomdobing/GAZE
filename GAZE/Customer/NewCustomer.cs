using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GAZE.Customer
{
    public partial class NewCustomer : Form
    {

        #region Declarations
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly ConfigAdmin ConfigAdmin = new ConfigAdmin();
        readonly ExceptionThrown exceptionThrown = new ExceptionThrown();
        readonly Validations validation = new Validations();
        // readonly Print print = new Print();
        readonly MessageHandler messageHandler = new MessageHandler();
        readonly ControlManagement controlManagement = new ControlManagement();

        #endregion
        public NewCustomer()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer");
            controlManagement.PopulateTitle(CmbTitle);
            controlManagement.PopulateCountried(Country_cmb);
            DOB_DTP.Format = DateTimePickerFormat.Custom;
            DOB_DTP.CustomFormat = ConfigAdmin.GetConfigValue("DateFormat");
            ContactNmr_txt.MaxLength = 14;

        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }

        private void Close_BTN_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {
            FirstName_Txt.Clear();
            surname_txt.Clear();
            ContactNmr_txt.Clear();
            Email_TXT.Clear();
            AddrL1_txt.Clear();
            AddrL2_txt.Clear();
            PostCode_txt.Clear();
            Country_cmb.SelectedIndex = 0;
            town_txt.Clear();
            CmbTitle.SelectedIndex = 0;
            DOB_DTP.Value = DateTime.Now;
            CustAge_txt.Clear();
            metroCheckBox1.CheckState = CheckState.Unchecked;
        }

        private void Submit_btn_click(object sender, EventArgs e)
        {
            if (!validation.IsValidEmail(Email_TXT.Text))
            {
                messageHandler.ShowMessage("The email address you have entered is not valid. Please ensure it meets the email address criteria", "Email Address Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!validation.IsValidPhone(ContactNmr_txt.Text))
            {
                messageHandler.ShowMessage("The contact number you have entered is not valid. Please ensure it meets the contact number criteria", "Contact Validation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (!validation.IsOverRequiredAge(DOB_DTP.Value))
            {
                //updated wording based on #60
                messageHandler.ShowMessage("The customers' age does not meet the requirements of the Terms and Conditions of this product and/or tariff", "Age Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (CustomerManagement.CheckIfCustomerExists(ContactNmr_txt.Text) == false)
            {
                return;
            }

            //CustomerManagement.CreateNewCustomer(CmbTitle, FirstName_Txt, surname_txt,
              //                                   DOB_DTP, ContactNmr_txt, Email_TXT, AddrL1_txt, 
              //                                   AddrL2_txt, town_txt, PostCode_txt, Country_cmb, 
              //                                   metroCheckBox1);


        }

        private void DOB_DTP_Leave(object sender, EventArgs e)
        {
            CustAge_txt.Text = DateTimeExtensions.ToAgeString(DOB_DTP.Value);
        }

        private void Email_TXT_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //print.PrintForm(this);
        }

        private void FirstName_Txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, FirstName_Txt, errorProvider1);
        }



        private void surname_txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, surname_txt, errorProvider1);
        }

        private void ContactNmr_txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, ContactNmr_txt, errorProvider1);
        }

        private void AltContact_txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //validation.control_Validating(sender, e, AltContact_txt, errorProvider1);
        }

        private void Email_TXT_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, Email_TXT, errorProvider1);
        }

        private void AddrL1_txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, AddrL1_txt, errorProvider1);
        }

        private void town_txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, town_txt, errorProvider1);
        }

        private void PostCode_txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            validation.control_Validating(sender, e, PostCode_txt, errorProvider1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
