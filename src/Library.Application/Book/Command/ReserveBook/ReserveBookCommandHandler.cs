using ErrorOr;
using Library.Application.Common.Interfaces;
using Library.Domain.Books;
using MediatR;
using System.Net;

namespace Library.Application.Book.Command.ReserveBook
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookCommand, ErrorOr<int>>
    {
        private readonly IBookRepository _bookRepository;

        public ReserveBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ErrorOr<int>> Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
            var bookIsAvailable = await _bookRepository.BookIsAvailable(request.bookId);

            if (bookIsAvailable == true)
            {
                var reservation = new BookReservation
                {
                    BookID = request.bookId,
                    UserID = request.userId
                };


                await _bookRepository.ReserveBook(reservation);

                return reservation.ReservationID; ;


            }

            return Error.Failure("General.Failure", "Book is not available");
         
        }
    }
}
