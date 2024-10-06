using ErrorOr;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Query.GetBookById
{
    public record GetBookByIdCommand(
        int bookId    
    ): IRequest<ErrorOr<DomainBooks.Book>>;
     
}
