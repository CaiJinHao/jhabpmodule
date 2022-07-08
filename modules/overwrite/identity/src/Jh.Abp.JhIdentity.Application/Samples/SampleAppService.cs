using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;

namespace Jh.Abp.JhIdentity.Samples;

[Dependency(ServiceLifetime.Singleton, ReplaceServices = true)]
public class SampleAppService : JhIdentityAppService, ISampleAppService
{
    protected IEmailSender emailSender => LazyServiceProvider.LazyGetRequiredService<IEmailSender>();
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

    public async Task TestEmailSenderAsync()
    {
        await emailSender.SendAsync("caijinhao@inspur.com", "金浩测试", "这是一个测试的邮件");
    }
}
