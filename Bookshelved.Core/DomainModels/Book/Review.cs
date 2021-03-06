using Bookshelved.Core.DomainModels.Account;

namespace Bookshelved.Core.DomainModels.Book
{
    public class BookReview
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public int BookID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}