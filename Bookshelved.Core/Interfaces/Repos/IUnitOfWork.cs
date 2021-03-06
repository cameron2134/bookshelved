﻿using System.Threading.Tasks;

namespace Bookshelved.Core.Interfaces.Repos
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();

        Task CommitTransaction();

        Task RollbackTransaction();

        Task Save();

        IRepository<T> GetRepository<T>() where T : class;
    }
}