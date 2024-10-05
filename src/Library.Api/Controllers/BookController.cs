using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] NewBook model)
        {
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book model)
        {
            return Ok(model);
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok();
        }


        [HttpGet("{id}", Name = "GetBookById")]
        public IActionResult GetBookById(int id)
        {
            return Ok(id);
        }

        [HttpGet("search")]
        public IActionResult SearchBook([FromQuery] SearchBookRequest model)
        {
            return Ok(model);
        }

        [HttpPost("{id}/reserve")]
        public IActionResult ReserveBook([FromQuery] ReserveBookRequest model)
        {
            return Ok(model);
        }

        [HttpGet("{id}/borrow")]
        public IActionResult ReserveBook([FromQuery] BorrowBookRequest model)
        {
            return Ok(model);
        }

        [HttpGet("{id}/request-notifification")]
        public IActionResult ReserveBook([FromQuery] RequestNotificationRequest model)
        {
            return Ok(model);
        }
    }
}
