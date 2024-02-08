using MyBooksManager.Domain.Entities;

namespace MyBooksManager.Domain.Repositories
{
    public interface ILoansRepository
    {
        Task Create(Loan loan);
        Task<Loan> Get(int id);
        Task<Loan> Update(Loan loan);
        Task SaveChangesAsync();
    }
}
