using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.Interfaces.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Repository.Repositories
{
    public class BookRepository : Repository<BookshelfContext, Book>, IBookRepository
    {
        public BookRepository(BookshelfContext context) : base(context)
        {
        }

        public Task<Book> GetBookDetails(int id)
        {
            return _dbSet
                .Include(o => o.Author)
                .Include(o => o.Series)
                .FirstOrDefaultAsync(o => o.ID == id);
        }
    }
}