using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Northwind
{
    /// <summary>
    /// A Generic Repository Interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 取得全部
        /// </summary>
        /// <returns></returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// 取得單筆
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 新增多筆
        /// </summary>
        /// <param name="instance"></param>
        void AddRange(IEnumerable<TEntity> instance);

        /// <summary>
        /// 更新多筆
        /// </summary>
        /// <param name="instance"></param>
        void UpdateRange(IEnumerable<TEntity> instance);

        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="instance"></param>
        void DeleteRange(IEnumerable<TEntity> instance);
    }
}
