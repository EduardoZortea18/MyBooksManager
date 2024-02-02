using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBooksManager.Application.Commands.CreateBook;

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
            var result = await _mediator.Send(command);
            return CreatedAtAction(string.Empty, result, command);
        }
    }
}
