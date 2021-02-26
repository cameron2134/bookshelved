using Bookshelved.Core.DomainModels.Book;
using System.Threading.Tasks;

namespace Bookshelved.Core.Interfaces.Repos
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookDetails(int id);
    }
}