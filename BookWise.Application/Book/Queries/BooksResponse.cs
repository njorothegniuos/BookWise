namespace BookWise.Application.Book.Queries
{
    public sealed record BooksResponse(string Id, string Title, string Author, string ISBN, DateTime PublicationDate);
}
