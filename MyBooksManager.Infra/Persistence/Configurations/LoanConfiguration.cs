using BooksManager.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooksManager.Domain.Entities;

namespace MyBooksManager.Infra.Persistence.Configurations
{
    public class LoanConfiguration : BaseConfiguration<Loan>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasOne(x => x.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId)
                .IsRequired();

            builder
                 .HasOne(x => x.User)
                 .WithMany(u => u.Loans)
                 .HasForeignKey(l => l.UserId)
                 .IsRequired();

            builder
                .Property(x => x.LoanDate)
                .IsRequired();

            builder
                .Property(x => x.LoanDate)
                .IsRequired(false);
        }
    }
}
