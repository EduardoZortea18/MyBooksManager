using BooksManager.Domain.Entities;
using MediatR;

namespace MyBooksManager.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Book());
        }
    }
}
