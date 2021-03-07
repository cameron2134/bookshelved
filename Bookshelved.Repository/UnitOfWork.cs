using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.Interfaces.Repos;
using Bookshelved.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookshelved.Core.DomainModels.Account;

namespace Bookshelved.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BookshelfContext _context;
        private IDictionary<string, object> _repos;

        public UnitOfWork(BookshelfContext context)
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

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repos == null)
                _repos = new Dictionary<string, object>
                {
                    // ToDo: We need to fix this, figure out what the generic repo should be
                    { typeof(ReadingList).Name, new Repository<BookshelfContext,TEntity>(_context) },
                    { typeof(Book).Name, new BookRepository(_context) }
                };

            IRepository<TEntity> repository = (IRepository<TEntity>)_repos[typeof(TEntity).Name];
            return repository;
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