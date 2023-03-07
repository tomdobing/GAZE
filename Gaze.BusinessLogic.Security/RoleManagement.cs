using Gaze.BusinessLogic.SQLManagement;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Security {

    public class RoleManagement {

        InfoSec InfoSec = new InfoSec();
        public bool DisableNonAdminControls([Optional] Control control) {

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

        
    }
}
