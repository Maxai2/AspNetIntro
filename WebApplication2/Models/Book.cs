using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }

        //[Required]
        //[ForeignKey("AuthorID")]
        //public virtual Author Author { get; set; }
    }
}
