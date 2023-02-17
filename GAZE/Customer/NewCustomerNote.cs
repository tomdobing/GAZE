﻿using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.SQLManagement;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GAZE.Customer
{
    public partial class NewCustomerNote : Form
    {

        readonly FormSettings formSettings = new FormSettings();
        readonly CustomerManagement CustomerManagement = new CustomerManagement();
        readonly InfoSec InfoSec = new InfoSec();
        readonly ControlManagement controlManagement = new ControlManagement();
        readonly MessageHandler messageHandler = new MessageHandler();

        public NewCustomerNote()
        {
            InitializeComponent();
            formSettings.ChangeableFormSettings(this, Name);
            formSettings.SetFormSettings(this);
        }

        private void NewCustomerNote_Load(object sender, EventArgs e)
        {
            CustID_txt.Text = InfoSec.GlobalCustomerID;
            CustID_txt.ReadOnly = true;
            controlManagement.PopulateNoteCategory(metroComboBox1);
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            NoteDesc_txt.Text = string.Empty;
            NoteDetails_txt.Text = string.Empty;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Create_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroComboBox1.Text))
            {
                messageHandler.ReturnInfoBox("Note Category not selected \n\nPlease check and try again", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrEmpty(NoteDesc_txt.Text))
            {
                messageHandler.ReturnInfoBox("You have not entered a note description! \n\nPlease check and try again", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Stop);
                return;
            }
            if (string.IsNullOrEmpty(NoteDetails_txt.Text))
            {
                messageHandler.ReturnInfoBox("You have note entered any note details\n\nPlease ensure you leave a detailed note \n\ncheck and try again", InfoBox.InformationBoxButtons.OK, InfoBox.InformationBoxIcon.Stop);
                return;
            }
            Thread.Sleep(1000);
            CustomerManagement.InsertNewCustomerNote(NoteDesc_txt.Text, NoteDetails_txt.Text,true, this, metroComboBox1.SelectedItem.ToString());
        }
    }
}
