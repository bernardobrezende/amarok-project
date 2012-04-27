using System;
using System.ComponentModel.DataAnnotations;

namespace Amarok.Framework.Validation
{
    public sealed class DateGreaterThanAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' must be greater than '{1}'";
        private string _basePropertyName;

        public DateGreaterThanAttribute(string basePropertyName)
            : base(_defaultErrorMessage)
        {
            this._basePropertyName = basePropertyName;
        }

        public DateGreaterThanAttribute(string baseProperty, string errorMessage)
            : base(errorMessage)
        {
            this._basePropertyName = baseProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(_defaultErrorMessage, name, _basePropertyName);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Get PropertyInfo Object  
            var basePropertyInfo = validationContext.ObjectType.GetProperty(_basePropertyName);

            //Get Value of the property  
            var startDate = (DateTime?)basePropertyInfo.GetValue(validationContext.ObjectInstance, null);

            var thisDate = (DateTime?)value;

            //Actual comparision  
            if (startDate.HasValue && thisDate.HasValue && thisDate <= startDate)
            {
                var message = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(message);
            }

            //Default return - This means there were no validation error  
            return null;
        }
    }  
}
