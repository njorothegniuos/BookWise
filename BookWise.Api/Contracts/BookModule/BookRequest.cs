using System.ComponentModel.DataAnnotations;

namespace BookWise.Api.Contracts.BookModule
{
    public class BookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
    }
}
