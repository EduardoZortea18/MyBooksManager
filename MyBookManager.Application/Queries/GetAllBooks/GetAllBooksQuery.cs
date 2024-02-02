using MediatR;
using MyBooksManager.Application.Models.Response;

namespace MyBooksManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookResponseModel>>
    {
    }
}
