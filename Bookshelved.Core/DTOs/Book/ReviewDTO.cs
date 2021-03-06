using Bookshelved.Core.DTOs.Account;

namespace Bookshelved.Core.DTOs.Book
{
    public class ReviewDTO
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int BookID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public ApplicationUserDTO User { get; set; }
    }
}