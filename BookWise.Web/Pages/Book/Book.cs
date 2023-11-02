using System.ComponentModel.DataAnnotations;

namespace BookWise.Web.Data.BookModule
{
    public class Book
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
