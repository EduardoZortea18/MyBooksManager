using MediatR;
using MyBooksManager.Application.Models.Responses.Books;

namespace MyBooksManager.Application.Queries.Books.GetBook
{
    public record GetBookQuery : IRequest<BookResponseModel>
    {
        public int Id { get; init; }

        public GetBookQuery(int id)
        {
            Id = id;
        }
    }
}
