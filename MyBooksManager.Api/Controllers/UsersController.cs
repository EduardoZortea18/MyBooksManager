using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBooksManager.Application.Commands.Users.CreateUser;
using MyBooksManager.Application.Queries.Users.GetUser;

namespace MyBooksManager.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.SelectMany(x => x.Value!.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new { Id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetUserQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
