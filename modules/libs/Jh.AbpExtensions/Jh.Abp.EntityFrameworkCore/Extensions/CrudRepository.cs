using Jh.Abp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace Jh.Abp.EntityFrameworkCore
{
    public abstract class CrudRepository<TDbContext, TEntity, TKey> : EfCoreRepository<TDbContext, TEntity, TKey>, ICrudRepository<TEntity, TKey>
        where TDbContext : IEfCoreDbContext
        where TEntity : class, IEntity<TKey>
    {

        protected CrudRepository(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<TEntity[]> DeleteListAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            var _dbSet = await GetQueryableAsync();
            var entitys = _dbSet.AsNoTracking().Where(predicate).ToArray();
            return await DeleteAsync(autoSave, isHard, GetCancellationToken(cancellationToken), entitys: entitys);
        }

        public virtual async Task<TEntity[]> DeleteEntitysAsync(IQueryable<TEntity> query, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            var entitys = query.AsNoTracking().ToArray();
            return await DeleteAsync(autoSave, isHard, GetCancellationToken(cancellationToken), entitys: entitys);
        }

        public virtual async Task<TEntity[]> DeleteAsync(bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default, params TEntity[] entitys)
        {
            if (entitys == null || !entitys.Any())
            {
                return default;
            }
            if (isHard)
            {
                await HardDeleteWithUnitOfWorkAsync((hardDeleteEntities) =>
                {
                    foreach (var item in entitys)
                    {
                        hardDeleteEntities.Add(item);
                    }
                });
            }
            await DeleteManyAsync(entitys, autoSave, cancellationToken);
            return entitys;
        }

        protected virtual async Task HardDeleteWithUnitOfWorkAsync(Action<HashSet<IEntity>> deleteFun, CancellationToken cancellationToken = default)
        {
            var uowManager = base.UnitOfWorkManager;
            if (uowManager == null)
            {
                throw new AbpException($"{nameof(UnitOfWorkManager)} property of the given entity object is null!");
            }
            var currentUow = uowManager.Current;
            if (currentUow == null)
            {
                using (var uow = uowManager.Begin())
                {
                    HardDelete(currentUow, deleteFun);
                    await uow.CompleteAsync(GetCancellationToken(cancellationToken));
                }
            }
            else
            {
                HardDelete(currentUow, deleteFun);
            }
        }

        protected virtual void HardDelete(IUnitOfWork currentUow, Action<HashSet<IEntity>> deleteFun)
        {
            var hardDeleteEntities = (HashSet<IEntity>)currentUow.Items.GetOrAdd(
                    UnitOfWorkItemNames.HardDeletedEntities,
                    () => new HashSet<IEntity>()
                );
            deleteFun(hardDeleteEntities);
        }

        public virtual async Task<IQueryable<TEntity>> GetQueryableAsync(bool inApplyDataFilters, bool includeDetails = false, bool isTracking = false)
        {
            var query = includeDetails ? await WithDetailsAsync() : await GetDbSetAsync();
            query = inApplyDataFilters ? ApplyDataFilters(query) : query;//添加数据过滤
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public virtual async Task<IQueryable<T>> GetQueryableAsync<T>() where T : class
        {
            return (await GetDbContextAsync()).Set<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">使用 IsTracking 字段为false不跟踪</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetListAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return await query.ToListAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">使用 IsTracking 字段为false不跟踪</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<long> GetCountAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

/*
        public async Task<int> ContextSaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await (await GetDbContextAsync()).SaveChangesAsync(cancellationToken);
        }*/
    }
}
