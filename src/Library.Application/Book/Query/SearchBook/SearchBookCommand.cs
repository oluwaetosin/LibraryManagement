using ErrorOr;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Query.SearchBook
{
    public record SearchBookCommand(string Name) : IRequest<ErrorOr<IList<DomainBooks.Book>>>;
   
}
