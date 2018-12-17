using Microsoft.EntityFrameworkCore;
using Authetification.Models;

namespace Authetification.EF
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            Database.EnsureCreated(); // создает бд при запуске
        }
    }
}
