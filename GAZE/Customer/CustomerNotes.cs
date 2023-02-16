using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Windows.Forms;

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
            CustName_txt.ReadOnly = true;
            NoteID_txt.ReadOnly = true;
            notedetails_txt.ReadOnly = true;
            CreateDate_txt.ReadOnly = true;
            CreateBy_txt.ReadOnly = true;
        }

        private void CustomerNotes_Load(object sender, EventArgs e)
        {
            customerManagement.GetCustomerNotesForDataGrid(NoteGridview);
            //customerManagement.GetCustomerNotes(NoteID_txt.Text, NoteDataGridView, CustName_txt.Text, notedetails_txt.Text, CreateBy_txt.Text, CreateDate_txt.Text);

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NoteGridview_SelectionChanged(object sender, EventArgs e)
        {
            if (NoteGridview.SelectedCells.Count > 0)
            {

                int rownum = NoteGridview.SelectedCells[0].RowIndex;
                NoteID_txt.Text = NoteGridview.Rows[rownum].Cells["NoteID"].Value.ToString();
                CustName_txt.Text = NoteGridview.Rows[rownum].Cells["CustomerName"].Value.ToString();
                notedetails_txt.Text = NoteGridview.Rows[rownum].Cells["NoteDetails"].Value.ToString();
                CreateBy_txt.Text = NoteGridview.Rows[rownum].Cells["CreatedBy"].Value.ToString();
                CreateDate_txt.Text = NoteGridview.Rows[rownum].Cells["CreatedDate"].Value.ToString();
                
            }
        }
    }
}
