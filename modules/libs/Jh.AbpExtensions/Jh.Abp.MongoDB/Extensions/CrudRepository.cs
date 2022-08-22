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

        public virtual async Task<TEntity[]> CreateAsync(TEntity[] entitys, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            //使用SqlBulk
            await base.InsertManyAsync(entitys, autoSave, GetCancellationToken(cancellationToken));
            return entitys;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await base.InsertAsync(entity,autoSave, GetCancellationToken(cancellationToken));
            return entity;
        }

        public virtual async Task<TEntity[]> DeleteListAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            var _dbSet = await GetQueryableAsync();
            var entitys = _dbSet.Where(predicate).ToArray();
            return await DeleteAsync(autoSave, isHard, GetCancellationToken(cancellationToken), entitys: entitys);
        }

        public virtual async Task<TEntity[]> DeleteEntitysAsync(IQueryable<TEntity> query, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            var entitys = query.ToArray();
            return await DeleteAsync(autoSave, isHard, GetCancellationToken(cancellationToken), entitys: entitys);
        }
     
        public virtual async Task<TEntity[]> DeleteAsync(bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default, params TEntity[] entitys)
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
            await base.DeleteManyAsync(entitys, autoSave, GetCancellationToken(cancellationToken));
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
            var query = await GetMongoQueryableAsync();
            return inApplyDataFilters ? ApplyDataFilters(query) : query;//添加数据过滤
        }

        public virtual async Task<IQueryable<T>> GetQueryableAsync<T>() where T : class
        {
            return await GetMongoQueryableAsync<T>();
        }

        public async Task<List<TEntity>> GetListAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return await (query as IMongoQueryable<TEntity>).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(IQueryable<TEntity> query, CancellationToken cancellationToken = default)
        {
            return await (query as IMongoQueryable<TEntity>).LongCountAsync(GetCancellationToken(cancellationToken));
        }

        /*public virtual async Task<IQueryable<T>> GetQueryableAsync<T>() where T : class
        {
            return await GetMongoQueryableAsync<T>();
        }*/
    }
}
