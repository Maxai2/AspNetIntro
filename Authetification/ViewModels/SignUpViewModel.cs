using System.ComponentModel.DataAnnotations;

namespace Authetification.ViewModels
{
    public class SignUpViewModel
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

        [Display(Name = "Repeat")]
        [Required]
        [Compare("Pswd")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Pswd2 { get; set; }
    }
}
