using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAZE.BusinessLogic.DocumentManagement
{
    public class DocumentConfiguration
    {
        #region Declarations
        private readonly static string SQLConnectionString = ConfigurationManager.AppSettings["SQLConnection"];
        public static string FilePathToOpen;
        #endregion

        #region Methods
        #endregion


    }
}
