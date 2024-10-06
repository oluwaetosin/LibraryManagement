using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public class RequestNotificationCommandHandler : IRequestHandler<RequestNotificationCommand, int>
    {
        public Task<int> Handle(RequestNotificationCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
