using Library.Application.Common.Interfaces;
using Library.Domain.Books;
using Library.Infrastructure.Common.Persistence;

namespace Library.Infrastructure.Books.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateBook(Book book)
        {
            await  _dbContext.Books.AddAsync(book);

            await _dbContext.SaveChangesAsync();
        }
    }
}
