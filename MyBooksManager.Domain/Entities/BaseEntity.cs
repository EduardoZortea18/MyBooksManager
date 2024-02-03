namespace BooksManager.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; protected set; }
        public bool Active { get; private set; } = true;

        public void Delete()
        {
            Active = false;
        }
    }
}
