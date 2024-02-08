using BooksManager.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBooksManager.Domain.Entities;

namespace MyBooksManager.Infra.Persistence.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                 .HasMany(x => x.Loans)
                 .WithOne(l => l.User)
                 .HasForeignKey(l => l.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
