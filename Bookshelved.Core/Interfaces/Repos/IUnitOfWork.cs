using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bookshelved.Core.Interfaces.Repos
{
    public interface IUnitOfWork<out TContext>
        where TContext : DbContext
    {
        Task BeginTransaction();

        Task CommitTransaction();

        Task RollbackTransaction();

        Task Save();

        IRepository GetRepository<T>() where T : class;
    }
}