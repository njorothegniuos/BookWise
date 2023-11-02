using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.BookModule;
using Microsoft.EntityFrameworkCore;

namespace BookWise.Infrastructure.Repositories
{
    public class BookOrderRepository : IBookOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookOrderRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Insert(BookOrder bookOrder) => _dbContext.Set<BookOrder>().Add(bookOrder);

        public async Task<List<BookOrder>> ListBookOrders()
        {
                var records = await _dbContext.BookOrders.ToListAsync();
                return records;
        }
    }
}
