using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Application.Contracts
{
    public interface IRequestRemoteService<TEntity, TEntityDto, TPagedRetrieveOutputDto, in TKey, in TRetrieveInputDto, in TCreateInputDto, in TUpdateInputDto, in TDeleteInputDto> : IApplicationService
    {
        Task<PagedResultDto<TPagedRetrieveOutputDto>> GetListAsync(TRetrieveInputDto input);
        Task<ListResultDto<TPagedRetrieveOutputDto>> GetEntitysAsync(TRetrieveInputDto inputDto);
        Task<TEntity> GetAsync(TKey id);
        Task CreateAsync(TCreateInputDto input);
        Task CreateAsync(TCreateInputDto[] input);
        Task<TPagedRetrieveOutputDto> UpdateAsync(TKey id, TUpdateInputDto input);
        Task UpdatePortionAsync(TKey id, TUpdateInputDto inputDto);
        Task DeleteAsync(TKey id);
        Task DeleteAsync(TDeleteInputDto deleteInputDto);
        Task DeleteAsync(TKey[] keys);
        Task UpdateDeletedAsync(TKey id, bool isDeleted);
        Task<ListResultDto<TPagedRetrieveOutputDto>> GetOptionsAsync(TRetrieveInputDto inputDto);
    }
}
