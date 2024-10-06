using Library.Application.Book.Command.UpdateBook;
using MediatR;

namespace Library.Application.Book.Query.GetAllBooks
{

    public class GetAllBooksCommandHandler : IRequestHandler<GetAllBooksCommand, List<int>>
    {
        public Task<List<int>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new List<int>());
        }
    }
}
