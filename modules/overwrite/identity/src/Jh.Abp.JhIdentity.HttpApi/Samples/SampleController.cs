using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace Jh.Abp.JhIdentity.Samples;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0")]
[Area(JhIdentityRemoteServiceConsts.ModuleName)]
[RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
[Route("api/v{apiVersion:apiVersion}/JhIdentity/sample")]
public class SampleController : JhIdentityController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet("Claims")]
    [Authorize]
    [MapToApiVersion("1.0")]
    [MapToApiVersion("2.0")]
    [MapToApiVersion("3.0")]
    public dynamic GetAllClaims()
    {
        var u = CurrentUser;
        var t = CurrentTenant;
        var data = CurrentUser.GetAllClaims().Select(a => new { a.Value, a.ValueType, a.Type }).ToList();
        return data;
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public Task<string> PostAsyncV1()
    {
        return PostAsync("v1");
    }

    [HttpPost]
    [MapToApiVersion("2.0")]
    public Task<string> PostAsyncV2()
    {
        return PostAsync("v2");
    }

    [HttpPost]
    [MapToApiVersion("3.0")]
    public Task<string> PostAsyncV3()
    {
        return PostAsync("v3");
    }

    private Task<string> PostAsync(string msg)
    {
        return Task.FromResult($"{msg}-Post-{HttpContext.GetRequestedApiVersion().ToString()}");
    }

    [Authorize]
    [HttpGet]
    [Route("TestTaskFactory")]
    public async Task TestTaskFactoryAsync()
    {
        await _sampleAppService.TestTaskFactoryAsync();
    }

    [Authorize]
    [HttpGet]
    [Route("TestEmailSender")]
    public async Task TestEmailSenderAsync()
    {
        await _sampleAppService.TestEmailSenderAsync();
    }
}
