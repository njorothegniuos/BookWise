namespace BookWise.Application.Book.Queries
{
    public sealed record BookResponse(string Id, string Title, string Author, string ISBN, DateTime PublicationDate);
}
