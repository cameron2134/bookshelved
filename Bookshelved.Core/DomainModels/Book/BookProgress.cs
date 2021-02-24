using System;

namespace Bookshelved.Core.DomainModels.Book
{
    public class BookProgress
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateFinished { get; set; }
        public int? CurrentPage { get; set; }

        public virtual Book Book { get; set; }
    }
}