using Library.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Common.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public LibraryDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
