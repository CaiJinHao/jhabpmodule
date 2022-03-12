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
        Task CreateAsync(TCreateInputDto input);
        Task DeleteAsync(TKey id);
        Task DeleteAsync(TKey[] keys);
        Task UpdatePortionAsync(TKey id, TUpdateInputDto inputDto);
        Task<TPagedRetrieveOutputDto> UpdateAsync(TKey id, TUpdateInputDto input);
        Task<TEntityDto> GetAsync(TKey id);
        Task<PagedResultDto<TPagedRetrieveOutputDto>> GetListAsync(TRetrieveInputDto input);
        Task<ListResultDto<TPagedRetrieveOutputDto>> GetEntitysAsync(TRetrieveInputDto inputDto);



        //如果需要可在RemoteService中添加
        //Task UpdateDeletedAsync(TKey id, bool isDeleted);
        //Task CreateAsync(TCreateInputDto[] input);
        //Task DeleteAsync(TDeleteInputDto deleteInputDto);
        //Task<ListResultDto<TPagedRetrieveOutputDto>> GetOptionsAsync(TRetrieveInputDto inputDto);
    }
}
