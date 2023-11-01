using BookWise.Domain.Entities.BookModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookWise.Infrastructure.Configurations
{
    internal class BookOrderConfiguration : IEntityTypeConfiguration<BookOrder>
    {
        public void Configure(EntityTypeBuilder<BookOrder> builder)
        {
            builder.ToTable("BookOrders");

            builder.HasKey(product => product.Id);
            builder.Property(product => product.UserId).IsRequired();
            builder.Property(product => product.BookId).IsRequired();
        }
    }
}
