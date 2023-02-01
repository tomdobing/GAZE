using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Gaze.BusinessLogic.Config
{
    public class Validations
    {
        /// <summary>
        /// Method used to validate if the email address entered matches the standard format for an email address
        /// </summary>
        /// <param name="email">Email address to be validated</param>
        /// <returns>true if match</returns>
        public  bool IsValidEmail(string email)
        {
            string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            return Regex.IsMatch(email, pattern);
            
        }
        /// <summary>
        /// Method used to validate if the phone number matches UK formats
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool IsValidPhone(string phone)
        {
            string pattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";
            return Regex.IsMatch(phone, pattern);
        }

        public bool IsOverRequiredAge(DateTime BirthDate)
        {
            int age = DateTime.Today.Year - BirthDate.Year;
            if (BirthDate > DateTime.Today.AddYears(-age)) age--;
            return age >=18;
            
        }

    }
}
