using MyBooksManager.Domain.Entities;

namespace MyBooksManager.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task Create(User user);
        Task<User> Get(int id);
        Task SaveChangesAsync();
    }
}
