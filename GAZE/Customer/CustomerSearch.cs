using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class CustomerSearch : Form
    {
        readonly FormSettings FormSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        public CustomerSearch()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, Name);
        }

        private void CustomerSearch_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //    if (dataGridView1.Visible) 
            //    {
            //        dataGridView1.Hide();
            //    }
            //    else
            //    {
            //        dataGridView1.Visible = true;
            CustomerManagement.GetCustomerDataByContactNumber(SearchNum_txt.Text, dataGridView1);

        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int selectedRowIndex = e.RowIndex;
            //DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            //int rowID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
            //MessageBox.Show(rowID.ToString());
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            int rowID = Convert.ToInt32(selectedRow.Cells["CustomerID"].Value);
            MessageBox.Show(rowID.ToString());

        }
    }
}

