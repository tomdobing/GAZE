using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaze.BusinessLogic.Exceptions
{
    public class GAZEGeneralException : Exception
    {

        public GAZEGeneralException()
        {


        }


        public GAZEGeneralException(String message) 
            : base(message) 
        { 
        
        
        }

        public GAZEGeneralException(string message, Exception inner)
            : base(message, inner) 
        {

        }
    }
}
