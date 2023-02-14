using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
        protected DbContext _context
        {
            get; set;
        }

        public GenericRepository(DbContext context)
        {
            if(context == null)
            {
                throw new ArgumentNullException("context");
            }

            this._context = context;
        }

        public void Add(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("instance");
            }

            _context.Set<TEntity>().Add(entity);
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this._context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this._context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this._context.Entry(entity).State = EntityState.Modified;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if(entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            this._context.Set<TEntity>().AddRange(entities);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            this._context.Set<TEntity>().UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("instance");
            }

            this._context.Entry(entity).State = EntityState.Deleted;
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            this._context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
