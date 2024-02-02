using BooksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BooksManager.Infra.Persistence
{
    public class BooksManagerDbContext : DbContext
    {
        public BooksManagerDbContext(DbContextOptions<BooksManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
