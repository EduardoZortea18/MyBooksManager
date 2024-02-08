using MediatR;
using MyBooksManager.Application.Models.Responses.Books;
using MyBooksManager.Application.Models.Responses.Loans;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Queries.Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookResponseModel>>
    {
        private readonly IBooksRepository _repository;

        public GetAllBooksQueryHandler(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookResponseModel>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAll();
            return response.Select(x => new BookResponseModel(
                x.Id,
                x.Title,
                x.Author,
                x.Isbn,
                x.PublicationDate,
                x.Loans.Select(x => new LoanResponseModel(x.BookId, x.UserId, x.LoanDate, x.ExpectedReturnDate, x.ReturnDate)).ToList())).ToList();
        }
    }
}
