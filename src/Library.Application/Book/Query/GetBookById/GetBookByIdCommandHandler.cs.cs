using MediatR;

namespace Library.Application.Book.Query.GetBookById
{
    public class GetBookByIdCommandHandler : IRequestHandler<GetBookByIdCommand, int>
    {
        public Task<int> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
