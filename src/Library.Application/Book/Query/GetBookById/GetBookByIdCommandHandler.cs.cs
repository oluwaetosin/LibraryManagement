using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Query.GetBookById
{
    public class GetBookByIdCommandHandler : IRequestHandler<GetBookByIdCommand, ErrorOr<DomainBooks.Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ErrorOr<DomainBooks.Book>> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.bookId);

            if(book == null)
            {
                return Error.NotFound();
            }
            return book;

        }
    }
}
