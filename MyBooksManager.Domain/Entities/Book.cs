using MyBooksManager.Domain.Entities;

namespace BooksManager.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public int PublicationDate { get; private set; }
        public List<Loan> Loans { get; private set; }

        public Book(string title, string author, string isbn, int publicationDate)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            PublicationDate = publicationDate;
        }
    }
}
