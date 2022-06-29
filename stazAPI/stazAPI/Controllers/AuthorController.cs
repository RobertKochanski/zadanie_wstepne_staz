using Microsoft.AspNetCore.Mvc;
using stazDAL.Entities;
using stazServices.RestModels;
using stazServices.Services.Interfaces;

namespace stazAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAuthorDetails")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            return Ok(await _authorService.GetAuthor(id));
        }

        [HttpGet("GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _authorService.GetAuthors());
        }

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor(AddAuthorRequest request)
        {
            await _authorService.AddAuthor(request);
            return Ok();
        }

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(Guid id, UpdateAuthorRequest request)
        {
            await _authorService.UpdateAuthor(id, request);
            return Ok();
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            await _authorService.RemoveAuthor(id);
            return NoContent();
        }
    }
}
