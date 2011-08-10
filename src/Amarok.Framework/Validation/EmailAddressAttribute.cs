using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Amarok.Framework.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAddressAttribute : ValidationAttribute
    {
        private const string defaultErrorMessage = "{0} is not a correct email.";
        private const string emailRegex = @"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.(([0-9]{1,3})|([a-zA-Z]{2,3})|(aero|coop|info|museum|name))$";
        private string currentErrorMessage;

        public EmailAddressAttribute(string validationMessage)
        {
            this.currentErrorMessage = validationMessage;
        }

        public EmailAddressAttribute() : this(defaultErrorMessage) { }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, defaultErrorMessage ?? currentErrorMessage, name);
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(Convert.ToString(value), emailRegex);
        }
    }
}
