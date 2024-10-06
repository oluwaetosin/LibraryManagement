using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Books;
using Library.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public  async Task<IList<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int bookId)
        {
            return await _dbContext.Books.FindAsync(bookId);
        }

        public async Task<IList<Book>> SearchBook(string bookName)
        {
           return await _dbContext.Books.Where(x => x.Title.Contains(bookName)).ToListAsync();
        
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var currbook = await GetBookById(book.BookID);

            if(currbook == null) {
                return null;
            }

            currbook.ISBN = book.ISBN;
            currbook.Title = book.Title;
            currbook.Location = book.Location;
            currbook.Category = book.Category;
            currbook.Author = book.Author;
            currbook.CopiesAvailable = book.CopiesAvailable;
            currbook.Edition = book.Edition;

            await _dbContext.SaveChangesAsync();

            return currbook;

        }
    }
}
