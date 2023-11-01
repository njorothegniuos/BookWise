using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.BookModule;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookOrder> BookOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
