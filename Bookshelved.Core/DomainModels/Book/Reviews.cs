namespace Bookshelved.Core.DomainModels.Book
{
    public class Reviews
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual Book Book { get; set; }
    }
}