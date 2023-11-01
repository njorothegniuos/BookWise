using BookWise.Domain.Entities.BookModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWise.Infrastructure.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(product => product.Id);
            builder.Property(product => product.Title).HasMaxLength(150).IsRequired();
            builder.Property(product => product.Author).HasMaxLength(150).IsRequired();
            builder.Property(product => product.ISBN).HasMaxLength(150).IsRequired();

        }
    }
}
