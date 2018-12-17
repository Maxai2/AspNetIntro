using System.ComponentModel.DataAnnotations;

namespace Authetification.ViewModels
{
    public class SignInViewModel
    {
        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Pswd { get; set; }
    }
}
