using Krypton.Toolkit;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.Security.Management
{
    /// <summary>
    /// Control Access Helper used to disabled Specified controls
    /// </summary>
    public class ControlAccessHelper
    {
        SQLDataAdmin SQLDataAdmin = new SQLDataAdmin();

        /// <summary>
        /// Method Used To Disable MenuStripItems
        /// </summary>
        /// <param name="men"></param>
        public void DisableItemsMenuItems(MenuStrip men)
        {
            SQLDataAdmin.GetAllDisabledControls();
            foreach (string controls in SQLDataAdmin.DisabledControls)
            {
                ToolStripMenuItem menuItem = men.Items.Find(controls, true).FirstOrDefault() as ToolStripMenuItem;
                if (menuItem != null)
                {
                    menuItem.Enabled = false;
                }
            }
        }
        /// <summary>
        /// Method called to find controls
        /// </summary>
        /// <param name="Form"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public Control FindControlByName(KryptonForm Form, string controlName)
        {

            foreach (Control control in Form.Controls)
            {
                if (control.Name == controlName)
                {
                    return control;
                }
                if (control.HasChildren)
                {
                    Control nestedControl = FindControlByName(Form, controlName);
                    if (nestedControl != null)
                    {
                        return nestedControl;
                    }
                }
            }

            return null;
        }

        public void disableOtherControls(KryptonForm Form)
        {
            foreach (string Controlname  in SQLDataAdmin.GetAllDisabledControls())
            {
                Control control = FindControlByName(Form, Controlname);
                if (control != null)
                {
                    control.Enabled = false;
                }
            }
        
        
        }


        /// <summary>
        /// Called to execute Control Management.
        /// </summary>
        /// <param name="FormWithControls"></param>
        /// <param name="MenuStrips"></param>
        public void ExecuteControlManagement(KryptonForm FormWithControls, [Optional] MenuStrip MenuStrips, [Optional] Control ctrlToDisable)
        {
            foreach (string ControlName in SQLDataAdmin.GetAllDisabledControls())
            {
                Debug.WriteLine(ControlName);
                Control control = FindControlByName(FormWithControls, ControlName);
                if (control != null)
                {
                    Debug.WriteLine(control.Name);
                    control.Enabled = false;
                }



            }
            DisableItemsMenuItems(MenuStrips);
            


        }
    }



}

