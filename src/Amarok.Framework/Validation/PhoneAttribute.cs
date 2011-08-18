using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Amarok.Framework.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneAttribute : ValidationAttribute
    {
        private const string defaultErrorMessage = "{0} is not a correct phone.";
        private const string emailRegex = @"^(\d{2,3}|\(\d{2,3}\))[ ]?\d{3,4}[-]?\d{3,4}$";
        private string currentErrorMessage;

        public PhoneAttribute(string validationMessage)
        {
            this.currentErrorMessage = validationMessage;
        }

        public PhoneAttribute() : this(defaultErrorMessage) { }

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
