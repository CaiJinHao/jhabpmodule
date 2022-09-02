using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Jh.Abp.JhIdentity.Samples;

public class SampleAppService_Tests : JhIdentityApplicationTestBase
{
    private readonly ISampleAppService _sampleAppService;
    private readonly IEmailAppService emailAppService;

    public SampleAppService_Tests()
    {
        _sampleAppService = GetRequiredService<ISampleAppService>();
        emailAppService = GetRequiredService<IEmailAppService>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var result = await _sampleAppService.GetAsync();
        result.Value.ShouldBe(42);
    }

    [Fact]
    public async Task GetAuthorizedAsync()
    {
        var result = await _sampleAppService.GetAuthorizedAsync();
        result.Value.ShouldBe(42);
    }

    [Fact]
    public async Task SendEmailAsync()
    {
        var code = await emailAppService.GeneratorVerificationCodeAsync(6);
        var key = System.Guid.NewGuid().ToString("n");
        await emailAppService.SendEmailVerificationCodeAsync("caijinhaovip@126.com", key, code);
        Thread.Sleep(2000);
        var result= await emailAppService.ValidateEmailVerificationCodeAsync(key, code);
        result.ShouldBeTrue();
    }
}
