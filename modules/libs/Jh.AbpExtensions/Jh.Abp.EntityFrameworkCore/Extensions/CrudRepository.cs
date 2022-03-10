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

        public virtual async Task<TEntity[]> CreateAsync(TEntity[] entitys, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            //使用SqlBulk
            await (await GetDbSetAsync()).AddRangeAsync(entitys);
            if (autoSave)
            {
                await (await GetDbContextAsync()).SaveChangesAsync(cancellationToken);
            }
            return entitys;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            await (await GetDbSetAsync()).AddAsync(entity);
            if (autoSave)
            {
                await (await GetDbContextAsync()).SaveChangesAsync(cancellationToken);
            }
            return entity;
        }

        public virtual async Task<TEntity[]> DeleteListAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _dbSet = await GetDbSetAsync();
            var entitys = _dbSet.AsNoTracking().Where(predicate).ToArray();
            return await DeleteAsync(autoSave, isHard, cancellationToken, entitys: entitys);
        }

        public virtual async Task<TEntity[]> DeleteEntitysAsync(IQueryable<TEntity> query, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entitys = query.AsNoTracking().ToArray();
            return await DeleteAsync(autoSave, isHard, cancellationToken, entitys: entitys);
        }

        public virtual async Task<IQueryable<TEntity>> GetQueryableAsync(bool includeDetails = false)
        {
            return includeDetails ? await WithDetailsAsync() : await GetDbSetAsync();
        }

        public virtual async Task<IQueryable<T>> GetQueryableAsync<T>() where T : class
        {
            return (await GetDbContextAsync().ConfigureAwait(continueOnCapturedContext: false)).Set<T>();
        }

        public virtual async Task<TEntity[]> DeleteAsync(bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken), params TEntity[] entitys)
        {
            if (entitys == null || !entitys.Any())
            {
                return default;
            }
            var _dbSet = await GetDbSetAsync();
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
            _dbSet.RemoveRange(entitys);
            if (autoSave)
            {
                await (await GetDbContextAsync()).SaveChangesAsync(cancellationToken);
            }
            return entitys;
        }

        protected virtual async Task HardDeleteWithUnitOfWorkAsync(Action<HashSet<IEntity>> deleteFun, CancellationToken cancellationToken = default(CancellationToken))
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
                    await uow.CompleteAsync(cancellationToken);
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

        public async Task<int> ContextSaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await (await GetDbContextAsync()).SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            var dbSet = (await GetDbContextAsync().ConfigureAwait(continueOnCapturedContext: false)).Set<T>();
            await dbSet.AddAsync(entity, cancellationToken);
        }
    }
}
