using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookCommand, int>
    {
        public Task<int> Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
