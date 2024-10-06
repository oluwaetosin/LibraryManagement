using MediatR;

namespace Library.Application.Book.Query.GetBookById
{
    public record GetBookByIdCommand(
        int bookId    
    ): IRequest<int>;
     
}
