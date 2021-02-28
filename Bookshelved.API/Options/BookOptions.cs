namespace Bookshelved.API.Options
{
    public class BookOptions : PagingOptions
    {
        public int? AuthorID { get; set; }
        public int? SeriesID { get; set; }
    }
}