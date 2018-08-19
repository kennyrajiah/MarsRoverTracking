using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarsRoverTracking.Utilities
{
    public class ValidValuesAttribute : ValidationAttribute
    {

        string _args;

        public ValidValuesAttribute(string args)
        {
            _args = args;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            foreach (char c in value.ToString())
                if (_args.Contains(c))
                    return ValidationResult.Success;
            return new ValidationResult("Invalid value.");
        }
    }
}