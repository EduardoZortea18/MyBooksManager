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
            await _context.SaveChangesAsync();
        }

        public async Task<Book> Get(int id)
            => await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Book>> GetAll()
            => await _context.Books.ToListAsync();
    }
}
