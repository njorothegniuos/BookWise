using BookWise.Domain.Common;
using Domain.Common;

namespace BookWise.Domain.Entities.Book
{
    public class Book : Entity
    {
        public Book(Guid id,string title, string author, string isbn,DateTime publicationDate,
            RecordStatus recordStatus) : base(id)
        {
            
        }
        public Book() { }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
