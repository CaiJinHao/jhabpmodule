﻿using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Application.Contracts
{
    /// <summary>
    /// 应用程序服务继承
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPagedRetrieveOutputDto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TRetrieveInputDto"></typeparam>
    /// <typeparam name="TCreateInputDto"></typeparam>
    /// <typeparam name="TUpdateInputDto"></typeparam>
    /// <typeparam name="TDeleteInputDto"></typeparam>
    public interface ICrudApplicationService<TEntity, TEntityDto, TPagedRetrieveOutputDto, in TKey, in TRetrieveInputDto, in TCreateInputDto, in TUpdateInputDto, in TDeleteInputDto>
    : ICrudAppService<TEntityDto, TPagedRetrieveOutputDto, TKey, TRetrieveInputDto, TCreateInputDto, TUpdateInputDto>
    {
        /// <summary>
        /// 为false时，获取不到扩展字段,默认为false
        /// </summary>
        bool IsTracking { get; set; }
        /// <summary>
        /// 创建一个实体[HttpPost]
        /// </summary>
        /// <param name="inputDto"></param>
        /// <param name="autoSave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> CreateAsync(TCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 创建多个实体[Route("list")][HttpPost]
        /// </summary>
        /// <param name="inputDtos"></param>
        /// <param name="autoSave"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity[]> CreateAsync(TCreateInputDto[] inputDtos, bool autoSave = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据条件删除多条[HttpDelete]
        /// </summary>
        Task<TEntity[]> DeleteAsync(TDeleteInputDto deleteInputDto, string methodStringType = ObjectMethodConsts.EqualsMethod, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据主键删除多条[Route("keys")][HttpDelete]
        /// </summary>
        Task<TEntity[]> DeleteAsync(TKey[] keys, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据主键删除
        /// </summary>
        Task<TEntity> DeleteAsync(TKey id, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据主键更新部分[HttpPatch]
        /// </summary>
        Task<TEntity> UpdatePortionAsync(TKey key, TUpdateInputDto inputDto, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> AnyAsync(TRetrieveInputDto inputDto, string methodStringType = ObjectMethodConsts.ContainsMethod, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据条件查询(不分页)[Route("list")][HttpGet]
        /// </summary>
        Task<ListResultDto<TEntityDto>> GetEntitysAsync(TRetrieveInputDto inputDto, string methodStringType = ObjectMethodConsts.ContainsMethod, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 重写分页列表 methodStringType
        /// </summary>
        Task<PagedResultDto<TPagedRetrieveOutputDto>> GetListAsync(TRetrieveInputDto input, string methodStringType = ObjectMethodConsts.ContainsMethod, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 获取entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntityDto> GetAsync(TKey id, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 获取entityDto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> GetEntityAsync(TKey id, bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
