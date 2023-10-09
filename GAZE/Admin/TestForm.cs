using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAZE.Admin
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(KryptonInputBox.Show("Test", "TEST CAPTION", "asdasd", "Help", default, default, default));
            

        }

        private void button1_Click(object sender, EventArgs e)
        {kryptonInputBoxExtendedManager1.DisplayInputBox();
        }
    }
}
