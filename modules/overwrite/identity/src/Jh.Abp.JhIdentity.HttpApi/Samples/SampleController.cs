using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using System.Linq;

namespace Jh.Abp.JhIdentity.Samples;

[ApiVersion("1.0")]
[ApiVersion("2.0")]
[ApiVersion("3.0")]
[Area(JhIdentityRemoteServiceConsts.ModuleName)]
[RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
[Route("api/v{apiVersion:apiVersion}/JhIdentity/sample")]
public class SampleController : JhIdentityController
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
}
