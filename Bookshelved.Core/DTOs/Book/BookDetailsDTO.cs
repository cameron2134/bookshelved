namespace Bookshelved.Core.DTOs.Book
{
    public class BookDetailsDTO
    {
        public int ID { get; set; }
        public int? SeriesID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }

        public SeriesDTO Series { get; set; }
        public AuthorDTO Author { get; set; }
    }
}