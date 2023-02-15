using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Northwind
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// DbContext
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// Saves the change
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangeAsync();

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
