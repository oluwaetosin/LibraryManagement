using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Query.SearchBook
{
    public class SearchBookCommandHandler : IRequestHandler<SearchBookCommand, ErrorOr<IList<DomainBooks.Book>>>
    {
        private readonly IBookRepository _bookRepository;

        public SearchBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public  async Task<ErrorOr<IList<DomainBooks.Book>>> Handle(SearchBookCommand request, CancellationToken cancellationToken)
        {
            IList<DomainBooks.Book> result =   await _bookRepository.SearchBook(request.Name);

            if (result == null || result.Count == 0) {
                return Error.NotFound();
            }

            return result.ToList();
        }
    }
}
