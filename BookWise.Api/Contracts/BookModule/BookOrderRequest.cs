using BookWise.Domain.Common;

namespace BookWise.Api.Contracts.BookModule
{
    public class BookOrderRequest
    {
        public Guid BookId { get; set; }
        public string UserId { get; set; }
        public DateTime? ReserveDate { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
