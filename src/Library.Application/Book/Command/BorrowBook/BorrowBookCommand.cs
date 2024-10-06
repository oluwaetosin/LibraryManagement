using ErrorOr;
using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public record BorrowBookCommand(
    int bookId,
    int userId
    ): IRequest<ErrorOr<bool>>;
}
