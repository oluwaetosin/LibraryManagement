using DomainBooks = Library.Domain.Books;

namespace Library.Application.Common.Interfaces
{
    public interface IBookRepository
    {
        Task CreateBook(DomainBooks.Book book);
        Task<DomainBooks.Book> UpdateBook(DomainBooks.Book book);

        Task<IList<DomainBooks.Book>> SearchBook(string bookName);

        Task<DomainBooks.Book> GetBookById(int bookId);

        Task<IList<DomainBooks.Book>> GetAllBooks();

    }
}
