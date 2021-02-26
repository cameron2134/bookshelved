namespace Bookshelved.Core.DTOs
{
    public class BookDTO
    {
        public int ID { get; set; }
        public int? SeriesID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }
    }
}