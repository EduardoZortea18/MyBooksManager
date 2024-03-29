﻿using FluentValidation;
using MyBooksManager.Application.Commands.Books.CreateBook;
using System.Globalization;

namespace MyBooksManager.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Author)
                .Length(1, 50).WithMessage("Author name must contain between 1 and 50 characters.")
                .NotEmpty().WithMessage("Author can't be empty.")
                .NotNull().WithMessage("Author can't be null.");

            RuleFor(x => x.Title)
               .Length(1, 50).WithMessage("Title name must contain between 1 and 50 characters.")
               .NotEmpty().WithMessage("Title can't be empty.")
               .NotNull().WithMessage("Title can't be null.");

            RuleFor(x => x.Isbn)
               .Length(13).WithMessage("Isbn name must contain exactly 13 characters.")
               .NotEmpty().WithMessage("Isbn can't be empty.")
               .NotNull().WithMessage("Isbn can't be null.");

            RuleFor(x => x.PublicationDate)
                .Must(IsValidDateFormat).WithMessage("Invalid date format")
                .NotEmpty().WithMessage("PublicationDate can't be empty.")
                .NotNull().WithMessage("PublicationDate can't be null.");
        }

        private bool IsValidDateFormat(int date)
        {
            DateTime dateParsed;
            DateTime.TryParseExact(date.ToString(), "yyyyMMdd",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out dateParsed);
            return dateParsed != DateTime.MinValue;
        }
    }
}
