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

namespace GAZE.Customer
{
    public partial class NewCustomer : Form
    {

        #region Declarations
        FormSettings formSettings = new FormSettings();
        #endregion
        public NewCustomer()
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "New Customer");
        }

        private void NewCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
