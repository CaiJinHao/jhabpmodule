using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Application.Contracts
{
    public interface ICrudApplicationService<TEntityDto, TPagedRetrieveOutputDto, in TKey, in TRetrieveInputDto, in TCreateInputDto, in TUpdateInputDto, in TDeleteInputDto>
    : ICrudAppService<TEntityDto, TPagedRetrieveOutputDto, TKey, TRetrieveInputDto, TCreateInputDto, TUpdateInputDto>
    {
        Task DeleteAsync(TKey[] keys);
        Task UpdatePortionAsync(TKey id, TUpdateInputDto inputDto);
        Task<ListResultDto<TPagedRetrieveOutputDto>> GetEntitysAsync(TRetrieveInputDto inputDto);
    }
}
