using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Validation.Services;

namespace Validation.Utils
{
    public class CheckEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IUserService userService = (IUserService)validationContext.GetService(typeof(IUserService));

            if (userService.CheckEmail(value.ToString()))
            {
                //return new ValidationResult(GetErrorMessage(value.ToString()));
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(string email)
        {
            return $"Email {email} already used";
        }
    }
}
