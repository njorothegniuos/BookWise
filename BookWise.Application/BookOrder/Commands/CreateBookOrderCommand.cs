using Application.Abstractions.Messaging;
using BookWise.Domain.Common;

namespace BookWise.Application.BookOrder.Commands
{
    public sealed record CreateBookOrderCommand(Guid Id, Guid BookId, string UserId, DateTime? ReserveDate, DateTime? BorrowedDate, DateTime? ReturnDate, RecordStatus RecordStatus) : ICommand<Guid>;
}
