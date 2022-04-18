using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.JhIdentity.Samples;

[Dependency(ServiceLifetime.Singleton, ReplaceServices = true)]
public class SampleAppService : JhIdentityAppService, ISampleAppService
{
    protected IIdentityUserAppService IdentityUserAppService =>LazyServiceProvider.LazyGetRequiredService<IIdentityUserAppService>();
    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    public async Task TestTaskFactoryAsync()
    {
        _ = Task.Factory.StartNew(async () =>
        {
            var user = await IdentityUserAppService.GetAsync(new System.Guid("3a02a833-ee30-520a-d93a-86557523bbbe"));
            Logger.LogInformation($"数据{user.Id}");
        });
        await Task.CompletedTask;
    }
}
