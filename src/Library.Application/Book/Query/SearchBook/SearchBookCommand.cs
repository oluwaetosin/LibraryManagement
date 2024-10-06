using MediatR;

namespace Library.Application.Book.Query.SearchBook
{
    public record SearchBookCommand(string Name) : IRequest<int>;
   
}
