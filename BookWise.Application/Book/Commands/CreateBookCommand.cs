using Application.Abstractions.Messaging;
using BookWise.Domain.Common;

namespace BookWise.Application.Book.Commands
{
    public sealed record CreateBookCommand(string Title, string Author, string ISBN, DateTime PublicationDate, RecordStatus RecordStatus) : ICommand<Guid>;
}
