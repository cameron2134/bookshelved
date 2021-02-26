using System.Collections.Generic;

namespace Bookshelved.Core.DomainModels.Book
{
    public class Series
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}