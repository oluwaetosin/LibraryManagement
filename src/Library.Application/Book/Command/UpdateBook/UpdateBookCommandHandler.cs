using ErrorOr;
using Library.Application.Common.Interfaces;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Command.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ErrorOr<DomainBooks.Book>>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<DomainBooks.Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookItem = new DomainBooks.Book
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
                Publisher = request.Publisher,
                Copies = request.Copies,
                BookID = request.BookId

            };

            var book = await _bookRepository.UpdateBook(
                bookItem
            );

            if (book == null)
            {
                return Error.Unexpected();
            }
            return book;
        }

       
    }
}
