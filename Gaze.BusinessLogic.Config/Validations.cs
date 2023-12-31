﻿using Gaze.BusinessLogic.SQLManagement;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Gaze.BusinessLogic.Config
{
    public class Validations
    {
        readonly SQLManagement.ConfigAdmin ConfigAdmin = new SQLManagement.ConfigAdmin();
        /// <summary>
        /// Method used to validate if the email address entered matches the standard format for an email address
        /// </summary>
        /// <param name="email">Email address to be validated</param>
        /// <returns>true if match</returns>
        public bool IsValidEmail(string email)
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
        /// <summary>
        /// Method to validate is the customer is over the age of X Years
        /// </summary>
        /// <param name="BirthDate">The date of birth of the customer</param>
        /// <returns>Returns if over X Years</returns>
        public bool IsOverRequiredAge(DateTime BirthDate)
        {
            int age = DateTime.Today.Year - BirthDate.Year;
            if (BirthDate > DateTime.Today.AddYears(-age)) age--;
            return age >= ConfigAdmin.GetValueForApp("AgeLimit");

        }
        public void control_Validating(object sender, CancelEventArgs e, Control ctr, ErrorProvider errorProvider1)
        {
            if (ctr.Text == "")
            {
                
                errorProvider1.SetError(ctr, "This field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(ctr, "");
                e.Cancel = false;
            }
        }

    }
}
