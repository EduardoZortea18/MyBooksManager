using MediatR;
using MyBooksManager.Application.Models.Responses.Books;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Queries.Books.GetBook
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookResponseModel>
    {
        private readonly IBooksRepository _repository;

        public GetBookQueryHandler(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookResponseModel> Handle(GetBookQuery query, CancellationToken cancellationToken)
        {
            var response = await _repository.Get(query.Id) ?? default;

            if (response == null) return null;

            return new BookResponseModel(
                response.Id, response.Title, response.Author, response.Isbn, response.PublicationDate);
        }
    }
}
