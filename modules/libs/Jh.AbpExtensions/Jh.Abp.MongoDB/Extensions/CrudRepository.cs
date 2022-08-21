using Jh.Abp.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Volo.Abp.Uow;

namespace Jh.Abp.MongoDB
{
    public abstract class CrudRepository<TDbContext, TEntity, TKey> : MongoDbRepository<TDbContext, TEntity, TKey>, ICrudRepository<TEntity, TKey>
        where TDbContext : IAbpMongoDbContext
        where TEntity : class, IEntity<TKey>
    {

        protected CrudRepository(IMongoDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<TEntity[]> CreateAsync(TEntity[] entitys, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            //使用SqlBulk
            await base.InsertManyAsync(entitys, autoSave, cancellationToken);
            return entitys;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.InsertAsync(entity,autoSave, cancellationToken);
            return entity;
        }

        public virtual async Task<TEntity[]> DeleteListAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _dbSet = await GetQueryableAsync();
            var entitys = _dbSet.Where(predicate).ToArray();
            return await DeleteAsync(autoSave, isHard, cancellationToken, entitys: entitys);
        }

        public virtual async Task<TEntity[]> DeleteEntitysAsync(IQueryable<TEntity> query, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entitys = query.ToArray();
            return await DeleteAsync(autoSave, isHard, cancellationToken, entitys: entitys);
        }

        /// <summary>
        /// .AsNoTracking() 不跟踪加载不到扩展属性
        /// </summary>
        public virtual async Task<IQueryable<TEntity>> GetQueryableAsync(bool inApplyDataFilters, bool includeDetails = false)
        {
            var query = includeDetails ? await WithDetailsAsync() : await GetMongoQueryableAsync();
            return inApplyDataFilters ? ApplyDataFilters(query) : query;//添加数据过滤
        }

        public virtual async Task<IQueryable<T>> GetQueryableAsync<T>() where T : class
        {
            return await GetMongoQueryableAsync<T>();
        }

        public virtual async Task<TEntity[]> DeleteAsync(bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken), params TEntity[] entitys)
        {
            if (entitys == null || !entitys.Any())
            {
                return default;
            }
            var _dbSet = await GetMongoQueryableAsync();
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
            await base.DeleteManyAsync(entitys, autoSave, cancellationToken);
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

        public Task<int> ContextSaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(1);
        }

        public async Task AddAsync<T>(T entity, CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            var dbSet = (await GetDbContextAsync().ConfigureAwait(continueOnCapturedContext: false)).Collection<T>();
            await dbSet.InsertOneAsync(entity,cancellationToken:cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await (query as IMongoQueryable<TEntity>).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await (query as IMongoQueryable<TEntity>).LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public Task<IQueryable<TEntity>> GetTrackingAsync(IQueryable<TEntity> query, bool isTracking)
        {
            return Task.FromResult(query);
        }
    }
}
