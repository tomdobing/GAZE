using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;

namespace GAZE.Customer
{
    public partial class NewCustomer : Form
    {

        #region Declarations
        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly ConfigAdmin ConfigAdmin = new ConfigAdmin();
        #endregion
        public NewCustomer()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer");
            CustomerManagement.PopulateTitle(CmbTitle);
            DOB_DTP.Format = DateTimePickerFormat.Custom;
            DOB_DTP.CustomFormat = ConfigAdmin.GetConfigValue("DateFormat");
            ContactNmr_txt.MaxLength = 16;
                
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }

        private void Close_BTN_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            FirstName_Txt.Clear();
            surname_txt.Clear();
            ContactNmr_txt.Clear();
            Email_TXT.Clear();
            Address_Txt.Clear();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CustomerManagement.CreateNewCustomer(CmbTitle, FirstName_Txt, surname_txt, DOB_DTP, ContactNmr_txt, Email_TXT, Address_Txt, metroCheckBox1);
        }
    }
}
