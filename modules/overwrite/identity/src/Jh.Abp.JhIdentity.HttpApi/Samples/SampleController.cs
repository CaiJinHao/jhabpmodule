using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using System.Linq;

namespace Jh.Abp.JhIdentity.Samples;

[Area(JhIdentityRemoteServiceConsts.ModuleName)]
[RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
[Route("api/JhIdentity/sample")]
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
    public dynamic GetAllClaims()
    {
        var u = CurrentUser;
        var t = CurrentTenant;
        var data= CurrentUser.GetAllClaims().ToList();
        return data;
    }
}
