using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class AddressDetails : Form
    {
        readonly FormSettings FormSettings = new FormSettings();
        readonly CustomerManagement customerManagement = new CustomerManagement();
        public AddressDetails()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, Name);
            customerManagement.PopulateCountried(Country_cmb);
        }

        private void AddressDetails_Load(object sender, EventArgs e)
        {
            customerManagement.GetCustomerAddress(Addr1_txt, AddrL2_txt, Town_txt, postalcode_txt, Country_cmb);
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
