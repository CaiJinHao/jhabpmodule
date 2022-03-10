using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

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
        var u = CurrentUser;
        var t = CurrentTenant;
        return await _sampleAppService.GetAsync();
    }
}
