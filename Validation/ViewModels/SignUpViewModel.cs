using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Validation.ViewModels
{
    public class SignUpViewModel
    {
        [Display (Name = "Email")]
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress]
        [Remote(action: "CheckEmail", controller: "User", HttpMethod = "POST", ErrorMessage = "Email used")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm")]
        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Password must be equal")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }
    }
}
