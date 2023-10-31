using Domain.Common;

namespace BookWise.Domain.Entities.Book
{
    public class Book : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public byte RecordStatus { get; set; }
        public DateTime createdAt { get; set; }

    }
}
