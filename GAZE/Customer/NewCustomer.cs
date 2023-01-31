using System;
using System.Windows.Forms;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.BusinessLogic.Security;

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

        #endregion
        public NewCustomer()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer");
            CustomerManagement.PopulateTitle(CmbTitle);
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
            Address_Txt.Clear();
            CmbTitle.SelectedIndex = 0;
            DOB_DTP.Value = DateTime.Now;
            CustAge_txt.Clear();
        }

        private void Submit_btn_click(object sender, EventArgs e)
        {
            
            if (validation.IsValidEmail(Email_TXT.Text))
            {
                CustomerManagement.CreateNewCustomer(CmbTitle, FirstName_Txt, surname_txt, DOB_DTP, ContactNmr_txt, Email_TXT, Address_Txt, metroCheckBox1);
            }
            else
            {
                exceptionThrown.ThrowNewException("Email Address Validation Failure", "The email address you have entered is not valid. Please ensure it meets the email address criteria", "Validation Failure");
            }
            
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
    }
}
