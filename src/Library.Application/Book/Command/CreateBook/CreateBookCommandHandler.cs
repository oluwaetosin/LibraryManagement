using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Command.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ErrorOr<DomainBooks.Book>>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<DomainBooks.Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new DomainBooks.Book
            {
                Title = request.Title,
                Author = request.Author,
                Category = request.Category,
                CopiesAvailable = request.CopiesAvailable,
                Edition = request.Edition,
                ISBN = request.ISBN,
                Language = request.Language,
                Location = request.Location,
                Pages = request.Pages,
                PublicationYear = request.PublicationYear,
                Publisher = request.Publisher

            };

            _bookRepository.CreateBook(book);

            return book;
        }
    }
}
