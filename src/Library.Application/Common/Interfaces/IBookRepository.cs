using DomainBooks = Library.Domain.Books;

namespace Library.Application.Common.Interfaces
{
    public interface IBookRepository
    {
        Task CreateBook(DomainBooks.Book book);
        
    }
}
