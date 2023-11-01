using Application.Abstractions.Messaging;

namespace BookWise.Application.Book.Queries
{
    public sealed record SearchForABookQuery(string Value) : IQuery<BooksResponse>;
}
