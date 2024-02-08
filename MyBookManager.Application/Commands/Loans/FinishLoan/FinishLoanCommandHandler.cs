using MediatR;
using MyBooksManager.Application.Models.Errors;
using MyBooksManager.Application.Models.Responses.Loans;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Commands.Loans.FinishLoan
{
    public class FinishLoanCommandHandler : IRequestHandler<FinishLoanCommand, Result<LoanResponseModel>>
    {
        private readonly ILoansRepository _repository;

        public FinishLoanCommandHandler(ILoansRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<LoanResponseModel>> Handle(FinishLoanCommand command, CancellationToken cancellationToken)
        {
            var loanToBeFinished = await _repository.Get(command.Id);

            if (loanToBeFinished == null) return null;

            loanToBeFinished.ConfirmReturn();

            if (IsLate(loanToBeFinished.ExpectedReturnDate.Date, loanToBeFinished.ReturnDate.Date))
            {
                return new Result<LoanResponseModel>(new LoanResponseModel(), "Your loan is late", true);
            }

            var loanUpdated = await _repository.Update(loanToBeFinished);

            return new Result<LoanResponseModel>(
                new LoanResponseModel(loanUpdated.BookId, loanUpdated.UserId, loanUpdated.LoanDate, loanUpdated.ExpectedReturnDate, loanUpdated.ReturnDate),
                "You return on the expected date");
        }

        private bool IsLate(DateTime expectedDate, DateTime returnDate) => expectedDate.Date < returnDate.Date;
    }
}
