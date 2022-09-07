using EventLibrary.Dialog;
using System;
namespace Gaze.BusinessLogic.Exceptions
{

    public class ExceptionThrown
    {
        frmExceptionDialog frmExceptionDialog = new frmExceptionDialog();


        public void ThrowNewStackException(Exception ex, string Text)
        {
            frmExceptionDialog frmExceptionDialog = new frmExceptionDialog
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Text = Text,
                TopMost = true
            };
            frmExceptionDialog.Show();
            
        }

        public void ThrowNewException(string message,string stacktrace, string Text)
        {
            frmExceptionDialog frmExceptionDialog = new frmExceptionDialog
            {
                Message = message,
                StackTrace = stacktrace,
                Text = Text,
                TopMost = true
            };
            frmExceptionDialog.Show();

        }

    }
}
