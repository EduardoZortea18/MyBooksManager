using MediatR;

namespace MyBooksManager.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
