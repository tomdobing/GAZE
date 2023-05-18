using Gaze.BusinessLogic.BillingManagement;
using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.CustomerManagement;
using Gaze.BusinessLogic.PolicyManagement;
using Gaze.BusinessLogic.SQLManagement;
using GAZE.BusinessLogic.DocumentManagement;
using Krypton.Toolkit;
using System;
using System.IO;
using System.Windows.Forms;

namespace GAZE.Customer.Documents
{
    public partial class CustomerDocuments : KryptonForm
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
        NoteManagement NoteManagement = new NoteManagement();
        DocumentRetrieval DocumentRetrieval = new DocumentRetrieval();
        DocumentConfiguration DocumentConfiguration = new DocumentConfiguration();
        #endregion

        public CustomerDocuments()
        {
            InitializeComponent();
            FormSettings.ChangeableFormSettings(this, "Customer Documents - CustomerID:" + InfoSec.GlobalCustomerID);
            FormSettings.SetFormSettings(this);
            this.Palette = HomePage.kryptonManager1.GlobalPalette;
            kryptonHeader1.Values.Description = "CustomerID: " + InfoSec.GlobalCustomerID;
            DocumentRetrieval.PopulateAcceptedFileTypes();


        }

        private void CustomerDocuments_Load(object sender, EventArgs e)
        {
            DocumentRetrieval.GetCustomerDocuments(kryptonDataGridView1);
        }


        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            DataGridViewRow selectedRow = kryptonDataGridView1.Rows[selectedRowIndex];

            int rowID = Convert.ToInt32(selectedRow.Cells["DocumentID"].Value);
            DocumentRetrieval.OpenCustomerDocument("", rowID);
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
               MessageBox.Show("Error");
                return;
            }
           
            string filepath = openFileDialog.FileName;
            long filesize = new FileInfo(openFileDialog.FileName).Length;
            string newfilepath = @"C:\Temp\GAZE\Documents\" + Path.GetFileName(filepath);
            DocumentRetrieval.UploadCustomerDocument(GetFileType(Path.GetExtension(filepath)),
            Path.GetFileName(filepath), newfilepath, ConvertBytesToMB(filesize).ToString("0.00") + "MB", filepath);
            

        }
        public string GetFileType(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }

            string extension = Path.GetExtension(filePath);
            return !string.IsNullOrEmpty(extension) ? extension.TrimStart('.') : string.Empty;
        }
        public double ConvertBytesToMB(long bytes)
        {
            return (double)bytes / (1024 * 1024);
        }

        private void CustomerDocuments_FormClosing(object sender, FormClosingEventArgs e)
        {
            DocumentRetrieval.AcceptedFileTypes = null;
        }
    }
}
