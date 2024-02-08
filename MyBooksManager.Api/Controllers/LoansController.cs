using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBooksManager.Application.Commands.Loans.CreateLoan;
using MyBooksManager.Application.Commands.Loans.FinishLoan;
using MyBooksManager.Application.Queries.Loans.GetLoan;

namespace MyBooksManager.Api.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan(CreateLoanCommand command)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.SelectMany(x => x.Value!.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetLoan), new { Id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoan([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetLoanQuery(id));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> FinishLoan([FromRoute] int id)
        {
            var result = await _mediator.Send(new FinishLoanCommand(id));

            if (result.HasError)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }
    }
}
