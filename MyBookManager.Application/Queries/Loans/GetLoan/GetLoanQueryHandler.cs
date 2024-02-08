using MediatR;
using MyBooksManager.Application.Models.Responses.Loans;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Queries.Loans.GetLoan
{
    public class GetLoanQueryHandler : IRequestHandler<GetLoanQuery, LoanResponseModel>
    {
        private readonly ILoansRepository _repository;

        public GetLoanQueryHandler(ILoansRepository repository)
        {
            _repository = repository;
        }

        public async Task<LoanResponseModel> Handle(GetLoanQuery query, CancellationToken cancellationToken)
        {
            var response = await _repository.Get(query.Id) ?? default;

            if (response == null) return null;

            return new LoanResponseModel(response.BookId, response.UserId, response.LoanDate, response.ExpectedReturnDate, response.ReturnDate);
        }
    }
}
