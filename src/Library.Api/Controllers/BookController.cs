using Library.Application.Book.Command.CreateBook;
using Library.Application.Book.Command.ReserveBook;
using Library.Application.Book.Command.UpdateBook;
using Library.Application.Book.Query.GetAllBooks;
using Library.Application.Book.Query.GetBookById;
using Library.Application.Book.Query.SearchBook;
using Library.Contracts.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ISender _mediator;
        public BookController(ISender mediator)
        {
            _mediator = mediator;   
        }
        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] NewBookRequest model)
        {
            var command = new CreateBookCommand(
                model.Title,
                model.Author,
                model.ISBN,
                model.Publisher,
                model.PublicationYear,
                model.Category,
                model.Language,
                model.Edition,
                model.Pages,
                model.CopiesAvailable,
                model.Location
                );

            var bookId = await _mediator.Send( command );

            return CreatedAtRoute("GetBookById", routeValues: new { id = bookId }, value: bookId);

          
        }

        /// <summary>
        /// Update a book record
        /// </summary>
        /// <param name="id">Book id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequest model)
        {
            var command = new UpdateBookCommand(
                id,
                 model.Title,
                model.Author,
                model.ISBN,
                model.Publisher,
                model.PublicationYear,
                model.Category,
                model.Language,
                model.Edition,
                model.Pages,
                model.CopiesAvailable,
                model.Location);

            var bookId = await _mediator.Send(command);
            return Ok(bookId);
        }

        /// <summary>
        /// List all books
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var command = new GetAllBooksCommand();

            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Get Book By Id
        /// </summary>
        /// <param name="id">Id of book</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdCommand(id));
            return Ok(result);

            
        }
        /// <summary>
        /// Search book by name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchBook([FromQuery] SearchBookRequest model)
        {
            var result = await _mediator.Send(new SearchBookCommand(model.Name));
            return Ok(result);
            
        }

        /// <summary>
        /// Reserve a Book for 48hrs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] ReserveBookRequest model)
        {
            /// TODO get userId from token
            var result = await _mediator.Send(new ReserveBookCommand(model.BookId, 1));
            return Ok(result);
        }

        /// <summary>
        /// Borrow a book for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookRequest model)
        {
            /// TODO get userId from token
            var result = await _mediator.Send(new BorrowBookCommand(model.BookId, 1));
            return Ok(result);
        }

        /// <summary>
        /// Subscribe to a book availability notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/request-notifification")]
        public async Task<IActionResult> RequestNotification([FromBody] RequestNotificationRequest model)
        {
            var result = await _mediator.Send(new RequestNotificationCommand(model.BookId, 1));
            return Ok(result);
        }
    }
}
