using Library.Contracts.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] NewBookRequest model)
        {
            return Ok(model);
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
        public IActionResult Update(int id, [FromBody] UpdateBookRequest model)
        {
            return Ok(model);
        }

        /// <summary>
        /// List all books
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok();
        }


        /// <summary>
        /// Get Book By Id
        /// </summary>
        /// <param name="id">Id of book</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBookById")]
        public IActionResult GetBookById(int id)
        {
            return Ok(id);

            
        }
        /// <summary>
        /// Search book by name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public IActionResult SearchBook([FromQuery] SearchBookRequest model)
        {
            return Ok(model);
        }

        /// <summary>
        /// Reserve a Book for 48hrs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{id}/reserve")]
        public IActionResult ReserveBook([FromQuery] ReserveBookRequest model)
        {
            return Ok(model);
        }

        /// <summary>
        /// Borrow a book for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("{id}/borrow")]
        public IActionResult BorrowBook([FromQuery] BorrowBookRequest model)
        {
            return Ok(model);
        }

        /// <summary>
        /// Subscribe to a book availability notification
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("{id}/request-notifification")]
        public IActionResult ReserveBook([FromQuery] RequestNotificationRequest model)
        {
            return Ok(model);
        }
    }
}
