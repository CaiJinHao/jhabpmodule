using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Application.Contracts
{
    /// <summary>
    /// 应用程序服务继承
    /// </summary>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPagedRetrieveOutputDto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TRetrieveInputDto"></typeparam>
    /// <typeparam name="TCreateInputDto"></typeparam>
    /// <typeparam name="TUpdateInputDto"></typeparam>
    /// <typeparam name="TDeleteInputDto"></typeparam>
    public interface ICrudApplicationService<TEntityDto, TPagedRetrieveOutputDto, in TKey, in TRetrieveInputDto, in TCreateInputDto, in TUpdateInputDto, in TDeleteInputDto>
    : ICrudAppService<TEntityDto, TPagedRetrieveOutputDto, TKey, TRetrieveInputDto, TCreateInputDto, TUpdateInputDto>
    {
        Task DeleteAsync(TKey[] keys);
        Task UpdatePortionAsync(TKey id, TUpdateInputDto inputDto);
        Task<ListResultDto<TPagedRetrieveOutputDto>> GetEntitysAsync(TRetrieveInputDto inputDto);
    }
}
