using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Entity;
using Jh.Abp.Common.Linq;
using Jh.Abp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Jh.Abp.Application
{
    public abstract class CrudApplicationService<TEntity, TEntityDto, TPagedRetrieveOutputDto, TKey, TRetrieveInputDto, TCreateInputDto, TUpdateInputDto, TDeleteInputDto>
        : CrudAppService<TEntity, TEntityDto, TPagedRetrieveOutputDto, TKey, TRetrieveInputDto, TCreateInputDto, TUpdateInputDto>
        , ICrudApplicationService<TEntity, TEntityDto, TPagedRetrieveOutputDto, TKey, TRetrieveInputDto, TCreateInputDto, TUpdateInputDto, TDeleteInputDto>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
        where TPagedRetrieveOutputDto : IEntityDto<TKey>
        where TRetrieveInputDto : ILimitedResultRequest
    {

        public ICrudRepository<TEntity, TKey> crudRepository;
        protected virtual string BatchDeletePolicyName { get; set; }

        /// <summary>
        /// 为false时，获取不到扩展字段,默认为false
        /// </summary>
        protected virtual bool IsTracking { get; set; } = false;

        public CrudApplicationService(ICrudRepository<TEntity, TKey> repository) : base(repository)
        {
            crudRepository = repository;
        }

        protected virtual async Task<TEntity> CreateAsync(TCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = ObjectMapper.Map<TCreateInputDto, TEntity>(inputDto);
            if (inputDto is IMethodDto<TEntity> methodDto)
            {
                if (methodDto.MethodInput != null)
                {
                    methodDto.MethodInput.CreateOrUpdateEntityAction?.Invoke(entity);
                }
            }
            return await crudRepository.CreateAsync(entity, autoSave, cancellationToken);
        }

        protected virtual async Task DeleteAsync(TKey[] keys, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            await crudRepository.DeleteListAsync(a => keys.Contains(a.Id), autoSave, isHard, cancellationToken);
        }

        protected virtual async Task DeleteAsync(TKey id, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            await crudRepository.DeleteListAsync(a => a.Id.Equals(id), autoSave, isHard, cancellationToken);
        }

        protected virtual async Task UpdatePortionAsync(TKey key, TUpdateInputDto updateInput, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entity = await crudRepository.FindAsync(key, includeDetails, cancellationToken);
            EntityOperator.UpdatePortionToEntity(updateInput, entity);
            if (updateInput is IMethodDto<TEntity> methodDto)
            {
                if (methodDto.MethodInput != null)
                {
                    methodDto.MethodInput.CreateOrUpdateEntityAction?.Invoke(entity);
                }
            }
        }

        protected virtual async Task<ListResultDto<TPagedRetrieveOutputDto>> GetEntitysAsync(TRetrieveInputDto inputDto, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            inputDto.MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount;
            var query = await CreateFilteredQueryAsync(await crudRepository.GetQueryableAsync(includeDetails), inputDto);
            query = ApplySorting(query, inputDto);
            query = ApplyPaging(query, inputDto);
            var methodDto = inputDto as IMethodDto<TEntity>;
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.SelectAction != null)
                    {
                        query = methodDto.MethodInput.SelectAction(query);
                    }
                }
            }
            var entities = await query.ToListAsync(cancellationToken);
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.CreateOrUpdateEntityAction != null)
                    {
                        foreach (var item in entities)
                        {
                            methodDto.MethodInput.CreateOrUpdateEntityAction(item);
                        }
                    }
                }
            }
            return new ListResultDto<TPagedRetrieveOutputDto>(
                 ObjectMapper.Map<List<TEntity>, List<TPagedRetrieveOutputDto>>(entities)
            );
        }
       
        protected virtual async Task<TEntityDto> GetAsync(TKey id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entity = await crudRepository.FindAsync(id, includeDetails, cancellationToken);//不用Find会查不出来扩展字段
            return await MapToGetOutputDtoAsync(entity);
        }

        protected virtual async Task<PagedResultDto<TPagedRetrieveOutputDto>> GetListAsync(TRetrieveInputDto input, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var query = await CreateFilteredQueryAsync(await crudRepository.GetQueryableAsync(includeDetails), input);

            var totalCount = await query.LongCountAsync(cancellationToken);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);
            var methodDto = input as IMethodDto<TEntity>;
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.SelectAction != null)
                    {
                        query = methodDto.MethodInput.SelectAction(query);
                    }
                }
            }
            var entities = await query.ToListAsync(cancellationToken);
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.CreateOrUpdateEntityAction != null)
                    {
                        foreach (var item in entities)
                        {
                            methodDto.MethodInput.CreateOrUpdateEntityAction(item);
                        }
                    }
                }
            }
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<TPagedRetrieveOutputDto>(
                totalCount,
                entityDtos
            );
        }

        protected override async Task<IQueryable<TEntity>> CreateFilteredQueryAsync(TRetrieveInputDto inputDto)
        {
            return await CreateFilteredQueryAsync(inputDto);
        }

        protected virtual async Task<IQueryable<TEntity>> CreateFilteredQueryAsync<TWhere>(TWhere inputDto)
        {
            return await CreateFilteredQueryAsync(await ReadOnlyRepository.GetQueryableAsync(), inputDto);
        }

        protected virtual Task<IQueryable<TEntity>> CreateFilteredQueryAsync<TWhere>(IQueryable<TEntity> queryable, TWhere inputDto)
        {
            if (!IsTracking)
            {
                queryable = queryable.AsNoTracking();//加上之后获取不到扩展字段
            }
            var methodDto = inputDto as IMethodDto<TEntity>;
            var methodStringType = methodDto?.MethodInput?.StringTypeQueryMethod;
            var lambda = LinqExpression.ConvetToExpression<TWhere, TEntity>(inputDto, methodStringType ?? ObjectMethodConsts.ContainsMethod);
            var query = queryable.Where(lambda);
            if (methodDto != null)
            {
                if (methodDto.MethodInput != null)
                {
                    if (methodDto.MethodInput.QueryAction != null)
                    {
                        query = methodDto.MethodInput.QueryAction(query);
                    }
                }
            }
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                if (inputDto is IRetrieveDelete retrieveDelete)
                {
                    if (retrieveDelete.Deleted.HasValue)
                    {
                        switch (retrieveDelete.Deleted)
                        {
                            case 1:
                                {
                                    query = query.Where(e => Convert.ToInt16(((ISoftDelete)e).IsDeleted) == 1);
                                    //query = query.Where(e => ((ISoftDelete)e).IsDeleted == true);
                                }
                                break;
                            case 2:
                                {
                                    query = query.Where(e => Convert.ToInt16(((ISoftDelete)e).IsDeleted) == 0);
                                    //query = query.Where(e => ((ISoftDelete)e).IsDeleted == false);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return Task.FromResult(query);
        }

        protected virtual async Task<bool> AnyAsync(TRetrieveInputDto inputDto, CancellationToken cancellationToken = default)
        {
            await CheckGetListPolicyAsync();
            var query = await CreateFilteredQueryAsync(await crudRepository.GetQueryableAsync(), inputDto);
            return query.Any();
        }

        protected virtual async Task DeleteAsync(TDeleteInputDto deleteInputDto, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            var query = await CreateFilteredQueryAsync(deleteInputDto);
            await crudRepository.DeleteEntitysAsync(query, autoSave, isHard, cancellationToken);
        }

        #region 兼容RemoteService

        public override async Task<TEntityDto> CreateAsync(TCreateInputDto input)
        {
            await CheckCreatePolicyAsync();
            var data = await CreateAsync(input, autoSave: false);
            return MapToGetOutputDto(data);
        }

        public virtual async Task DeleteAsync(TKey[] keys)
        {
            await CheckPolicyAsync(BatchDeletePolicyName);
            await DeleteAsync(keys, autoSave: false);
        }

        public override async Task DeleteAsync(TKey id)
        {
            await CheckDeletePolicyAsync();
            await DeleteAsync(id, autoSave: false);
        }

        public override async Task<TEntityDto> UpdateAsync(TKey id, TUpdateInputDto updateInput)
        {
            await CheckUpdatePolicyAsync();
            var entity = await GetEntityByIdAsync(id);//调用的是Repository的GetAsync
            await MapToEntityAsync(updateInput, entity);
            if (updateInput is IMethodDto<TEntity> methodDto)
            {
                if (methodDto.MethodInput != null)
                {
                    methodDto.MethodInput.CreateOrUpdateEntityAction?.Invoke(entity);
                }
            }
            return await MapToGetOutputDtoAsync(entity);
        }

        public virtual async Task UpdatePortionAsync(TKey id, TUpdateInputDto inputDto)
        {
            await CheckUpdatePolicyAsync();
            await UpdatePortionAsync(id, inputDto, includeDetails: false);
        }

        public virtual async Task<ListResultDto<TPagedRetrieveOutputDto>> GetEntitysAsync(TRetrieveInputDto inputDto)
        {
            await CheckGetListPolicyAsync();
            return await GetEntitysAsync(inputDto, includeDetails: false);
        }

        public override async Task<TEntityDto> GetAsync(TKey id)
        {
            await CheckGetPolicyAsync();
            return await GetAsync(id, includeDetails: false);
        }

        public override async Task<PagedResultDto<TPagedRetrieveOutputDto>> GetListAsync(TRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync();
            return await GetListAsync(input, includeDetails: false);
        }

        #endregion
    }
}
