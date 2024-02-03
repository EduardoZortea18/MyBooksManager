using MediatR;
using MyBooksManager.Application.Models.Responses.Books;

namespace MyBooksManager.Application.Queries.Books.GetAllBooks
{
    public record GetAllBooksQuery : IRequest<List<BookResponseModel>>
    {
    }
}
