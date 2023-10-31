using BookWise.Domain.Entities.BookModule;

namespace BookWise.Domain.Abstractions
{
    public interface IBookOrderRepository
    {
        void Insert(BookOrder BookOrder);
    }
}
