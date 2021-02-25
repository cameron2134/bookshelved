using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Core.DomainModels.Book
{
    public class Book
    {
        public int ID { get; set; }
        public int? SeriesID { get; set; }
        public int AuthorID { get; set; }
        public string Name { get; set; }

        public virtual BookProgress BookProgress { get; set; }
        public virtual Series Series { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}