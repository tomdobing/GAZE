using Krypton.Toolkit;
using System.Text.RegularExpressions;

namespace Gaze.BusinessLogic.BillingManagement
{
    public class Validations
    {


        public bool ValidateBankAccountNumber(KryptonTextBox AccountNumber)
        {
            if (AccountNumber == null)
            {
                return false;
            }
            if (AccountNumber.TextLength != 8)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ValidateSortCodeNumber(KryptonTextBox sortCode)
        {
            // Define a regular expression pattern to match the UK sort code format
            string pattern = @"^\d{2}-\d{2}-\d{2}$";

            // Use the Regex.IsMatch method to check if the sort code matches the pattern
            if (Regex.IsMatch(sortCode.Text, pattern))
            {
                // The sort code matches the pattern, return true
                return true;
            }
            else
            {
                // The sort code does not match the pattern, return false
                return false;
            }
        }
    }
}
