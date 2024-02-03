using BooksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyBooksManager.Domain.Entities;
using System.Reflection;

namespace BooksManager.Infra.Persistence
{
    public class BooksManagerDbContext : DbContext
    {
        public BooksManagerDbContext(DbContextOptions<BooksManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
