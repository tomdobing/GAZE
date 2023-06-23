using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using GAZE.BusinessLogic.DocumentManagement;
using Krypton.Toolkit;
using System;

namespace GAZE.Help
{
    public partial class AcceptedFileTypes : KryptonForm
    {
        #region Declarations
        FormSettings FormSettings = new FormSettings();
        HomePage HomePage = new HomePage();
        DocumentRetrieval DocumentRetrieval = new DocumentRetrieval();
        #endregion

        #region Methods
        public AcceptedFileTypes()
        {
            InitializeComponent();
            DocumentRetrieval.GetAcceptableFileTypesForHelpPage(kryptonDataGridView1);
        }

        private void AcceptedFileTypes_Load(object sender, EventArgs e)
        {
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "HELP - Accepted File Types");
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
        }





        #endregion
    }
}
