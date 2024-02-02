namespace MyBooksManager.Application.Models.Response
{
    public class BookResponseModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public int PublicationDate { get; private set; }

        public BookResponseModel(int id, string title, string author, string isbn, int publicationDate)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            PublicationDate = publicationDate;
        }
    }
}
