using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Pay.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
