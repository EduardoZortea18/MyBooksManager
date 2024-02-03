using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBooksManager.Application.Commands.Books.CreateBook;
using MyBooksManager.Application.Commands.Books.DeleteBook;
using MyBooksManager.Application.Queries.Books.GetAllBooks;
using MyBooksManager.Application.Queries.Books.GetBook;

namespace MyBooksManager.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.SelectMany(x => x.Value!.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBook), new { Id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetBookQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
            => Ok(await _mediator.Send(new GetAllBooksQuery()));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
