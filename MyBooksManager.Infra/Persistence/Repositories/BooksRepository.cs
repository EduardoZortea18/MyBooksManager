using BooksManager.Domain.Entities;
using BooksManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Infra.Persistence.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksManagerDbContext _context;

        public BooksRepository(BooksManagerDbContext context)
        {
            _context = context;
        }

        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await SaveChangesAsync();
        }

        public async Task<Book> Get(int id)
            => await _context.Books.Include(x => x.Loans).FirstOrDefaultAsync(x => x.Id == id && x.Active);

        public async Task<List<Book>> GetAll()
            => await _context.Books.Include(x => x.Loans).Where(x => x.Active).ToListAsync();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
