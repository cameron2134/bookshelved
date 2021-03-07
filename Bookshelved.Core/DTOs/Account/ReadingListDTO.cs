using System.Collections.Generic;
using Bookshelved.Core.DTOs.Book;

namespace Bookshelved.Core.DTOs.Account
{
    public class ReadingListDTO
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookDTO> Books { get; set; }
    }
}