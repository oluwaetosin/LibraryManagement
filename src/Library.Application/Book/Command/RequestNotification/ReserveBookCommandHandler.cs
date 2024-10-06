using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Books;
using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public class RequestNotificationCommandHandler : IRequestHandler<RequestNotificationCommand, ErrorOr<bool>>
    {
        private readonly IBookRepository _bookRepository;

        public RequestNotificationCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<bool>> Handle(RequestNotificationCommand request, CancellationToken cancellationToken)
        {


            await _bookRepository.QueueNotification(request.userId, request.bookId);

            return true;
        }
    }
}
