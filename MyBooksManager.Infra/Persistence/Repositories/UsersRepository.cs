using BooksManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using MyBooksManager.Domain.Entities;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Infra.Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BooksManagerDbContext _context;

        public UsersRepository(BooksManagerDbContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChangesAsync();
        }

        public async Task<User> Get(int id)
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Active);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
