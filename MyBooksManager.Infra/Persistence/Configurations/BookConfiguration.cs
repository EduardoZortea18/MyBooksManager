using BooksManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksManager.Infra.Persistence.Configurations
{
    public class BookConfiguration : BaseConfiguration<Book>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Isbn)
               .IsRequired()
               .HasMaxLength(13);

            builder.HasIndex(x => x.Isbn)
                .IsUnique();

            builder.Property(x => x.PublicationDate)
               .IsRequired()
               .HasMaxLength(10);
        }
    }
}
