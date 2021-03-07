using System;

namespace Bookshelved.Core.DTOs.Book
{
    public class BookProgressDTO
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string UserID { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
        public int? CurrentPage { get; set; }
    }
}