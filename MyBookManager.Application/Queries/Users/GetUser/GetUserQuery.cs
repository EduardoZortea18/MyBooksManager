using MediatR;
using MyBooksManager.Application.Models.Responses.Users;

namespace MyBooksManager.Application.Queries.Users.GetUser
{
    public record GetUserQuery : IRequest<UserResponseModel>
    {
        public int Id { get; init; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
