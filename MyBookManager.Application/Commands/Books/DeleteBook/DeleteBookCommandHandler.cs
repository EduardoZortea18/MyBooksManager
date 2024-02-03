using MediatR;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBooksRepository _repository;
        public DeleteBookCommandHandler(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _repository.Get(command.Id);

            if (book == null)
            {
                throw new ArgumentNullException("There's no book with the provided id.");
            }

            book.Delete();

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
