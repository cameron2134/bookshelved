using System.ComponentModel.DataAnnotations;

namespace Bookshelved.Core.DTOs.Book
{
    public class BookDTO
    {
        public int ID { get; set; }
        public int? SeriesID { get; set; }

        [Required]
        public int AuthorID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}