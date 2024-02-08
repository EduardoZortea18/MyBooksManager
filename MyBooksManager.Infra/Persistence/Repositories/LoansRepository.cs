using BooksManager.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using MyBooksManager.Domain.Entities;
using MyBooksManager.Domain.Repositories;

namespace MyBooksManager.Infra.Persistence.Repositories
{
    public class LoansRepository : ILoansRepository
    {
        private readonly BooksManagerDbContext _context;

        public LoansRepository(BooksManagerDbContext context)
        {
            _context = context;
        }

        public async Task Create(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await SaveChangesAsync();
        }

        public async Task<Loan> Get(int id)
            => await _context.Loans.Include(x => x.Book).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id && x.Active);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Loan> Update(Loan loan)
        {
           _context.Loans.Update(loan);
           await SaveChangesAsync();
            return loan;
        }
    }
}
