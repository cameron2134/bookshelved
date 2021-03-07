using System.Collections.Generic;
using Bookshelved.Core.DomainModels.Book;

namespace Bookshelved.Core.DomainModels.Account
{
    public class ReadingList
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ReadingListBooks> BooksInList { get; set; }
    }
}