using BooksManager.Infra.Persistence.Configurations;
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
        }
    }
}
