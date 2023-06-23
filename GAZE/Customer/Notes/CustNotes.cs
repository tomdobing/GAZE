using Gaze.BusinessLogic.BillingManagement;
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

namespace GAZE.Customer.Notes
{
    public partial class CustNotes : KryptonForm
    {

        #region Declarations
        FormSettings FormSettings = new FormSettings();
        InfoSec InfoSec = new InfoSec();
        CustomerManagement CustomerManagement = new CustomerManagement();
        SQLManagement PolicySQLManagement = new SQLManagement();
        HomePage HomePage = new HomePage();
        SQLBilling SQLBilling = new SQLBilling();
        ControlManagement ControlManagement = new ControlManagement();
        NoteManagement NoteManagement = new NoteManagement();
        #endregion
        public CustNotes()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Insert Note - CustomerID:" + InfoSec.GlobalCustomerID);
            FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            NoteManagement.PopulateNoteTable(kryptonDataGridView1);
        }

        private void CustNotes_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            NewNote newNote = new NewNote();
            newNote.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
