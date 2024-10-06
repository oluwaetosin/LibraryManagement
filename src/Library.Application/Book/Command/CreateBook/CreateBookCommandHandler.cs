using MediatR;

namespace Library.Application.Book.Command.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
