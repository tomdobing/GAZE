using Gaze.BusinessLogic.SQLManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Security {

    public class RoleManagement {

        InfoSec InfoSec = new InfoSec();
        public bool DisableNonAdminControls([Optional] Control control) 
        {

            if (string.IsNullOrEmpty(InfoSec.GlobalUsername)) return false;

            if (InfoSec.isUserAdmin(InfoSec.GlobalUsername) == false) 
            {
                control.Enabled = false;
                return false;
            }
            else {
                return true;
            }
        }

        public static void RestrictedControls(Control ParentControl, string userRole)
        {
            foreach (Control item in ParentControl.Controls)
            {
                if (item.HasChildren)
                {
                    RestrictedControls(item, userRole);
                }
                if (item.Tag != null && item.Tag.ToString().Contains("Retricted"))
                {
                    string[] roles = item.Tag.ToString().Replace("Restricted", "").Split(',');
                    if (!roles.Contains(userRole))
                    {
                        item.Enabled = false;
                    }
                }

            }
        
        }

        
    }
}
