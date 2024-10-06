using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Books;
using MediatR;

namespace Library.Application.Book.Command.ReserveBook
{
    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, ErrorOr<bool>>
    {
        private readonly IBookRepository _bookRepository;

        public BorrowBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<bool>> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var bookIsAvailable = await _bookRepository.BookIsAvailable(request.bookId);

            if (bookIsAvailable == true)
            {
                var bookBorrw = new BookBorrow
                {
                    BookID = request.bookId,
                    UserID = request.userId
                };


                await _bookRepository.BorrowBook(bookBorrw);

                return true; 


            }

            return Error.Failure("General.Failure", "Book is not available");
        }
    }
}
