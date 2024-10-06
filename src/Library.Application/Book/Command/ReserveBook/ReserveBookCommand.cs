using ErrorOr;
using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public record ReserveBookCommand(
    int bookId,
    int userId
    ): IRequest<ErrorOr<int>>;
}
