using BookWise.Domain.Entities.BookModule;

namespace BookWise.Domain.Abstractions
{
    public interface IBookRepository
    {
        void Insert(Book book);
    }
}
