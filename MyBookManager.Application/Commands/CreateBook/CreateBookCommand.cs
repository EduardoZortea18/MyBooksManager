using BooksManager.Domain.Entities;
using MediatR;

namespace MyBooksManager.Application.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int PublicationDate { get; set; }
    }
}
