using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Jh.Abp.Domain
{
    public interface ICrudRepository<TEntity, TKey> : IRepository<TEntity, TKey>
         where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        Task<List<TEntity>> GetListAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default);
        Task<long> GetCountAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default);
        Task<IQueryable<TEntity>> GetTrackingAsync(IQueryable<TEntity> query,bool isTracking);

       /// <summary>
       /// 创建一条数据
       /// </summary>
       Task<TEntity> CreateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 创建多条数据
        /// </summary>
        Task<TEntity[]> CreateAsync(TEntity[] entitys, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据条件删除
        /// </summary>
        Task<TEntity[]> DeleteListAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据条件删除
        /// </summary>
        Task<TEntity[]> DeleteEntitysAsync(IQueryable<TEntity> query, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 获取Queryable
        /// </summary>
        Task<IQueryable<TEntity>> GetQueryableAsync(bool inApplyDataFilters, bool includeDetails = false);

        /// <summary>
        /// 获取指定实体的DbSet集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IQueryable<T>> GetQueryableAsync<T>() where T : class;

        /// <summary>
        /// 删除(支持硬删除)
        /// </summary>
        /// <param name="autoSave"></param>
        /// <param name="isHard"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<TEntity[]> DeleteAsync(bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken), params TEntity[] entitys);

        /// <summary>
        /// 数据上下文保存更改
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ContextSaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class;
    }
}
