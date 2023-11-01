using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.BookModule;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Insert(Book book) => _dbContext.Set<Book>().Add(book);

        public async Task<Book> SearchForABook(string value)
        {
            var records = await _dbContext.Books.FirstOrDefaultAsync(e => e.Title == value);
            return records;
        }

    }
}
