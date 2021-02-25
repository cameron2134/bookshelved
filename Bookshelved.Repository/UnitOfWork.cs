using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly BookshelfContext _context;
        private Repository<Book> _bookRepo;
        private Repository<Series> _seriesRepo;

        public Repository<Book> BookRepo {
            get {
                if (_bookRepo == null)
                    _bookRepo = new Repository<Book>(_context);

                return _bookRepo;
            }
        }

        public Repository<Series> SeriesRepo {
            get {
                if (_seriesRepo == null)
                    _seriesRepo = new Repository<Series>(_context);

                return _seriesRepo;
            }
        }

        public UnitOfWork(BookshelfContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
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