using Library.Domain.Books;
using Library.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Common.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<BookReservation> BookReservations { get; set; } = null!;

        public LibraryDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
