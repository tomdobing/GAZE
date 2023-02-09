using Gaze.BusinessLogic.Config;
using System;
using System.Windows.Forms;
using Gaze.BusinessLogic.SQLManagement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GAZE.Customer
{
    public partial class CustomerNotes : Form
    {
        readonly FormSettings FormSettings = new FormSettings();
        readonly CustomerManagement customerManagement = new CustomerManagement();
        public CustomerNotes()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, Name);
            CustName_txt.Enabled = false;
            NoteID_txt.Enabled = false;
            notedetails_txt.Enabled = false;
            CreateDate_txt.Enabled = false;
            CreateBy_txt.Enabled = false;
        }

        private void CustomerNotes_Load(object sender, EventArgs e)
        {
            customerManagement.GetCustomerNotesForDataGrid(NoteDataGridView);
            //customerManagement.GetCustomerNotes(NoteID_txt.Text, NoteDataGridView, CustName_txt.Text, notedetails_txt.Text, CreateBy_txt.Text, CreateDate_txt.Text);

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NoteDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (NoteDataGridView.SelectedCells.Count > 0)
            {

                int rownum = NoteDataGridView.SelectedCells[0].RowIndex;
                NoteID_txt.Text = NoteDataGridView.Rows[rownum].Cells["NoteID"].Value.ToString();
                CustName_txt.Text = NoteDataGridView.Rows[rownum].Cells["CustomerName"].Value.ToString();
                notedetails_txt.Text = NoteDataGridView.Rows[rownum].Cells["NoteDetails"].Value.ToString();
                CreateBy_txt.Text = NoteDataGridView.Rows[rownum].Cells["CreatedBy"].Value.ToString();
               CreateDate_txt.Text = NoteDataGridView.Rows[rownum].Cells["CreatedDate"].Value.ToString();
                // etc. for each text box
            }
        }
    }
}
