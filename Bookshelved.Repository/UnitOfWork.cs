using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.Interfaces.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
        where TContext : DbContext
    {
        private readonly TContext _context;
        private IDictionary<Type, object> _repos;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public Task BeginTransaction()
        {
            return _context.Database.BeginTransactionAsync();
        }

        public Task CommitTransaction()
        {
            return _context.Database.CommitTransactionAsync();
        }

        public Task RollbackTransaction()
        {
            return _context.Database.RollbackTransactionAsync();
        }

        public IRepository GetRepository<T>() where T : class
        {
            if (_repos == null)
                _repos = new Dictionary<Type, object>();

            var type = typeof(T);
            if (!_repos.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repos.Add(type, repositoryInstance);
            }

            return (IRepository)_repos[type];
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}