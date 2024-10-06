using MediatR;

namespace Library.Application.Book.Command.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        public Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
