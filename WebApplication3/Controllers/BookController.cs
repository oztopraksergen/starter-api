using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Services.Abstract;
using WebApplication3.Services.Concrete;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            var result = _bookService.AddBook(book);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

    }
}
