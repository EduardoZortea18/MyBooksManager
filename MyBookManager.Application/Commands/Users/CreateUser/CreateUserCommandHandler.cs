using MediatR;
using MyBooksManager.Domain.Entities;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUsersRepository _repository;

        public CreateUserCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User(command.Name, command.Email);
            await _repository.Create(user);

            return user.Id;
        }
    }
}
