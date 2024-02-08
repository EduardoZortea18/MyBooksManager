using MediatR;
using MyBooksManager.Domain.Entities;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Commands.Loans.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, int>
    {
        private readonly ILoansRepository _repository;

        public CreateLoanCommandHandler(ILoansRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateLoanCommand command, CancellationToken cancellationToken)
        {
            var loan = new Loan(command.BookId, command.UserId);
            await _repository.Create(loan);

            return loan.Id;
        }
    }
}
