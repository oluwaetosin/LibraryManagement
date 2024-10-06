using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public record RequestNotificationCommand(
    int bookId,
    int userId
    ): IRequest<int>;
}
