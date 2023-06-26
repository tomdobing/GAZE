using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
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
       
        #endregion



        public NewCustomerImproved()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer Improved");
            controlManagement.PopulateTitle(ctTitle_cmbIm);
            controlManagement.PopulateCountried(country_cmbIM);
            dobDtpIM.Format = DateTimePickerFormat.Custom;
            dobDtpIM.CustomFormat = ConfigAdmin.GetConfigValue("DateFormat");
            cntNumber_txtIm.MaxLength = 14;
        }

        private void NewCustomerImproved_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ctTitle_cmbIm.SelectedIndex = 0;
            ctFirstName_txtIM.Clear();
            ctSurName_txtIM.Clear();
            dobDtpIM.Value = DateTime.Now;
            cntNumber_txtIm.Clear();
            cntNumberAlt_txtIM.Clear();
            addrLine1_txt.Clear();
            addrLine2_txt.Clear();
            town_txt.Clear();
            postalCode_txt.Clear();
            country_cmbIM.SelectedIndex = 0;
            
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
            CustomerManagement.CreateNewCustomer(ctTitle_cmbIm, ctFirstName_txtIM, ctSurName_txtIM, dobDtpIM, cntNumber_txtIm, cntNumberAlt_txtIM, emailAddr_txt, addrLine1_txt, addrLine2_txt,
                town_txt, postalCode_txt, country_cmbIM, bankNumber_txt, sortCode_txt);
        }
    }
}
