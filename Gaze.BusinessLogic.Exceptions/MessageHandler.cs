using InfoBox;
using System.Windows.Forms;

namespace Gaze.BusinessLogic.Exceptions
{
    public class MessageHandler
    {
        /// <summary>
        /// Method to return a message box that is custom generated
        /// </summary>
        /// <param name="message">The main message of the message box</param>
        /// <param name="caption">Title of the box</param>
        /// <param name="buttons">What buttons to display</param>
        /// <param name="icon">What type of message box to display i.e ERROR, INFORMATION, WARNING</param>
        /// <returns></returns>
        public DialogResult ShowMessage(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, caption, buttons, icon);
        }

        /// <summary>
        /// Customer Message Handler for error and information boxes
        /// </summary>
        /// <param name="message">The main message of the box</param>
        /// <param name="buttons">Which buttons to display i.e OK, Yes/No</param>
        /// <param name="icon">What icon war stop excl</param>
        public void ReturnInfoBox(string message, InformationBoxButtons buttons, InformationBoxIcon icon)
        {
            InformationBox.Show(message, buttons, icon, InformationBoxStyle.Modern, InformationBoxSound.Default,
                InformationBoxOrder.TopMost, InformationBoxBehavior.Modal);
        }

    }
}
