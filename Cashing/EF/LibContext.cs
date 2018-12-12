using Microsoft.EntityFrameworkCore;
using Caching.Models;

namespace Caching.EF
{
    public class LibContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LibContext(DbContextOptions<LibContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
