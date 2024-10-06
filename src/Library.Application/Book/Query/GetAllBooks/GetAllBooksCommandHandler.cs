using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Query.GetAllBooks
{

    public class GetAllBooksCommandHandler : IRequestHandler<GetAllBooksCommand, ErrorOr<IList<DomainBooks.Book>>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<IList<DomainBooks.Book>>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            var books =  await _bookRepository.GetAllBooks();

            if(books == null || books.Count == 0) {
                return Error.NotFound();
            }
            return books.ToList();
        }
    }
}
