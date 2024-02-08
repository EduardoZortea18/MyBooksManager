using MediatR;
using MyBooksManager.Application.Models.Responses.Loans;

namespace MyBooksManager.Application.Queries.Loans.GetLoan
{
    public class GetLoanQuery : IRequest<LoanResponseModel>
    {
        public int Id { get; private set; }

        public GetLoanQuery(int id)
        {
            Id = id;
        }
    }
}
