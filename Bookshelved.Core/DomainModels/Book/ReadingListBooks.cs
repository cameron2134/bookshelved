using System.Collections.Generic;
using Bookshelved.Core.DomainModels.Account;

namespace Bookshelved.Core.DomainModels.Book
{
    public class ReadingListBooks
    {
        public int ID { get; set; }
        public int ReadingListID { get; set; }
        public int BookID { get; set; }

        public Book Book { get; set; }
        public ReadingList ReadingList { get; set; }
    }
}