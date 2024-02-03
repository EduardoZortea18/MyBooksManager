using MediatR;
using MyBooksManager.Application.Models.Responses.Users;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponseModel>
    {
        private readonly IUsersRepository _repository;

        public GetUserQueryHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var response = await _repository.Get(query.Id) ?? default;

            if (response == null) return null;

            return new UserResponseModel(response.Name, response.Email);
        }
    }
}
