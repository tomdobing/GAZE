﻿using Gaze.BusinessLogic.Config;
using Gaze.BusinessLogic.Exceptions;
using Gaze.BusinessLogic.Security;
using Gaze.BusinessLogic.SQLManagement;
using Gaze.Security.Management;
using Krypton.Toolkit;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GAZE.Admin
{
    public partial class ControlAdminNotes : KryptonForm
    {
        #region Declarations
        readonly FormSettings GetFormSettings = new FormSettings();
        readonly ControlManagement ControlManagement = new ControlManagement();
        readonly HomePage HomePage = new HomePage();
        #endregion


        public ControlAdminNotes()
        {
            InitializeComponent();
            GetFormSettings.SetFormSettings(this);
            GetFormSettings.ChangeableFormSettings(this, this.Name);
            Palette = HomePage.kryptonManager1.GlobalPalette;
            catNoteName_txt.Enabled = false;
            catNoteDesc_txt.Enabled = false;
            disablecat_chk.Enabled = false;
            catType_cmb.Enabled = false;
        }

        private void ControlAdminNotes_Load(object sender, EventArgs e)
        {
            ExecuteLoad();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (currNoteValue_cmb.SelectedItem == "Add New Value")
            {
                catNoteName_txt.Enabled = true;
                catNoteDesc_txt.Enabled = true;
                disablecat_chk.Enabled = false;
                catType_cmb.Enabled = true;
                createCat_btn.Enabled = true;
            }
            else
            {
                catNoteName_txt.Enabled = false;
                catNoteDesc_txt.Enabled = false;
                disablecat_chk.Enabled = true;
                catType_cmb.Enabled = false;
                createCat_btn.Enabled = false;
            }
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (disablecat_chk.CheckState == System.Windows.Forms.CheckState.Checked)
            {
                string message = "You are about to disable " + currNoteValue_cmb.SelectedItem.ToString() + ". \n This will remove it for everyone.\n\n Are you sure you wish to continue?";
                string caption = "Are you sure?";
                DialogResult result;
                result = KryptonMessageBox.Show(message, caption, MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question, KryptonMessageBoxDefaultButton.Button3);
                if (result == DialogResult.Yes)
                {

                   ControlManagement.SetNoteCategoryToDisabled(currNoteValue_cmb.SelectedItem.ToString());
                   disablecat_chk.CheckState = CheckState.Unchecked;
                }
                if (result == DialogResult.No) 
                {
                    KryptonMessageBox.Show("User Cancelled. \n\n No Changes Made!", "Cancelled", MessageBoxButtons.OK, KryptonMessageBoxIcon.Information, KryptonMessageBoxDefaultButton.Button3);
                    disablecat_chk.CheckState = CheckState.Unchecked;
                    return;
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (currNoteValue_cmb.SelectedIndex == -1 )
            {
                KryptonMessageBox.Show("You have not selected an option ", "Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                return;
            }
            if (catType_cmb.SelectedIndex == -1)
            {
                KryptonMessageBox.Show("You have not selected an option for Category Type ", "Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                return;
            }
            if (currNoteValue_cmb.Text == "Add New Value")
            {
                if (string.IsNullOrEmpty(catNoteName_txt.Text))
                {
                    KryptonMessageBox.Show("You must enter a Name for the new Note Category.", "Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                    return;
                }
                if (string.IsNullOrEmpty(catNoteDesc_txt.Text))
                {
                    KryptonMessageBox.Show("You must enter a Description for the new Note Category Description.", "Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button3);
                    return;
                }
                ControlManagement.CreateNewNoteCategory(catNoteName_txt.Text, catNoteDesc_txt.Text, catType_cmb.SelectedItem.ToString());
            }
        }

        private void currNoteValue_cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            //KryptonComboBox kryptonComboBox = (KryptonComboBox)sender;
            string ItemText = currNoteValue_cmb.GetItemText(currNoteValue_cmb.Items[e.Index]);

            bool shouldDrawBold = ItemText == "Add New Value";

            Font itemFont = shouldDrawBold ? new Font(e.Font, FontStyle.Bold) : e.Font;
            e.DrawBackground();
            e.Graphics.DrawString(ItemText, itemFont,Brushes.Black, e.Bounds.X, e.Bounds.Y);
            e.DrawFocusRectangle();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExecuteLoad()
        {
            ControlManagement.PopulateNoteCategory(currNoteValue_cmb);
            currNoteValue_cmb.Items.Add("Add New Value");
            ControlManagement.PopulateNoteCategoryType(catType_cmb);
        }
    }
}
