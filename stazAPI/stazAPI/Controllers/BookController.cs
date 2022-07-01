using Microsoft.AspNetCore.Mvc;
using stazServices.RestModels;
using stazServices.Services.Interfaces;

namespace stazAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBook")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            return Ok(await _bookService.GetBook(id));
        }

        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetBooks());
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(AddBookRequest request)
        {
            await _bookService.AddBook(request);
            return Ok();
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromQuery]Guid id, UpdateBookRequest request)
        {
            await _bookService.UpdateBook(id, request);
            return Ok();
        }

        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await _bookService.RemoveBook(id);
            return NoContent();
        }
    }
}
