using System.Collections.Generic;

namespace Bookshelved.Core.DomainModels.Book
{
    public class Author
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}