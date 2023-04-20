﻿using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
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

namespace GAZE.Policy
{
    public partial class NewCustomerPolicy : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        CustCallBack CustCallBack = new CustCallBack();
        ControlManagement ControlManagement = new ControlManagement();
        ProductDetails ProductDetails = new ProductDetails();
        #endregion

        public NewCustomerPolicy()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "New Policy - CustomerID:" + InfoSec.GlobalCustomerID);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            ControlManagement.PopulateProductName(kryptonComboBox1);
            PolStarDate_dtp.Format = DateTimePickerFormat.Custom;
            PolStarDate_dtp.CustomFormat = "yyyy/dd/MM hh:mm tt";
            PolStarDate_dtp.Value = DateTime.Now;

        }

        private void NewCustomerPolicy_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ProductDetails.GetProductDetailsFromCombo(kryptonComboBox1,ProdID_txt ,prodname_txt, proddesc_txt, prodstatus_txt, prodprice_txt, prodstartdate_txt, prodenddate_txt);
        }

        private void kryptonGroupBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (PolicySQLManagement.CheckCustomerAlreadyActiveProduct(prodname_txt) == true)
            {

                KryptonMessageBox.Show("No Product has been selected\n\n Please pick a valid product to enroll this Customers products",
                    "Index Out Of Range", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            if (kryptonComboBox1.SelectedIndex == -1)
            {
                KryptonMessageBox.Show("No Product has been selected\n\n Please pick a valid product to enroll this Customers products",
                    "Index Out Of Range", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;
            }
            if (PolStarDate_dtp.Value == DateTime.MinValue)
                
            {
                KryptonMessageBox.Show("An invalid start date has been selceted\n\n Please pick a valid Policy Start Date",
                "Index Out Of Range", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error, 0, 0, false, false, false, false, null);
                return;

            }
            PolicySQLManagement.CreateNewCustomerPolicy(prodname_txt, PolStarDate_dtp, this);

        }
    }
}