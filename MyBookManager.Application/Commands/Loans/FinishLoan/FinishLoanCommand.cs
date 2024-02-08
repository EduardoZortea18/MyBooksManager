using MediatR;
using MyBooksManager.Application.Models.Errors;
using MyBooksManager.Application.Models.Responses.Loans;

namespace MyBooksManager.Application.Commands.Loans.FinishLoan
{
    public class FinishLoanCommand : IRequest<Result<LoanResponseModel>>
    {
        public int Id { get; private set; }

        public FinishLoanCommand(int id)
        {
            Id = id;
        }
    }
}
