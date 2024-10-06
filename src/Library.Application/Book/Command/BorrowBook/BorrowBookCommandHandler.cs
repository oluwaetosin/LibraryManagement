using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, int>
    {
        public Task<int> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
