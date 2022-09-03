using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.MailKit;

namespace Jh.Abp.JhIdentity.Samples;

[Dependency(ServiceLifetime.Singleton, ReplaceServices = true)]
public class SampleAppService : JhIdentityAppService, ISampleAppService
{
    protected IEmailAppService emailAppService => LazyServiceProvider.LazyGetRequiredService<IEmailAppService>();
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
        var code = "123456";
        var key = System.Guid.NewGuid().ToString("n");
        await emailAppService.SendEmailVerificationCodeAsync(new SendEmailVerificationCodeInputDto() { Email= "caijinhaovip@126.com" });
        Thread.Sleep(2000);
        var result = await emailAppService.ValidateEmailVerificationCodeAsync(key, code);
    }
}
