using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.Config;

namespace GAZE.Config
{
    public partial class ControlAdmin : Form
    {

        FormSettings FormSettings = new FormSettings();

        public ControlAdmin()
        {
            InitializeComponent();
            FormSettings.SetFormSettings(this);
            FormSettings.ChangeableFormSettings(this, "Controls Admin");
        }

        private void ControlAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
