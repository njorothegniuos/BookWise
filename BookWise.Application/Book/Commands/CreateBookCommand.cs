using Application.Abstractions.Messaging;

namespace BookWise.Application.Book.Commands
{
    public sealed record CreateBookCommand(string Title, string Author, string Isbn, DateTime PublicationDate) : ICommand<Guid>;
}
