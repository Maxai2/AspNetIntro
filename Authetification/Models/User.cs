using System.ComponentModel.DataAnnotations;

namespace Authetification.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string PswdHash { get; set; }

        [Required]
        [MaxLength(50)]
        public string Salt { get; set; }
    }
}
