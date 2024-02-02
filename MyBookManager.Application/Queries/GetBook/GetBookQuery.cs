using MediatR;
using MyBooksManager.Application.Models.Response;

namespace MyBooksManager.Application.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookResponseModel>
    {
        public int Id { get; private set; }

        public GetBookQuery(int id)
        {
            Id = id;
        }
    }
}
