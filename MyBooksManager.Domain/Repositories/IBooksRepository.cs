using BooksManager.Domain.Entities;

namespace MyBooksManager.Domain.Repositories
{
    public interface IBooksRepository
    {
        Task Create(Book book);
        Task<Book> Get(int id);
        Task<List<Book>> GetAll();
    }
}
