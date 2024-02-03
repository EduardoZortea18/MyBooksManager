using FluentValidation;
using MyBooksManager.Application.Commands.Users.CreateUser;

namespace MyBooksManager.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Length(1, 50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .Length(1, 50)
                .EmailAddress();
        }
    }
}
