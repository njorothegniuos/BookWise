using BookWise.Domain.Entities.BookModule;

namespace BookWise.Domain.Abstractions
{
    public interface IBookOrderRepository
    {
        void Insert(BookOrder BookOrder);
        Task<List<BookOrder>> ListBookOrders();
    }
}
