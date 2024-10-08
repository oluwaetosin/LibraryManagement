﻿using Library.Api.Filters;
using Library.Application.Book.Command.CreateBook;
using Library.Application.Book.Command.ReserveBook;
using Library.Application.Book.Command.UpdateBook;
using Library.Application.Book.Query.GetAllBooks;
using Library.Application.Book.Query.GetBookById;
using Library.Application.Book.Query.SearchBook;
using Library.Application.User.Query;
using Library.Contracts.Books;
using Library.Domain.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeUser]
    public class BookController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookController(ISender mediator,IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator; 
            _httpContextAccessor = httpContextAccessor;
            
        }
        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Book), 201)]
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
                model.Location,
                model.Copies
                );

            var book = await _mediator.Send( command );

            

            return CreatedAtRoute("GetBookById", routeValues: new { id = book.Value.BookID }, value: book.Value);

          
        }

        /// <summary>
        /// Update a book record
        /// </summary>
        /// <param name="id">Book id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] UpdateBookRequest model)
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
                model.Location,
                model.Copies);

            var book = await _mediator.Send(command);

            if (book.IsError)
            {
                return Problem("Unexpected Error Occured");
            }

            return Ok(book);
        }

        /// <summary>
        /// List all books
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType( typeof(Book), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<ActionResult<Book>> GetAllBooks()
        {
            var command = new GetAllBooksCommand();

            var result = await _mediator.Send(command);

            if (result.IsError)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }


        /// <summary>
        /// Get Book By Id
        /// </summary>
        /// <param name="id">Id of book</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdCommand(id));

            if (result.IsError)
            {
                return NotFound();
            }

            return Ok(result.Value);

        }
        /// <summary>
        /// Search book by name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<ActionResult<IList<Book>>> SearchBook([FromQuery] SearchBookRequest model)
        {
            var result = await _mediator.Send(new SearchBookCommand(model.Name));

            if (result.IsError)
            {
                return NotFound();
            }
            return Ok(result.Value);
            
        }

        /// <summary>
        /// Reserve a Book for 48hrs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{bookid}/reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] ReserveBookRequest model)
        {
            object userEmail;
            _httpContextAccessor.HttpContext.Items.TryGetValue("User", out userEmail);
            var user = await _mediator.Send(new GetUserByEmailCommand(userEmail.ToString()));
           
            var result = await _mediator.Send(new ReserveBookCommand(model.BookId, user.Value.UserId));

            if(result.IsError)
            {
                return Problem(result.FirstError.Description);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Borrow a book for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowBookRequest model)
        {
            object userEmail;
            _httpContextAccessor.HttpContext.Items.TryGetValue("User", out userEmail);
            var user = await _mediator.Send(new GetUserByEmailCommand(userEmail.ToString()));

            var result = await _mediator.Send(new BorrowBookCommand(model.BookId, user.Value.UserId));
            return Ok(result);
        }

        /// <summary>
        /// Borrow a book for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/return")]
        public async Task<IActionResult> ReturnBook([FromBody] BorrowBookRequest model)
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
            object userEmail;
            _httpContextAccessor.HttpContext.Items.TryGetValue("User", out userEmail);
            var user = await _mediator.Send(new GetUserByEmailCommand(userEmail.ToString()));

            var result = await _mediator.Send(new RequestNotificationCommand(model.BookId, user.Value.UserId));
            return Ok(result);
        }

    }
}
