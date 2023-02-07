using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Exceptions
{
    public class MessageHandler
    {
        /// <summary>
        /// Method to return a messagebox that is custom generated
        /// </summary>
        /// <param name="message">The main message of the messagebox</param>
        /// <param name="caption">Title of the box</param>
        /// <param name="buttons">What buttons to display</param>
        /// <param name="icon">What type of message box to display i.e ERROR, INFORMATION, WARNING</param>
        /// <returns></returns>
        public  DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, caption, buttons, icon);
        }

    }
}
