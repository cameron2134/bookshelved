using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Core.DTOs.Book
{
    public class AuthorDTO
    {
        public int ID { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
    }
}