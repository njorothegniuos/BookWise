using BookWise.Domain.Common;
using Domain.Common;

namespace BookWise.Domain.Entities.BookModule
{
    public class BookOrder : Entity
    {
        public BookOrder(Guid id, Guid bookId, string userId, DateTime? reserveDate,
            DateTime? borrowedDate, DateTime? returnDate,RecordStatus recordStatus) : base(id)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            ReserveDate = reserveDate;
            BorrowedDate = borrowedDate;
            ReturnDate = returnDate;
            RecordStatus = recordStatus;
        }
        public BookOrder() { }
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string UserId { get; set; }
        public DateTime? ReserveDate { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
