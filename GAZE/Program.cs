using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaze.BusinessLogic.Startup;
namespace GAZE
{
    
    internal static class Program
    {

        //static Admin.LoginForm loginForm;
        ///// <summary>
        ///// The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    //new Admin.LoginForm().Show();
        //    Application.Run(new Admin.LoginForm());
        //    Application.Run();
        //    //loginForm = new Admin.LoginForm();
        //    //Application.Run(loginForm);
        //}

        
        /// <summary>
        /// Startup form changed to allow login screen to close
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Admin.LoginForm();
            main.FormClosed += new FormClosedEventHandler(FormClosed);
            main.Show();
            Application.Run();
        }

        static void FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= FormClosed;
            if (Application.OpenForms.Count == 0) Application.ExitThread();
            else Application.OpenForms[0].FormClosed += FormClosed;
        }
    }
}
