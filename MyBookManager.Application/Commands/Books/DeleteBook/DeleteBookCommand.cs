using MediatR;

namespace MyBooksManager.Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; private set; }
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }
}
