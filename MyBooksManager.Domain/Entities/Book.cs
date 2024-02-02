namespace BooksManager.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public int PublicationDate { get; private set; }
    }
}
