using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Book.Query.SearchBook
{
    public class SearchBookCommandHandler : IRequestHandler<SearchBookCommand, int>
    {
        public Task<int> Handle(SearchBookCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Random().Next(1, 300));
        }
    }
}
