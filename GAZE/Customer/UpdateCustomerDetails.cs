using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using Krypton.Toolkit;
using MetroFramework.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GAZE.Customer {
    public partial class UpdateCustomerDetails : KryptonForm
    {
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly InfoSec InfoSec = new InfoSec();
        readonly ConfigAdmin ConfigAdmin = new ConfigAdmin();
        readonly ControlManagement ControlManagement = new ControlManagement();
        readonly Validations Validations = new Validations();
        readonly MessageHandler messageHandler = new MessageHandler();

        public UpdateCustomerDetails() 
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "Update Customer Details");


            foreach (MetroLabel item in this.Controls.OfType<MetroLabel>()) {
                //item.BackColor = SystemColors.ActiveCaption;
                item.UseCustomBackColor = true;
                item.Font = new Font(item.Font, FontStyle.Bold);
                item.FontWeight = MetroFramework.MetroLabelWeight.Bold;
                item.AutoSize = true;
            }
            ControlManagement.PopulateTitle(CustTitle_cmb);
        }

        private void UpdateCustomerDetails_Load(object sender, EventArgs e) {
            CustID_lbl.Text = "CustomerID: " + InfoSec.GlobalCustomerID;
            CustomerManagement.GetCustomerForUpdates(CustTitle_cmb, CustFN_txt, CustSN_txt, metroDateTime1, CustNum_txt, AltNumb_txt, CustEmail_txt);


        }

        private void metroButton1_Click(object sender, EventArgs e) {
            if (Validations.IsValidPhone(CustNum_txt.Text) == false) {
                KryptonMessageBox.Show("The contact number you have entered is not valid!\n\nPlease check and confirm this number is correct with the customer", "Whoops!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, 0, 0, false, false, false, false, null);
                return;
            }
            if (Validations.IsValidEmail(CustEmail_txt.Text) == false) {
                KryptonMessageBox.Show("The email address you have entered is not valid!\n\nPlease check and confirm this email address is correct with the customer", "Whoops!", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, 0, 0, false, false, false, false, null);
                return;
            }
            CustomerManagement.UpdateCustomerDetails(CustTitle_cmb, CustFN_txt, CustSN_txt, metroDateTime1, CustNum_txt, AltNumb_txt, CustEmail_txt, this);
        }


    }
}
