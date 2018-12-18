using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [DefaultValue(true)]
        public bool Gender { get; set; }

        [Required]
        [DefaultValue(0)]
        public int BYear { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
