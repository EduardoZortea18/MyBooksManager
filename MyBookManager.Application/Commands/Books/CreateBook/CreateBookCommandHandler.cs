using BooksManager.Domain.Entities;
using MediatR;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Commands.Books.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBooksRepository _repository;

        public CreateBookCommandHandler(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book(command.Title, command.Author, command.Isbn, command.PublicationDate);
            await _repository.Create(book);

            return book.Id;
        }
    }
}
