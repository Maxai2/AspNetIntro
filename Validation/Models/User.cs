using System;

namespace Validation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
    }
}
