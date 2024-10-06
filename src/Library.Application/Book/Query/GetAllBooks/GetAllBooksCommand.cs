using ErrorOr;
using MediatR;
using DomainBooks = Library.Domain.Books;


namespace Library.Application.Book.Query.GetAllBooks
{
    public record GetAllBooksCommand(): IRequest<ErrorOr<IList<DomainBooks.Book>>>;
    
}
