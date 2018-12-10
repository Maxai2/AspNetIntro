using System;
using System.ComponentModel.DataAnnotations;

namespace Validation.ViewModels
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(3, ErrorMessage = "Min length 3 chars")]
        [MaxLength(30, ErrorMessage = "Max length 3 chars")]
        public string Name { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Avatar")]
        [DataType(DataType.ImageUrl)]
        public string Avatar { get; set; }
    }
}
