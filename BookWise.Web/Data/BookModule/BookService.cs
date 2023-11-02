namespace BookWise.Web.Data.BookModule
{
    public class BookService
    {
        private static readonly string[] books = new[]
        {
        "The river between", "The river and the source", "Kifo kisimani", "Becoming CEO", "Power", "Warm", "Emotional intelligence in AI", "Embedded finance", "Generative AI", "AI and the future of employment"
    };

        public Task<Book[]> GetBookstAsync()
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Book
            {
                Title = books[Random.Shared.Next(books.Length)],
                Author = "Ngugi wa Thiongo",
                PublicationDate = DateTime.Now.AddDays(-index),
                Isbn = Random.Shared.Next(-20, 55).ToString()           
            }).ToArray());
        }
    }
}
