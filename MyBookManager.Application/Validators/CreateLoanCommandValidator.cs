using FluentValidation;
using MyBooksManager.Domain.Entities;

namespace MyBooksManager.Application.Validators
{
    public class CreateLoanCommandValidator : AbstractValidator<Loan>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("Book Id can't be empty.")
                .NotNull().WithMessage("Book Id can't be null.");

            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("User Id can't be empty.")
               .NotNull().WithMessage("User Id can't be null.");
        }
    }
}
