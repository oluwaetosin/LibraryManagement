using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Books;
using Library.Domain.Users;
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

        public async Task<bool> BookIsAvailable(int bookId)
        {
            var bookExist = await  _dbContext.Books.FindAsync(bookId);

            if(bookExist == null)
            {
                return false;
            }

            var reservedBooks = await _dbContext.BookReservations.Where(x=>x.BookID == bookId
            
            && (x.ReservationDateTime.AddHours(48) > DateTime.Now)).ToListAsync();

            if(reservedBooks.Count < bookExist.CopiesAvailable)
            {
                return true;
            }

            return false;


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

        public async Task ReserveBook(BookReservation reservation)
        {
            _dbContext.BookReservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task BorrowBook(BookBorrow bookBorrow)
        {
            _dbContext.BookBorrows.AddAsync(bookBorrow);
            await _dbContext.SaveChangesAsync();
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

        public async Task QueueNotification(int userId, int bookId)
        {
            var notification = new NotificationQueue
            {
                BookID = bookId,
                UserID = userId,
            };

            await _dbContext.AddAsync(notification);

            await _dbContext.SaveChangesAsync();

        }

        
    }
}
