using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
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

namespace GAZE.Customer {
    public partial class CustomerHistory : Form {

        private readonly FormSettings formSettings = new FormSettings();
        private readonly CustomerManagement CustomerManagement = new CustomerManagement();
        private readonly InfoSec InfoSec = new InfoSec();
        private readonly ConfigAdmin ConfigAdmin = new ConfigAdmin();
        private readonly ControlManagement ControlManagement = new ControlManagement();
        private readonly Validations Validations = new Validations();
        private readonly MessageHandler messageHandler = new MessageHandler();


        public CustomerHistory() 
        {
            InitializeComponent();
            formSettings.SetFormSettings(this);
            formSettings.ChangeableFormSettings(this, "Customer Details History");
        }
        
        private void CustomerHistory_Load(object sender, EventArgs e) 
        {
            CustomerManagement.GetCustomerHistory(metroGrid1);
        }
    }
}
